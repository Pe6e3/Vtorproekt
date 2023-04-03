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
    public class WorkTypesController : Controller
    {
        private readonly VtorproektContext _db;

        public WorkTypesController(VtorproektContext db)
        {
            _db = db;
        }

        // GET: WorkTypes
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["SortOrder"] = sortOrder;

            var workTypes = from wt in _db.WorkTypes
                            select wt;

            switch (sortOrder)
            {
                case "WorkTypeName_desc":
                    workTypes = workTypes.OrderByDescending(wt => wt.WorkTypeName);
                    break;
                default:
                    workTypes = workTypes.OrderBy(wt => wt.WorkTypeName);
                    break;
            }

            return View(await workTypes.AsNoTracking().ToListAsync());
        }


        // GET: WorkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.WorkTypes == null)
            {
                return NotFound();
            }

            var workType = await _db.WorkTypes
                .FirstOrDefaultAsync(m => m.WorkTypeId == id);
            if (workType == null)
            {
                return NotFound();
            }

            return View(workType);
        }

        // GET: WorkTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkTypeId,WorkTypeName")] WorkType workType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(workType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workType);
        }

        // GET: WorkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.WorkTypes == null)
            {
                return NotFound();
            }

            var workType = await _db.WorkTypes.FindAsync(id);
            if (workType == null)
            {
                return NotFound();
            }
            return View(workType);
        }

        // POST: WorkTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkTypeId,WorkTypeName")] WorkType workType)
        {
            if (id != workType.WorkTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(workType);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkTypeExists(workType.WorkTypeId))
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
            return View(workType);
        }

        // GET: WorkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.WorkTypes == null)
            {
                return NotFound();
            }

            var workType = await _db.WorkTypes
                .FirstOrDefaultAsync(m => m.WorkTypeId == id);
            if (workType == null)
            {
                return NotFound();
            }

            return View(workType);
        }

        // POST: WorkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.WorkTypes == null)
            {
                return Problem("Entity set 'VtorproektContext.WorkTypes'  is null.");
            }
            var workType = await _db.WorkTypes.FindAsync(id);
            if (workType != null)
            {
                _db.WorkTypes.Remove(workType);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkTypeExists(int id)
        {
          return (_db.WorkTypes?.Any(e => e.WorkTypeId == id)).GetValueOrDefault();
        }
    }
}
