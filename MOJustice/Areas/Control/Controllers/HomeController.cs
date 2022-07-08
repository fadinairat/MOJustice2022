using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOE.Models;

namespace MOE.Areas.Control.Controllers
{
    [Authorize]
    [Area("Control")]
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        // GET: HomeController
        //[Authorize(Roles = "Admin")]
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            ViewBag.PagesCount = _context.Pages.Where(a => a.Deleted == false).Count();
            ViewBag.FilesCount = _context.Files.Where(a => a.Deleted == 0).Count();
            ViewBag.CatsCount = _context.Categories.Where(a => a.Deleted == 0).Count();

            ViewBag.mostVisited = _context.Pages.Where(a => a.Deleted == false).OrderByDescending(a => a.Views).ToList();


            return View();
        }


        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View(id);
        }

        public ActionResult Techs()
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
