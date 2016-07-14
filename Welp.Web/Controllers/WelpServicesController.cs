using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Welp.Web.Data;
using Welp.Web.Models;

namespace Welp.Web
{
    public class WelpServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WelpServicesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WelpServices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Services.Include(w => w.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WelpServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welpService = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);
            if (welpService == null)
            {
                return NotFound();
            }

            return View(welpService);
        }

        // GET: WelpServices/Create
        public IActionResult Create()
        {
            ViewData["WelpServiceCategoryId"] = new SelectList(_context.Categories, "Id", "Text");
            return View();
        }

        // POST: WelpServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CanBePerformedOnline,Description,IncludedPrestations,LargeIcon,MediumIcon,OnlineDiscount,Price,SmallIcon,StandardDuration,Text,Title,WelpServiceCategoryId")] WelpService welpService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(welpService);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["WelpServiceCategoryId"] = new SelectList(_context.Categories, "Id", "Text", welpService.WelpServiceCategoryId);
            return View(welpService);
        }

        // GET: WelpServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welpService = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);
            if (welpService == null)
            {
                return NotFound();
            }
            ViewData["WelpServiceCategoryId"] = new SelectList(_context.Categories, "Id", "Text", welpService.WelpServiceCategoryId);
            return View(welpService);
        }

        // POST: WelpServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CanBePerformedOnline,Description,IncludedPrestations,LargeIcon,MediumIcon,OnlineDiscount,Price,SmallIcon,StandardDuration,Text,Title,WelpServiceCategoryId")] WelpService welpService)
        {
            if (id != welpService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(welpService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WelpServiceExists(welpService.Id))
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
            ViewData["WelpServiceCategoryId"] = new SelectList(_context.Categories, "Id", "Text", welpService.WelpServiceCategoryId);
            return View(welpService);
        }

        // GET: WelpServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welpService = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);
            if (welpService == null)
            {
                return NotFound();
            }

            return View(welpService);
        }

        // POST: WelpServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var welpService = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);
            _context.Services.Remove(welpService);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WelpServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
