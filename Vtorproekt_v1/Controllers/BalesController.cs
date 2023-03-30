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
    public class BalesController : Controller
    {
        private readonly VtorproektContext _context;

        public BalesController(VtorproektContext context)
        {
            _context = context;
        }

        // GET: Bales
        public async Task<IActionResult> Index()
        {
            var vtorproektContext = _context.Bales.Include(b => b.Employee).Include(b => b.Material);
            return View(await vtorproektContext.ToListAsync());
        }

        // GET: Bales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bales == null)
            {
                return NotFound();
            }

            var bale = await _context.Bales
                .Include(b => b.Employee)
                .Include(b => b.Material)
                .FirstOrDefaultAsync(m => m.BaleId == id);
            if (bale == null)
            {
                return NotFound();
            }

            return View(bale);
        }

        // GET: Bales/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "MaterialId");
            return View();
        }

        // POST: Bales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaleId,EmployeeId,MaterialId")] Bale bale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", bale.EmployeeId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "MaterialId", bale.MaterialId);
            return View(bale);
        }

        // GET: Bales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bales == null)
            {
                return NotFound();
            }

            var bale = await _context.Bales.FindAsync(id);
            if (bale == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", bale.EmployeeId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "MaterialId", bale.MaterialId);
            return View(bale);
        }

        // POST: Bales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaleId,EmployeeId,MaterialId")] Bale bale)
        {
            if (id != bale.BaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaleExists(bale.BaleId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", bale.EmployeeId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "MaterialId", bale.MaterialId);
            return View(bale);
        }

        // GET: Bales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bales == null)
            {
                return NotFound();
            }

            var bale = await _context.Bales
                .Include(b => b.Employee)
                .Include(b => b.Material)
                .FirstOrDefaultAsync(m => m.BaleId == id);
            if (bale == null)
            {
                return NotFound();
            }

            return View(bale);
        }

        // POST: Bales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bales == null)
            {
                return Problem("Entity set 'VtorproektContext.Bales'  is null.");
            }
            var bale = await _context.Bales.FindAsync(id);
            if (bale != null)
            {
                _context.Bales.Remove(bale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaleExists(int id)
        {
          return (_context.Bales?.Any(e => e.BaleId == id)).GetValueOrDefault();
        }
    }
}
