using System;
using System.Linq;
using EndProjectOrgani.Context;
using EndProjectOrgani.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.ViewComponents
{
    public class ProductSearch : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            var product = new Product();

            return View(product);
        }
    }
}
