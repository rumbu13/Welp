using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Welp.Web.Data;
using Welp.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Welp.Web.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class WelpServiceCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServerContext _serverContext;

        public WelpServiceCategoriesController(ApplicationDbContext context, ServerContext serverContext)
        {
            _context = context;
            _serverContext = serverContext;   
        }

        // GET: WelpServiceCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: WelpServiceCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welpServiceCategory = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            if (welpServiceCategory == null)
            {
                return NotFound();
            }

            return View(welpServiceCategory);
        }

        // GET: WelpServiceCategories/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View(new WelpServiceCategory());
        }

        // POST: WelpServiceCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,LargeIcon,MediumIcon,SmallIcon,Text")] WelpServiceCategory welpServiceCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(welpServiceCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(welpServiceCategory);
        }

        // GET: WelpServiceCategories/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welpServiceCategory = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            if (welpServiceCategory == null)
            {
                return NotFound();
            }
            return View(welpServiceCategory);
        }

        // POST: WelpServiceCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LargeIcon,MediumIcon,SmallIcon,Text")] WelpServiceCategory welpServiceCategory)
        {
            if (id != welpServiceCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(welpServiceCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WelpServiceCategoryExists(welpServiceCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(welpServiceCategory);
        }

        // GET: WelpServiceCategories/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welpServiceCategory = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            if (welpServiceCategory == null)
            {
                return NotFound();
            }

            ViewBag.HasServices = await _context.Services.AnyAsync(s => s.WelpServiceCategoryId == id);

            return View(welpServiceCategory);
        }

        // POST: WelpServiceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var welpServiceCategory = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            _context.Categories.Remove(welpServiceCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WelpServiceCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public ActionResult LookupFiles(string query)
        {
            var files = _serverContext.GetFilesFromServerPath("images", "*.*").
                Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || 
                           f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) || 
                           f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || 
                           f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) || 
                           f.EndsWith(".svg", StringComparison.OrdinalIgnoreCase));

            return String.IsNullOrWhiteSpace(query) ? Json(files) : Json(files.Where(f => f.Contains(query)));
        }
    }
}
