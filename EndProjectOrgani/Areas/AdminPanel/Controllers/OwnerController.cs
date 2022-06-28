using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EndProjectOrgani.Context;
using EndProjectOrgani.Entities;
using EndProjectOrgani.UniteOfWork;
using EndProjectOrgani.Utilities.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndProjectOrgani.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class OwnerController : Controller
    {
        readonly IUow _uow;
        readonly IWebHostEnvironment _env;
        readonly AppDbContext _context;
        public OwnerController(IUow uow, IWebHostEnvironment env, AppDbContext context)
        {
            _uow = uow;
            _env = env;
            _context = context;
        }

        public async Task<IActionResult> OwnerList(int page = 1, int take = 8)
        {
            var Owners = from b in _context.Owners.Where(x => x.Status != DataStatus.Deleted)
                           select b;

            int count = await GetPageCount(take);

            var OwnerList = await Owners.Skip((page - 1) * take).Take(take).ToListAsync();

            Paginate<Owner> result = new Paginate<Owner>(OwnerList, page, count);

            return View(result);
        }

        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Owners.CountAsync();

            return (int)Math.Ceiling((decimal)count / take);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Owner model)
        {
            if (!ModelState.IsValid)
                return View();
            if (!model.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }


            string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/owner", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await model.Photo.CopyToAsync(stream);
            }
            model.Image = fileName;

            await _uow.GetRepository<Owner>().CreateAsync(model);
            await _uow.SaveChangeAsync();

            return RedirectToAction("OwnerList", "Owner", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _uow.GetRepository<Owner>().FindAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Owner model)
        {
            var Dbentity = await _uow.GetRepository<Owner>().FindAsync(id);

            if (!ModelState.IsValid) return View(model);

            if (!model.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View(model);
            }

            string oldPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/owner", Dbentity.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/owner", fileName);
            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await model.Photo.CopyToAsync(stream);
            }

            Dbentity.Image = fileName;
            Dbentity.Fullname = model.Fullname;
            Dbentity.Profession = model.Profession;
            Dbentity.Status = DataStatus.Updated;
            Dbentity.ModifatedDate = DateTime.Now;

            await _uow.SaveChangeAsync();
            return RedirectToAction("OwnerList", "Owner", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _uow.GetRepository<Owner>().FindAsync(id);
            if (entity == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/owner", entity.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            //_uow.GetRepository<Category>().Delete(entity);

            entity.Image = string.Empty;
            entity.Status = DataStatus.Deleted;
            entity.ModifatedDate = DateTime.Now;
            await _uow.SaveChangeAsync();

            return RedirectToAction("OwnerList", "Owner", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _uow.GetRepository<Owner>().FindAsync(id);
            return View(entity);
        }
    }
}
