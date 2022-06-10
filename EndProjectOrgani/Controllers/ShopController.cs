using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndProjectOrgani.Context;
using EndProjectOrgani.Entities;
using EndProjectOrgani.UniteOfWork;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> ShopPage()
        {
            var saleoff = await _uow.GetRepository<SaleOff>().GetAllOrderByAsync(x => x.Id, false);
            var categories = await _uow.GetRepository<Category>().GetAllOrderByAsync(x => x.Id, true);
            var products = await _uow.GetRepository<Product>().GetAllOrderByAsync(x => x.Id, false);
            return View((saleoff, products, categories));
        }
    }
}
