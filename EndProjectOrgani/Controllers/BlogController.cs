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
    public class BlogController : Controller
    {
        readonly IUow _uow;
        readonly AppDbContext _context;
        public BlogController(IUow uow, AppDbContext context = null)
        {
            _uow = uow;
            _context = context;
        }

        public async Task<IActionResult> BlogPage()
        {
            var list = await _context.Blogs.Where(x => x.Status != DataStatus.Deleted).Include(x => x.BlogDetails).OrderByDescending(x => x.Id).ToListAsync();

            return View(list);
        }
    }
}