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
    [Authorize(Roles = "Admin")]
    public class ProductDetailController : Controller
    {
        readonly AppDbContext _context;
        public ProductDetailController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProductDetailList(int page = 1, int take = 8)
        {

            var ProductDetails = from b in _context.ProductDetails.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Product)
                                 select b;

            int count = await GetPageCount(take);

            var ProductDetailList = await ProductDetails.Skip((page - 1) * take).Take(take).ToListAsync();

            Paginate<ProductDetail> result = new Paginate<ProductDetail>(ProductDetailList, page, count);

            return View(result);
        }

        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.ProductDetails.CountAsync();

            return (int)Math.Ceiling((decimal)count / take);
        }



        public async Task<IActionResult> Create()
        {
            var model = await _context.Products.Where(x => x.Status != DataStatus.Deleted).OrderByDescending(x => x.Id).ToListAsync();

            var details = new ProductDetail();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] ProductDetail details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            await _context.ProductDetails.AddAsync(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductDetailList", "ProductDetail", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var details = await _context.ProductDetails.FindAsync(id);
            var model = await _context.Products.Where(x => x.Status != DataStatus.Deleted).OrderByDescending(x => x.Id).ToListAsync();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] ProductDetail details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            details.Status = DataStatus.Updated;
            details.ModifatedDate = DateTime.Now;

            _context.ProductDetails.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductDetailList", "ProductDetail", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var details = _context.ProductDetails.Find(id);

            _context.ProductDetails.Remove(details);

            await _context.SaveChangesAsync();

            return RedirectToAction("ProductDetailList", "ProductDetail", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var details = await _context.ProductDetails.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
    }
}
