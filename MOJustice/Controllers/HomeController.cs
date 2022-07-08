using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOE.Models;


namespace MOJustice.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            //ViewBag.LatestNews = _context.Pages
            //    .Where(a => a.Deleted == false && a.Active == true && a.Publish == true)
            //    //.Include(a => a.PageCategories)
            //    .ToList();
            ViewBag.About = _context.Pages.Where(a => a.Deleted == false && a.PageId == 3).FirstOrDefault();

            ViewBag.LatestNews = _context.PagesCategories
                .Include(a => a.Page)
                .Include(a => a.Category)
                .Where(a => a.CategoryId == 10 && a.Page.Active == true && a.Page.Publish == true && a.Page.Deleted == false)
                .ToList();


            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
