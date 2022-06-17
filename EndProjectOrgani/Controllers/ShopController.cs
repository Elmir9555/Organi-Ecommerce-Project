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
    public class ShopController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        public ShopController(IUow uow, AppDbContext context)
        {
            _uow = uow;
            _context = context;
        }

        public async Task<IActionResult> ShopPage(int page = 1, int take = 9)
        {
            var saleoff = await _uow.GetRepository<SaleOff>().GetAllOrderByAsync(x => x.Id, false);
            var categories = await _uow.GetRepository<Category>().GetAllOrderByAsync(x => x.Id, true);
            var productss = await _uow.GetRepository<Product>().GetAllOrderByAsync(x => x.Id, false);

          List<Product> products = await _context.Products
          .Where(x => x.Status != DataStatus.Deleted)
          .Skip((page - 1) * take)
          .Take(take)
          .OrderBy(m => m.Id)
          .ToListAsync();


            var productsVM = GetMapDatas(products);

            int count = await GetPageCount(take);

            Paginate<ProductVM> result = new Paginate<ProductVM>(productsVM, page, count);



            return View((saleoff, productss, categories,result));
        }

        public async Task<List<Product>> GetProductsWithPrice(int minValue, int maxValue)
        {
            return await _context.Products.Where(m => m.Price >= (decimal)minValue && m.Price <= (decimal)maxValue).ToListAsync();
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
                    Count = product.Count,
                    Category = product.Category,
                    CategoryId = product.CategoryId


                };

                productList.Add(newProduct);
            }

            return productList;
        }


    }
}
