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
        private readonly VtorproektContext _db;

        public BalesController(VtorproektContext context)
        {
            _db = context;
        }

        // GET: Bales
        public async Task<IActionResult> Index()
        {
            var vtorproektContext = _db.Bales.Include(b => b.Employee).Include(b => b.Material);
            ViewBag.Production = _db.Productions.ToList();
            return View(await vtorproektContext.ToListAsync());
        }

        // GET: Bales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Bales == null)
            {
                return NotFound();
            }

            var bale = await _db.Bales
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
        //public IActionResult Create()
        //{
        //    ViewData["Employee"] = new SelectList(_db.Employees, "EmployeeId", "EmployeeId");
        //    ViewData["Material"] = new SelectList(_db.Materials, "MaterialId", "MaterialId");
        //    return View();
        //}

        public IActionResult Create()
        {
            //ViewBag.Employee = new SelectList(_db.Employees, "EmployeeId", "FullName");
            //ViewBag.Material = new SelectList(_db.Materials, "MaterialId", "Name");
            ViewBag.Employee = _db.Employees.ToList();
            ViewBag.Material = _db.Materials.ToList();
            return View();
        }


        // POST: Bales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaleId,EmployeeId,MaterialId,isReady")] Bale bale)
        {
            if (ModelState.IsValid)
            {
                _db.Add(bale);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_db.Employees, "EmployeeId", "EmployeeName", bale.EmployeeId);
            ViewData["Material"] = new SelectList(_db.Materials, "MaterialId", "MaterialNameStart", bale.MaterialId);
            return View(bale);
        }

        // GET: Bales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Bales == null)
            {
                return NotFound();
            }

            var bale = await _db.Bales.FindAsync(id);
            if (bale == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(_db.Employees, "EmployeeId", "EmployeeName", bale.EmployeeId);
            ViewData["Material"] = new SelectList(_db.Materials, "MaterialId", "MaterialNameStart", bale.MaterialId);
            return View(bale);
        }

        // POST: Bales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaleId,EmployeeId,MaterialId,isReady")] Bale bale)
        {
            if (id != bale.BaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(bale);
                    await _db.SaveChangesAsync();
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
            ViewData["EmployeeId"] = new SelectList(_db.Employees, "EmployeeId", "EmployeeId", bale.EmployeeId);
            ViewData["MaterialId"] = new SelectList(_db.Materials, "MaterialId", "MaterialId", bale.MaterialId);
            return View(bale);
        }

        // GET: Bales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Bales == null)
            {
                return NotFound();
            }

            var bale = await _db.Bales
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
            if (_db.Bales == null)
            {
                return Problem("Entity set 'VtorproektContext.Bales'  is null.");
            }
            var bale = await _db.Bales.FindAsync(id);
            if (bale != null)
            {
                _db.Bales.Remove(bale);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaleExists(int id)
        {
          return (_db.Bales?.Any(e => e.BaleId == id)).GetValueOrDefault();
        }
    }
}
