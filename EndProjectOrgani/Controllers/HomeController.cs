using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EndProjectOrgani.Models;
using EndProjectOrgani.UniteOfWork;
using EndProjectOrgani.Context;
using EndProjectOrgani.Entities;
using Microsoft.EntityFrameworkCore;

namespace EndProjectOrgani.Controllers
{
    public class HomeController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        public HomeController(IUow uow, AppDbContext context)
        {
            _uow = uow;
            _context = context;
        }



        public async Task<IActionResult> HomePage()
        {
            var categories = await _uow.GetRepository<Category>().GetAllOrderByAsync(x => x.Id, false);
            var products = await _context.Products.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Category).ToListAsync();
            var blogs = await _context.Blogs.Where(x => x.Status != DataStatus.Deleted).Include(x => x.BlogDetails).OrderByDescending(x => x.Id).ToListAsync();
            var advert = await _uow.GetRepository<Advert>().GetAllOrderByAsync(x => x.Id, false);
            return View((categories, products, blogs, advert));
        }

        [HttpPost]
        public async Task<IActionResult> SubscribePage(Subscribe subscribe)
        {
            if (!ModelState.IsValid) return RedirectToAction("HomePage");

            await _context.Subscribes.AddAsync(subscribe);
            await _context.SaveChangesAsync();
            return RedirectToAction("HomePage");
        }

    }

}
