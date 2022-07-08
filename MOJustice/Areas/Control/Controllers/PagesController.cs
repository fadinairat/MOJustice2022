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
    public class PagesController : Controller
    {
        private readonly DataContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public PagesController(DataContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment IHostingEnvironment, IMemoryCache cache)
        {
            _context = context;
            _environment = IHostingEnvironment;
        }

        public async Task<IActionResult> getLinks(string keyword,string type, int lang)
        {
            if (type == "category")
            {
                var catList = await _context.Categories.Where(a => a.Deleted == 0 && (a.LangId == 1 || a.LangId == lang) && (a.Name.Contains(keyword) || a.ArName.Contains(keyword)))
                    .Select(a => new {a.Id, a.Name, a.ArName, a.LangId})
                    .ToListAsync();
                return Json(new
                {
                    kayword = keyword,
                    type = type,
                    lang = lang,
                    links = catList
                });
            }
            else if(type == "file")
            {
                var fileList = await _context.Files.Where(a => a.Deleted == 0 && (a.LangId == 1 || a.LangId == lang) && (a.Name.Contains(keyword) || a.ArName.Contains(keyword)))
                    .Select(a => new {a.Id, a.Name, a.ArName, a.LangId})
                    .ToListAsync();
                return Json(new
                {
                    kayword = keyword,
                    type = type,
                    lang = lang,
                    links = fileList
                });
            }
            else { //Page
                var pagesList = await _context.Pages.Where(a => a.Deleted == false && (a.LangId==1 || a.LangId== lang) && a.Title.Contains(keyword))
                    .Select(a => new { a.Title, a.PageId, a.LangId }).ToListAsync();
                return Json(new
                {
                    kayword = keyword,
                    type = type,
                    lang = lang,
                    links = pagesList
                });
            }
        }

        // GET: Control/Pages
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Pages.Include(p => p.HtmlTemplate).Include(p => p.Language).Include(p => p.PageRef).Include(p => p.UserAdd)
                .Where(a => a.Deleted == false);
            return View(await dataContext.ToListAsync());
        }

        // GET: Control/Pages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .Include(p => p.HtmlTemplate)
                .Include(p => p.Language)
                .Include(p => p.PageRef)
                .Include(p => p.UserAdd)
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Control/Pages/Create
        public IActionResult Create()
        {
            ViewData["Cats"] = _context.Categories.Where(a => a.Deleted == 0 && a.TypeId == 1).ToList();
            ViewData["TemplateId"] = _context.HtmlTemplates.Where(a => a.Deleted == 0 && a.Type ==1).ToList();
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name");
            ViewData["Parent"] = _context.Pages.Where(a => a.Deleted == false && (a.Parent == 0 || a.Parent == null)).ToList();
            return View();
        }

        // POST: Control/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,TranslateId,Title,PageDate,AddDate,LangId,Body,Slug,Url,RedirectUrl,Thumb,Thumb2,ShowThumb,MetaDescription,MetaKeywords,TemplateId,Priority,Publish,Active,AsMenu,ShowAsMain,Parent,ShowInSearchPage,ShowInSiteMap,ShowDate,AllowComment,ShowAsRelated,Summary,ValidDate,SubTitle,Gallery,ShowRelated,Sticky,Deleted,Archive,Views,Video,Audio,UserId,EditedBy,LastEdit")] Page page)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("id") != "")
                {
                    page.UserId = int.Parse(HttpContext.Session.GetString("id") ?? "1");
                }
                else page.UserId = null;

                page.AddDate = DateTime.Now;

                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var ImageUrl = ImagesUplaod.UploadSingleImage(HttpContext, "files/image/PageImages/", _environment.WebRootPath,"Thumb");
                    page.Thumb = ImageUrl.Item1;
                }
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var ImageUrl = ImagesUplaod.UploadSingleImage(HttpContext, "files/image/PageImages/", _environment.WebRootPath, "Thumb2");
                    page.Thumb2 = ImageUrl.Item1;
                }

                if (HttpContext.Request.Form["Category"] != "")
                {
                    page.PageCategories = new List<PageCategory>();
                    var pg_cat = new PageCategory { PageId = page.PageId, LangId = page.LangId, CategoryId = int.Parse(HttpContext.Request.Form["Category"]) };

                    //Or Use
                    //PageCategory pg_cat = new PageCategory();
                    //pg_cat.CategoryId = int.Parse(HttpContext.Request.Form["Category"]);
                    //pg_cat.LangId = page.LangId;
                    //pg_cat.PageId = page.PageId;
                    page.PageCategories.Add(pg_cat);
                }

                _context.Add(page);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TemplateId"] = new SelectList(_context.HtmlTemplates, "Id", "Id", page.TemplateId);
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Id", page.LangId);
            ViewData["Parent"] = new SelectList(_context.Pages, "PageId", "PageId", page.Parent);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", page.UserId);
            return View(page);
        }

        // GET: Control/Pages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            List<PageCategory> pageCats = _context.PagesCategories.Where(i => i.PageId == id)
                .Include(i => i.Category).Where(i => i.PageId == id).ToList();


            ViewData["PageCats"] = pageCats;
            ViewData["Cats"] = _context.Categories.Where(a => a.Deleted == 0 && a.TypeId == 1).ToList();
            ViewData["TemplateId"] = _context.HtmlTemplates.Where(a => a.Deleted == 0 && a.Type == 1).ToList();
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", page.LangId);
            ViewData["Parent"] = _context.Pages.Where(a => a.Deleted == false && (a.Parent == 0 || a.Parent == null) && a.PageId != id).ToList();
            return View(page);
        }

        // POST: Control/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,TranslateId,Title,PageDate,AddDate,LangId,Body,Slug,Url,RedirectUrl,ShowThumb,MetaDescription,MetaKeywords,TemplateId,Priority,Publish,Active,AsMenu,ShowAsMain,Parent,ShowInSearchPage,ShowInSiteMap,ShowDate,AllowComment,ShowAsRelated,Summary,ValidDate,SubTitle,Gallery,ShowRelated,Sticky,Deleted,Archive,Views,Video,Audio,UserId,EditedBy,LastEdit")] Page page)
        {
            if (id != page.PageId)
            {                
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                Page updatePage = await _context.Pages.FindAsync(id);
                try
                {
                    
                    if (updatePage != null)
                    {
                        updatePage.Title = page.Title;
                        updatePage.PageDate = page.PageDate;
                        updatePage.LangId = page.LangId;
                        updatePage.Body = page.Body;
                        updatePage.Slug = page.Slug;
                        updatePage.Url = page.Url;
                        updatePage.RedirectUrl = page.RedirectUrl;
                        updatePage.ShowThumb = page.ShowThumb;
                        updatePage.MetaDescription = page.MetaDescription;
                        updatePage.MetaKeywords = page.MetaKeywords;
                        updatePage.TemplateId = page.TemplateId;
                        updatePage.Priority = page.Priority;
                        updatePage.AsMenu = page.AsMenu;
                        updatePage.ShowAsMain = page.ShowAsMain;
                        updatePage.Parent = page.Parent;
                        updatePage.ShowInSearchPage = page.ShowInSearchPage;
                        updatePage.ShowInSiteMap = page.ShowInSiteMap;
                        updatePage.ShowDate = page.ShowDate;
                        updatePage.AllowComment = page.AllowComment;
                        updatePage.ShowAsRelated = page.ShowAsRelated;
                        updatePage.Summary = page.Summary;
                        updatePage.ValidDate = page.ValidDate;
                        updatePage.SubTitle = page.SubTitle;
                        updatePage.ShowRelated = page.ShowRelated;
                        updatePage.Sticky = page.Sticky;
                        updatePage.LastEdit = DateTime.Now;
                        if (HttpContext.Session.GetString("id") != "")
                        {
                            updatePage.EditedBy = int.Parse(HttpContext.Session.GetString("id") ?? "1");
                        }
                    }
                    else
                    {
                        TempData["error"] = "Page not found...";
                    }
                    
                   

                    if (HttpContext.Request.Form["Category"] != "")
                    {
                        Boolean exist = false;
                        var pageCat = _context.PagesCategories.Where(a => a.PageId == id);
                        foreach(PageCategory pcat in pageCat)
                        {
                            
                            if(pcat.CategoryId.ToString() == HttpContext.Request.Form["Category"])
                            {
                                exist = true;
                            }
                        }
                        if (!exist)//Category already exists
                        {
                            //Delete other cats                            
                            updatePage.PageCategories = new List<PageCategory>();
                            var pg_cat = new PageCategory { PageId = updatePage.PageId, LangId = updatePage.LangId, CategoryId = int.Parse(HttpContext.Request.Form["Category"]) };
                            page.PageCategories.Add(pg_cat);
                        }
                    }
                    if (HttpContext.Request.Form.Files.Count > 0)
                    {
                        var ImageUrl = ImagesUplaod.UploadSingleImage(HttpContext, "files/image/PageImages/", _environment.WebRootPath, "Thumb");
                        updatePage.Thumb = ImageUrl.Item1;
                    }
                    if (HttpContext.Request.Form.Files.Count > 0)
                    {
                        var ImageUrl = ImagesUplaod.UploadSingleImage(HttpContext, "files/image/PageImages/", _environment.WebRootPath, "Thumb2");
                        updatePage.Thumb2 = ImageUrl.Item1;
                    }
                    TempData["success"] = "Page updated successfully...";
                    _context.Update(updatePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(updatePage.PageId))
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
            //ViewData["TemplateId"] = new SelectList(_context.HtmlTemplates, "Id", "Id", page.TemplateId);
            //ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Id", page.LangId);
            //ViewData["Parent"] = new SelectList(_context.Pages, "PageId", "PageId", page.Parent);
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", page.UserId);
            List<PageCategory> pageCats = _context.PagesCategories.Where(i => i.PageId == id)
                .Include(i => i.Category).Where(i => i.PageId == id).ToList();
            ViewData["PageCats"] = pageCats;
            ViewData["Cats"] = _context.Categories.Where(a => a.Deleted == 0 && a.TypeId == 1).ToList();
            ViewData["TemplateId"] = _context.HtmlTemplates.Where(a => a.Deleted == 0 && a.Type == 1).ToList();
            ViewData["LangId"] = new SelectList(_context.Languages, "Id", "Name", page.LangId);
            ViewData["Parent"] = _context.Pages.Where(a => a.Deleted == false && (a.Parent == 0 || a.Parent == null)).ToList();

            return View(page);
        }

        // GET: Control/Pages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages
                .Include(p => p.HtmlTemplate)
                .Include(p => p.Language)
                .Include(p => p.PageRef)
                .Include(p => p.UserAdd)
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Control/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pages == null)
            {
                return Problem("Entity set 'DataContext.Pages'  is null.");
            }
            var page = await _context.Pages.FindAsync(id);
            if (page != null)
            {
                page.Deleted = true;
                _context.Update(page);
                await _context.SaveChangesAsync();

                TempData["success"] = "Page removed successfully...";
                //_context.Pages.Remove(page);
            }
            else
            {
                TempData["error"] = "Cannot remove the page...";
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
          return (_context.Pages?.Any(e => e.PageId == id)).GetValueOrDefault();
        }
    }
}
