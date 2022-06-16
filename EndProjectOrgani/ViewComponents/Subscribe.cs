using System;
using EndProjectOrgani.Context;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.ViewComponents
{
    public class Subscribe : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new Subscribe();
            return View(model);
        }
    }
}
