using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOE.Models;
using MOE.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace MOE.Areas.Control.Controllers
{
    [Area("Control")]
    public class CategoriesController : Controller
    {
        private readonly DataContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;


        public CategoriesController(DataContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment IHostingEnvironment, IMemoryCache cache)
        {
            _context = context;
            _environment = IHostingEnvironment;
        }

        // GET: Control/Categories
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Categories.Include(c => c.HtmlTemplate).Include(c => c.Language)
            .Include(a => a.Language)
            .Include(a => a.CategoryTypes)
            .Where(a => a.Deleted == 0);
            return View(await dataContext.ToListAsync());
        }

        // GET: Control/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.HtmlTemplate)
                .Include(c => c.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Control/Categories/Create
        public IActionResult Create()
        {
            ViewData["TemplateId"] = new SelectList(_context.HtmlTemplates, "Id", "Name");
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name");
            ViewData["Types"] = new SelectList(_context.Category_Types, "Id", "Title");
            ViewData["Parents"] = _context.Categories.Where(a => a.Deleted == 0 && a.ParentId == 0).ToList();

            return View();
        }

        // POST: Control/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArName,Slug,Thumb,Priority,ParentId,TemplateId,ItemsPerPage,TypeId,Description,ArDescription,LangId,ShowAsMain,ShowInSiteMap,ShowDescription,ShowTitle,ShowThumb,ShowInPath,ShowInSearch,ShowDate,ShowInCatList")] Category category)
        {
            //ModelState.Remove("")
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("id") != "")
                {
                    category.UserId = int.Parse(HttpContext.Session.GetString("id") ?? "1");
                }
                else category.UserId = null;

                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var ImageUrl = ImagesUplaod.UploadImage(HttpContext, "files/image/CatImages/", _environment.WebRootPath);
                    category.Thumb = ImageUrl.Item1;
                }

                _context.Add(category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category added successfully...";

                return RedirectToAction(nameof(Index));
            }
            ViewData["TemplateId"] = new SelectList(_context.HtmlTemplates, "Id", "Name", category.TemplateId);
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", category.LangId);
            ViewData["Types"] = new SelectList(_context.Category_Types, "Id", "Title");
            ViewData["Parents"] = _context.Categories.Where(a => a.Deleted == 0 && a.ParentId == 0).ToList();
            return View(category);
        }

        // GET: Control/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["TemplateId"] = new SelectList(_context.HtmlTemplates, "Id", "Name", category.TemplateId);
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", category.LangId);
            ViewData["Types"] = new SelectList(_context.Category_Types, "Id", "Title");
            ViewData["Parents"] = _context.Categories.Where(a => a.Deleted == 0 && a.ParentId == 0).ToList();
            return View(category);
        }

        // POST: Control/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArName,Slug,Priority,ParentId,TemplateId,ItemsPerPage,TypeId,Description,ArDescription,LangId,ShowAsMain,ShowInSiteMap,ShowDescription,ShowTitle,ShowThumb,ShowInPath,ShowInSearch,ShowDate,ShowInCatList,Deleted")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (HttpContext.Request.Form.Files.Count > 0)
                    {
                        var ImageUrl = ImagesUplaod.UploadImage(HttpContext, "files/image/CatImages/", _environment.WebRootPath);
                        category.Thumb = ImageUrl.Item1;
                    }

                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Category edited successfully...";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TemplateId"] = new SelectList(_context.HtmlTemplates, "Id", "Name", category.TemplateId);
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", category.LangId);
            ViewData["Types"] = new SelectList(_context.Category_Types, "Id", "Title");
            ViewData["Parents"] = _context.Categories.Where(a => a.Deleted == 0 && a.ParentId == 0).ToList();
            return View(category);
        }

        // GET: Control/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.HtmlTemplate)
                .Include(c => c.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Control/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'DataContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.Deleted = 1;
                _context.Update(category);
                await _context.SaveChangesAsync();
                //_context.Categories.Remove(category);
                TempData["success"] = "Category deleted successfully...";
            }
            else
            {
                TempData["error"] = "Cannot delete category...";
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
