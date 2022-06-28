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
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        readonly IUow _uow;
        readonly IWebHostEnvironment _env;
        readonly AppDbContext _context;
        public CategoryController(IUow uow, IWebHostEnvironment env, AppDbContext context)
        {
            _uow = uow;
            _env = env;
            _context = context;
        }

        public async Task<IActionResult> CategoryList(int page = 1, int take = 8)
        {
            var Categories = from b in _context.Categories.Where(x => x.Status != DataStatus.Deleted)
                             select b;

            int count = await GetPageCount(take);

            var CategoryList = await Categories.Skip((page - 1) * take).Take(take).ToListAsync();

            Paginate<Category> result = new Paginate<Category>(CategoryList, page, count);

            return View(result);
        }

        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Categories.CountAsync();

            return (int)Math.Ceiling((decimal)count / take);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
                return View();
            if (!category.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }


            string fileName = Guid.NewGuid().ToString() + "_" + category.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await category.Photo.CopyToAsync(stream);
            }
            category.Image = fileName;

            await _uow.GetRepository<Category>().CreateAsync(category);
            await _uow.SaveChangeAsync();

            return RedirectToAction("CategoryList", "Category", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _uow.GetRepository<Category>().FindAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Category category)
        {
            var Dbcategory = await _uow.GetRepository<Category>().FindAsync(id);

            if (!ModelState.IsValid) return View(category);

            if (!category.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View(category);
            }

            string oldPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", Dbcategory.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + category.Photo.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", fileName);
            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await category.Photo.CopyToAsync(stream);
            }

            Dbcategory.Image = fileName;
            Dbcategory.Name = category.Name;
            Dbcategory.Status = DataStatus.Updated;
            Dbcategory.ModifatedDate = DateTime.Now;

            await _uow.SaveChangeAsync();
            return RedirectToAction("CategoryList", "Category", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _uow.GetRepository<Category>().FindAsync(id);
            if (entity == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/category", entity.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            //_uow.GetRepository<Category>().Delete(entity);

            entity.Image = string.Empty;
            entity.Status = DataStatus.Deleted;
            entity.ModifatedDate = DateTime.Now;
            await _uow.SaveChangeAsync();

            return RedirectToAction("CategoryList", "Category", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _uow.GetRepository<Category>().FindAsync(id);
            return View(entity);
        }
    }

}
