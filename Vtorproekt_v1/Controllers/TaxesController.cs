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
    public class TaxesController : Controller
    {
        private readonly VtorproektContext _db;

        public TaxesController(VtorproektContext context)
        {
            _db = context;
        }

        // GET: Taxes
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.SortOrder = sortOrder;
            IQueryable<Tax> SortOrder = _db.Taxes
                .Include(t => t.WorkType);
                //.Include(t => t.Material);


            switch (sortOrder)
            {
                case "Date_desc": SortOrder = SortOrder.OrderByDescending(tax => tax.DateTax); break;
                case "Date_asc": SortOrder = SortOrder.OrderBy(tax => tax.DateTax); break;
                case "WorkType_desc": SortOrder = SortOrder.OrderByDescending(tax => tax.WorkType.WorkTypeName); break;
                case "WorkType_asc": SortOrder = SortOrder.OrderBy(tax => tax.WorkType.WorkTypeName); break;
                default: break;
            }

            return View(await SortOrder.AsNoTracking().ToListAsync());

        }

        // GET: Taxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Taxes == null)
            {
                return NotFound();
            }

            var tax = await _db.Taxes
                .Include(tax => tax.WorkType)
                .FirstOrDefaultAsync(m => m.TaxId == id);
            if (tax == null)
            {
                return NotFound();
            }

            return View(tax);
        }

        // GET: Taxes/Create
        public IActionResult Create()
        {
            ViewBag.WorkTypes = new SelectList(_db.WorkTypes, "WorkTypeId", "WorkTypeName");

            return View();
        }

        // POST: Taxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxId,WorkTypeId,DateTax,TaxValue,Limit1,Limit2,Limit3,Multi1,Multi2,Multi3")] Tax tax)
        {
            if (ModelState.IsValid)
            {
                _db.Add(tax);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tax);
        }

        // GET: Taxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.WorkTypes = new SelectList(_db.WorkTypes, "WorkTypeId", "WorkTypeName");
            if (id == null || _db.Taxes == null)
            {
                return NotFound();
            }

            var tax = await _db.Taxes
                .Include(tax => tax.WorkType)
                .FirstOrDefaultAsync(model => model.TaxId == id);
            if (tax == null)
            {
                return NotFound();
            }
            ViewBag.TaxDateValue = tax.DateTax;
            return View(tax);
        }

        // POST: Taxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxId,WorkTypeId, DateTax,TaxValue,Limit1,Limit2,Limit3,Multi1,Multi2,Multi3")] Tax tax)
        {
            if (id != tax.TaxId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(tax);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxExists(tax.TaxId))
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
            return View(tax);
        }

        // GET: Taxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Taxes == null)
            {
                return NotFound();
            }

            var tax = await _db.Taxes
                .FirstOrDefaultAsync(m => m.TaxId == id);
            if (tax == null)
            {
                return NotFound();
            }

            return View(tax);
        }

        // POST: Taxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Taxes == null)
            {
                return Problem("Entity set 'VtorproektContext.Taxes'  is null.");
            }
            var tax = await _db.Taxes.FindAsync(id);
            if (tax != null)
            {
                _db.Taxes.Remove(tax);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxExists(int id)
        {
            return (_db.Taxes?.Any(e => e.TaxId == id)).GetValueOrDefault();
        }
    }
}
