﻿using System;
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
            var productdetails = await _context.Products.Where(x => x.Status != DataStatus.Deleted).Include(x => x.ProductDetails).OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.Id == id);

            var productlist = await _uow.GetRepository<Product>().GetAllOrderByAsync(x => x.Id, false);

            return View((productdetails, productlist));
        }
    }
}
