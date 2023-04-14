using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VtorP.Data;
using VtorP.Models;

namespace VtorP.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly VtorPContext _db;

        public ProductionsController(VtorPContext context)
        {
            _db = context;
        }

        // GET: Productions
        public async Task<IActionResult> Index()
        {
            var VtorPContext = _db.Productions
                .Include(p => p.Storage)
                .Include(p => p.WorkType)
                .Include(p => p.Tax);
            ViewBag.Bale = _db.Bales.ToList();
            ViewBag.Employee = _db.Employees.ToList();
            ViewBag.Material = _db.Materials.ToList();
            ViewBag.Tax = _db.Taxes.ToList();

            return View(await VtorPContext.ToListAsync());
        }

        // GET: Productions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Productions == null)
            {
                return NotFound();
            }

            var production = await _db.Productions
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
            ViewBag.Storage = _db.Storages.ToList();
            ViewBag.WorkType = _db.WorkTypes.ToList();
            ViewBag.Bale = _db.Bales.ToList();
            ViewBag.Tax = _db.Taxes.ToList();
            ViewBag.Storager = _db.Employees.ToList();
            ViewBag.Material = _db.Materials.ToList();

            ViewBag.BaleEmpty = _db.Bales.Where(bale=>bale.isReady==false).ToList();



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
                Bale bale = _db.Bales.Where(newBale => newBale.BaleId == production.BaleId).FirstOrDefault();
                if (bale != null)
                {
                    bale.isReady = true;
                    _db.Update(bale);
                }


                _db.Add(production);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Storage"] = new SelectList(_db.Storages, "StorageId", "StorageName", production.Storage);
            ViewData["WorkType"] = new SelectList(_db.WorkTypes, "WorkTypeId", "WorkTypeName", production.WorkType);
            return View(production);
        }

        // GET: Productions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Storage = _db.Storages.ToList();
            ViewBag.WorkType = _db.WorkTypes.ToList();
            ViewBag.Bale = _db.Bales.ToList();
            ViewBag.Tax = _db.Taxes.ToList();
            ViewBag.Storager = _db.Employees.ToList();
            ViewBag.Material = _db.Materials.ToList();
            ViewBag.BaleEmpty = _db.Bales.Where(bale => bale.isReady == false).ToList();


            if (id == null || _db.Productions == null)
            {
                return NotFound();
            }

            var production = await _db.Productions.FindAsync(id);
            if (production == null)
            {
                return NotFound();
            }
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
                    _db.Update(production);
                    await _db.SaveChangesAsync();
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
            ViewData["StorageId"] = new SelectList(_db.Storages, "StorageId", "StorageId", production.Storage);
            ViewData["WorkTypeId"] = new SelectList(_db.WorkTypes, "WorkTypeId", "WorkTypeId", production.WorkType);
            return View(production);
        }

        // GET: Productions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Productions == null)
            {
                return NotFound();
            }

            var production = await _db.Productions
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
            if (_db.Productions == null)
            {
                return Problem("Entity set 'VtorPContext.Productions'  is null.");
            }
            var production = await _db.Productions.FindAsync(id);
            if (production != null)
            {
                _db.Productions.Remove(production);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionExists(int id)
        {
            return (_db.Productions?.Any(e => e.ProductionId == id)).GetValueOrDefault();
        }
    }
}
