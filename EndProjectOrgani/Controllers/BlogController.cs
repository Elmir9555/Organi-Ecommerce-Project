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

        public async Task<IActionResult> BlogDetailsPage(int id)
        {
            var blog = await _context.Blogs.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Owner).Include(x => x.BlogDetails).FirstOrDefaultAsync(x => x.Id == id);

            return View(blog);
        }

        public async Task<IActionResult> BlogSearch(string search)
        {
            var blogs = from m in _context.Blogs.Include(x=> x.BlogDetails) select m;

            if (!String.IsNullOrEmpty(search))
            {
                blogs = blogs.Where(x => x.Title.Contains(search));
            }

            return View("BlogPage", (await blogs.Where(x => x.Status != DataStatus.Deleted).ToListAsync()));
        }
    }
}
