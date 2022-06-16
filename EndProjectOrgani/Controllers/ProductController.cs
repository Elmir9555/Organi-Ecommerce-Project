using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndProjectOrgani.Context;
using EndProjectOrgani.Entities;
using EndProjectOrgani.UniteOfWork;
using EndProjectOrgani.Utilities.Paginations;
using EndProjectOrgani.ViewModels.Admin.ProductViewModels;
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

        public async Task<IActionResult> ProductPage(int page = 1, int take = 9)
        {

            List<Product> products = await _context.Products
            .Where(x=> x.Status != DataStatus.Deleted)
            .Skip((page - 1) * take)
            .Take(take)
            .OrderBy(m => m.Id)
            .ToListAsync();


            var productsVM = GetMapDatas(products);

            int count = await GetPageCount(take);

            Paginate<ProductVM> result = new Paginate<ProductVM>(productsVM, page, count);

            

            //var list = await _uow.GetRepository<Product>().GetAllOrderByAsync(x => x.Id, false);

            return View(result);
        }


        public async Task<IActionResult> ProductCategoryPage(int id, int page = 1, int take = 9)
        {
            //var list = await _context.Products.Where(x => x.Status != DataStatus.Deleted).Where(x => x.CategoryId == id).Include(x => x.Category).OrderByDescending(x => x.Id).ToListAsync();


            List<Product> products = await _context.Products
              .Where(x => x.Status != DataStatus.Deleted).Where(x => x.CategoryId == id).Include(x => x.Category).OrderByDescending(x => x.Id)
              .Skip((page - 1) * take)
              .Take(take)
              .OrderBy(m => m.Id)
              .ToListAsync();
        

            var productsVM = GetMapDatas(products);

            int count = await GetPageCount(take);

            Paginate<ProductVM> result = new Paginate<ProductVM>(productsVM, page, count);

            return View(result);
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







        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Products.CountAsync();

            return (int)Math.Ceiling((decimal)count / take);
        }

        private List<ProductVM> GetMapDatas(List<Product> products)
        {
            List<ProductVM> productList = new List<ProductVM>();

            foreach (var product in products)
            {
                ProductVM newProduct = new ProductVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Price = product.Price,
                    Count=product.Count,
                    Category=product.Category,
                    CategoryId=product.CategoryId


                };

                productList.Add(newProduct);
            }

            return productList;
        }

    }

}

