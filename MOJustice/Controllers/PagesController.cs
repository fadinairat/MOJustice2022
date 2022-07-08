using Microsoft.AspNetCore.Mvc;
using MOE.Models;
using MOE.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MOJustice.Controllers
{
    
    public class PagesController : Controller
    {
        private readonly DataContext _context;

        public PagesController(DataContext context)
        {
            _context = context;
        }

        // Get: Pages/Details/ID
        public async Task<IActionResult> Details(int? id, string title)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var pageDetails = _context.Pages.Where(a => a.PageId == id && a.Deleted == false && a.Active == true && a.Publish == true).FirstOrDefault();

            if (pageDetails == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            pageDetails.Views = pageDetails.Views + 1;
            _context.Update(pageDetails);
            await _context.SaveChangesAsync();

            String route = "<a href='"+Url.Action("Index", "Home")+ "' >الرئيسية &raquo;</a>";
            PageCategory cat = _context.PagesCategories
                .Include(a => a.Category)
                .Where(a => a.PageId == id)
                .FirstOrDefault();
            if(cat != null && cat.Category.ShowInPath== true)
            {
                route += " <a href='" + Url.Action("Details", "Categories", new {id= cat.Id, title=cat.Category.ArName }) + "' >"+cat.Category.ArName+" &raquo;</a>";
            }

            ViewBag.Route = route;

            return View(pageDetails);
        }
    }
}
