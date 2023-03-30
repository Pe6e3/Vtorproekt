using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vtorproekt.Data;
using Vtorproekt.Models;

namespace Vtorproekt.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly VtorproektContext _context;

        public ProductionsController(VtorproektContext context)
        {
            _context = context;
        }

        // GET: Productions
        public async Task<IActionResult> Index()
        {
            var vtorproektContext = _context.Productions.Include(p => p.Storage).Include(p => p.WorkType);
            return View(await vtorproektContext.ToListAsync());
        }

        // GET: Productions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productions == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .Include(p => p.Storage)
                .Include(p => p.WorkType)
                .FirstOrDefaultAsync(m => m.ProductionId == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // GET: Productions/Create
        public IActionResult Create()
        {
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId");
            ViewData["WorkTypeId"] = new SelectList(_context.WorkTypes, "WorkTypeId", "WorkTypeId");
            return View();
        }

        // POST: Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductionId,WorkTypeId,BaleId,Weight,StorageId,ProduceDate,TaxId")] Production production)
        {
            if (ModelState.IsValid)
            {
                _context.Add(production);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId", production.StorageId);
            ViewData["WorkTypeId"] = new SelectList(_context.WorkTypes, "WorkTypeId", "WorkTypeId", production.WorkTypeId);
            return View(production);
        }

        // GET: Productions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productions == null)
            {
                return NotFound();
            }

            var production = await _context.Productions.FindAsync(id);
            if (production == null)
            {
                return NotFound();
            }
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId", production.StorageId);
            ViewData["WorkTypeId"] = new SelectList(_context.WorkTypes, "WorkTypeId", "WorkTypeId", production.WorkTypeId);
            return View(production);
        }

        // POST: Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductionId,WorkTypeId,BaleId,Weight,StorageId,ProduceDate,TaxId")] Production production)
        {
            if (id != production.ProductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(production);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionExists(production.ProductionId))
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
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId", production.StorageId);
            ViewData["WorkTypeId"] = new SelectList(_context.WorkTypes, "WorkTypeId", "WorkTypeId", production.WorkTypeId);
            return View(production);
        }

        // GET: Productions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productions == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .Include(p => p.Storage)
                .Include(p => p.WorkType)
                .FirstOrDefaultAsync(m => m.ProductionId == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productions == null)
            {
                return Problem("Entity set 'VtorproektContext.Productions'  is null.");
            }
            var production = await _context.Productions.FindAsync(id);
            if (production != null)
            {
                _context.Productions.Remove(production);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionExists(int id)
        {
          return (_context.Productions?.Any(e => e.ProductionId == id)).GetValueOrDefault();
        }
    }
}
