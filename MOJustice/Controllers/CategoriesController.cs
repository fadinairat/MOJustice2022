using Microsoft.AspNetCore.Mvc;
using MOE.Models;
using MOE.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MOJustice.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DataContext _context;  

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        // Get: Categories/Details/ID
        public async Task<IActionResult> Details(int? id, string title)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            int skipVal = 0;
            String route = "<a href='" + Url.Action("Index", "Home") + "' >الرئيسية &raquo;</a>";
            ViewBag.Route = route;


            var catDetails = _context.Categories.Where(a => a.Id == id && a.Deleted == 0 && a.Active == true)                
                .FirstOrDefault();
            if(catDetails == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            if(catDetails.TypeId == 1)
            {
                //If Page Category
                var pageList = _context.PagesCategories.Where(a => a.CategoryId == id && a.Page.Active == true && a.Page.Deleted == false && a.Page.Publish == true && (a.Page.ValidDate == null || a.Page.ValidDate >= DateTime.Now.Date))
                    .Include(a => a.Page)
                    .OrderByDescending(a => a.Page.Sticky)
                    .OrderByDescending(a => a.Page.PageDate)
                    .OrderByDescending(a => a.Page.PageId)
                    .Skip(skipVal);

                ViewBag.Template = "Templates/3cols_cat";
                ViewBag.pageList = pageList;

                //return Json(new{
                //    Pages= pageList
                //});

                return View(catDetails);
            }
            else if(catDetails.TypeId == 2)
            {
                //File Category

            }
            else if(catDetails.TypeId == 3)
            {
                //Photos

            }
            else if(catDetails.TypeId == 4)
            {
                //Video Gallery
            }
            else if(catDetails.TypeId == 5)
            {
                //Audio Gallery
            }
            return View(catDetails);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
