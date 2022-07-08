using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOE.Models;

namespace MOE.Areas.Control.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Control")]
    public class GroupsController : Controller
    {
        private readonly DataContext _context;

        public GroupsController(DataContext context)
        {
            _context = context;
        }

        // GET: Control/Groups
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Groups.Where(a => a.Deleted == 0).Include(a => a.Language);
           
            return View(await dataContext.ToListAsync());
        }

        // GET: Control/Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(a => a.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Control/Groups/Create
        public IActionResult Create()
        {
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted == 0), "Id", "Name");
            return View();
        }

        // POST: Control/Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArName,LangId,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,Active,Deleted")] Group @group)
        {
            ModelState.Remove("Language");

            if (ModelState.IsValid)
            {
                group.UserId = int.Parse(HttpContext.Session.GetString("id") ?? "1");
                _context.Add(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted == 0), "Id", "Name", @group.LangId);
            return View(@group);
        }

        // GET: Control/Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted == 0), "Id", "Name", @group.LangId);
           
            return View(@group);
        }

        // POST: Control/Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArName,LangId,P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,Active,Deleted")] Group @group)
        {
            ModelState.Remove("Language");
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted == 0), "Id", "Name", @group.LangId);
            return View(@group);
        }

        // GET: Control/Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }
            
            var @group = await _context.Groups
                .Include(a => a.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Control/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groups == null)
            {
                return Problem("Entity set 'DataContext.Groups'  is null.");
            }
            var @group = await _context.Groups.FindAsync(id);
            if (@group != null)
            {
                group.Deleted = 1;
                _context.Groups.Update(group);
                //_context.Groups.Remove(@group);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
          return (_context.Groups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
