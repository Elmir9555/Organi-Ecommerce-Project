using System;
using Microsoft.AspNetCore.Mvc;

namespace EndProjectOrgani.ViewComponents
{
    public class SortByOrder : ViewComponent
    {
        public IViewComponentResult Invoke(string action)
        {
            ViewBag.Action = action;

            return View();
        }
    }
}
