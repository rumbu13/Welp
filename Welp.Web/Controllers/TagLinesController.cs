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
using Sakura.AspNetCore;

namespace Welp.Web.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class TagLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TagLinesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TagLines
        
        public async Task<IActionResult> Index(string sortOrder, string searchString, int? page)
        {
            var tagLines = String.IsNullOrWhiteSpace(searchString) ?
                _context.TagLines :
                _context.TagLines.Where(t => t.Text.Contains(searchString));

            if (!String.IsNullOrWhiteSpace(searchString))
                ViewBag.SearchString = searchString;
            else
                ViewBag.SearchString = null;

            if (!String.IsNullOrWhiteSpace(sortOrder))
                ViewBag.SortParam = sortOrder;
            else
                ViewBag.SortParam = null;

            if (String.IsNullOrWhiteSpace(sortOrder))
            {
                ViewBag.TextSortParam = "text_asc";
                ViewBag.ProbSortParam = "prob_asc";
                
            }

            switch (sortOrder)
            {
                case "text_asc":
                case "text":
                    tagLines = tagLines.OrderBy(t => t.Text);
                    ViewBag.TextSortParam = "text_desc";
                    ViewBag.ProbSortParam = "prob_asc";
                    break;
                case "text_desc":
                    tagLines = tagLines.OrderByDescending(t => t.Text);
                    ViewBag.TextSortParam = "text_asc";
                    ViewBag.ProbSortParam = "prob_asc";
                    break;
                case "prob_asc":
                case "prob":
                    tagLines = tagLines.OrderBy(t => t.Probability);
                    ViewBag.ProbSortParam = "prob_desc";
                    ViewBag.TextSortParam = "text_asc";
                    break;
                case "prob_desc":
                    tagLines = tagLines.OrderByDescending(t => t.Probability);
                    ViewBag.ProbSortParam = "prob_asc";
                    ViewBag.TextSortParam = "text_asc";
                    break;
                default:
                    break;
            }


            return View(await tagLines.ToPagedListAsync(20, page ?? 1));
        }


        // GET: TagLines/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TagLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Probability,Text")] TagLine tagLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tagLine);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tagLine);
        }

        // GET: TagLines/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagLine = await _context.TagLines.SingleOrDefaultAsync(m => m.Id == id);
            if (tagLine == null)
            {
                return NotFound();
            }
            return View(tagLine);
        }

        // POST: TagLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Probability,Text")] TagLine tagLine)
        {
            if (id != tagLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tagLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagLineExists(tagLine.Id))
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
            return View(tagLine);
        }

        // GET: TagLines/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagLine = await _context.TagLines.SingleOrDefaultAsync(m => m.Id == id);
            if (tagLine == null)
            {
                return NotFound();
            }

            return View(tagLine);
        }

        // POST: TagLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tagLine = await _context.TagLines.SingleOrDefaultAsync(m => m.Id == id);
            _context.TagLines.Remove(tagLine);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TagLineExists(int id)
        {
            return _context.TagLines.Any(e => e.Id == id);
        }
    }
}
