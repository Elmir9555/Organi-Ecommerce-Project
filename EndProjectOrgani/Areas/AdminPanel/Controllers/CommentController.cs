using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndProjectOrgani.Context;
using EndProjectOrgani.Entities;
using EndProjectOrgani.Utilities.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndProjectOrgani.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles ="Admin")]
    public class CommentController : Controller
    {
        readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CommentList(int page = 1, int take = 8)
        {
            var Comments = from b in _context.Comments.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Product)
                           select b;

            int count = await GetPageCount(take);

            var CommentList = await Comments.Skip((page - 1) * take).Take(take).ToListAsync();

            Paginate<Comment> result = new Paginate<Comment>(CommentList, page, count);

            return View(result);
        }

        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Comments.CountAsync();

            return (int)Math.Ceiling((decimal)count / take);
        }



        public async Task<IActionResult> Update(int id)
        {
            var details = await _context.Comments.FindAsync(id);
            var saleoff = await _context.SaleOffs.Where(x => x.Status != DataStatus.Deleted!).ToListAsync();

            return View((details, saleoff));
        }
        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] Comment details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            details.Status = DataStatus.Updated;
            details.ModifatedDate = DateTime.Now;
            _context.Comments.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("CommentList", "Comment", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var details = await _context.Comments.FindAsync(id);

            //_context.ProductDetails.Remove(details);

            details.Status = DataStatus.Deleted;
            details.ModifatedDate = DateTime.Now;
            _context.Comments.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("CommentList", "Comment", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var details = await _context.Comments.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
    }
}
