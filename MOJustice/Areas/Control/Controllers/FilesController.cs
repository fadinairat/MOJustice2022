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

namespace MOJustice.Areas.Control.Controllers
{
    [Area("Control")]
    public class FilesController : Controller
    {
        private readonly DataContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public FilesController(DataContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment IHostingEnvironment, IMemoryCache cache)
        {
            _context = context;
            _environment = IHostingEnvironment;
        }

        // GET: Control/Files
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Files.Where(a => a.Deleted==0).Include(f => f.Category).Include(f => f.FileType).Include(f => f.Language).Include(f => f.User);
            return View(await dataContext.ToListAsync());
        }

        // GET: Control/Files/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Files == null)
            {
                return NotFound();
            }

            var files = await _context.Files
                .Include(f => f.Category)
                .Include(f => f.FileType)
                .Include(f => f.Language)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (files == null)
            {
                return NotFound();
            }

            return View(files);
        }

        // GET: Control/Files/Create
        public IActionResult Create()
        {
            ViewData["Cats"] = _context.Categories.Where(a => a.Deleted == 0 && a.TypeId == 2).ToList();
            ViewData["Type"] = new SelectList(_context.FileType, "Id", "Title");
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name");
            
            return View();
        }

        // POST: Control/Files/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatId,Name,ArName,Year,Type,Parent,Publish,Active,Thumb,LangId,Description,ArDescription,FilePath,Source,Priority,ShowHome,AllowComment,Date,Deleted")] Files files)
        {
            if (ModelState.IsValid)
            {
                files.AddDate = DateTime.Now;
                files.UserId = int.Parse(HttpContext.Session.GetString("id") ?? "1");
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var filePath = ImagesUplaod.UploadFile(HttpContext, "files/file/", _environment.WebRootPath, "FilePath");
                    files.FilePath = filePath;
                }
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var ImageUrl = ImagesUplaod.UploadSingleImage(HttpContext, "files/image/FilesImages/", _environment.WebRootPath, "Thumb");
                    files.Thumb = ImageUrl.Item1;
                }


                _context.Add(files);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cats"] = _context.Categories.Where(a => a.Deleted == 0 && a.TypeId == 2).ToList();
            ViewData["Type"] = new SelectList(_context.FileType, "Id", "Title", files.Type);
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", files.LangId);
            return View(files);
        }

        // GET: Control/Files/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Files == null)
            {
                return NotFound();
            }

            var files = await _context.Files.FindAsync(id);
            if (files == null)
            {
                return NotFound();
            }
            ViewData["Cats"] = _context.Categories.Where(a => a.Deleted == 0 && a.TypeId == 2).ToList();
            ViewData["Type"] = new SelectList(_context.FileType, "Id", "Title", files.Type);
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", files.LangId);
            return View(files);
        }

        // POST: Control/Files/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatId,Name,ArName,Year,Type,Parent,Publish,Active,Thumb,LangId,Description,ArDescription,FilePath,Source,Priority,ShowHome,AllowComment,UserId,Date,Deleted")] Files files)
        {
            if (id != files.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    files.UpdatedAt = DateTime.Now;
                    
                    if (HttpContext.Request.Form.Files.Count > 0)
                    {
                        var filePath = ImagesUplaod.UploadFile(HttpContext, "files/file/", _environment.WebRootPath, "FilePath");
                        files.FilePath = filePath;
                    }
                    if (HttpContext.Request.Form.Files.Count > 0)
                    {
                        var ImageUrl = ImagesUplaod.UploadSingleImage(HttpContext, "files/image/FilesImages/", _environment.WebRootPath, "Thumb");
                        files.Thumb = ImageUrl.Item1;
                    }
                    TempData["success"] = "File updated successfully...";
                    _context.Update(files);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilesExists(files.Id))
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
            ViewData["Cats"] = _context.Categories.Where(a => a.Deleted == 0 && a.TypeId == 2).ToList();
            ViewData["Type"] = new SelectList(_context.FileType, "Id", "Title", files.Type);
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", files.LangId);
            return View(files);
        }

        // GET: Control/Files/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Files == null)
            {
                return NotFound();
            }

            var files = await _context.Files
                .Include(f => f.Category)
                .Include(f => f.FileType)
                .Include(f => f.Language)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (files == null)
            {
                return NotFound();
            }

            return View(files);
        }

        // POST: Control/Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Files == null)
            {
                return Problem("Entity set 'DataContext.Files'  is null.");
            }
            var files = await _context.Files.FindAsync(id);
            if (files != null)
            {
                files.Deleted = 1;
                _context.Update(files);
                await _context.SaveChangesAsync();

                TempData["success"] = "File removed successfully...";
                //_context.Files.Remove(files);
            }
            else
            {
                TempData["error"] = "Cannot remove the page...";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilesExists(int id)
        {
          return (_context.Files?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
