using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndProjectOrgani.Context;
using EndProjectOrgani.Entities;
using EndProjectOrgani.UniteOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndProjectOrgani.Controllers
{
    public class ProductController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        public ProductController(IUow uow, AppDbContext context)
        {
            _uow = uow;
            _context = context;
        }

        public async Task<IActionResult> ProductPage()
        {
            var list = await _uow.GetRepository<Product>().GetAllOrderByAsync(x => x.Id, false);

            return View(list);
        }


        public async Task<IActionResult> ProductCategoryPage(int id)
        {
            var list = await _context.Products.Where(x => x.Status != DataStatus.Deleted).Where(x => x.CategoryId == id).Include(x => x.Category).OrderByDescending(x => x.Id).ToListAsync();

            return View(list);
        }

        public async Task<IActionResult> ProductDetailsPage(int id)
        {
            var productdetails = await _context.Products.Where(x => x.Status != DataStatus.Deleted).Include(x => x.ProductDetails).FirstOrDefaultAsync(x => x.Id == id);

            var productlist = await _uow.GetRepository<Product>().GetAllOrderByAsync(x => x.Id, false);

            var commentlist = await _uow.GetRepository<Comment>().GetAllOrderByAsync(x => x.Id, false);

            var comment = await _context.Comments.FindAsync(id);

            TempData["ProId"] = id;
            
            return View((productdetails, productlist, commentlist, comment));
        }

        [HttpPost]
        public async Task<IActionResult> Comment([Bind(Prefix ="Item4")]Comment model)
        {
            var id = TempData["ProId"];

            model.ProductId = (int)id;


            await _context.Comments.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("HomePage","Home");
        }

        public async Task<IActionResult> ProductSearch(string search)
        {
            var products = from m in _context.Products select m;

            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.Name.Contains(search));
            }

            return View("ProductPage", (await products.Where(x => x.Status != DataStatus.Deleted).ToListAsync()));
        }

    }
}
