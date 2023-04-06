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
    public class StoragesController : Controller
    {
        private readonly VtorproektContext _db;

        public StoragesController(VtorproektContext db)
        {
            _db = db;
        }

        // GET: Storages
        public async Task<IActionResult> Index()
        {
              return _db.Storages != null ? 
                          View(await _db.Storages.ToListAsync()) :
                          Problem("Entity set 'VtorproektContext.Storages'  is null.");
        }

        // GET: Storages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Storages == null)
            {
                return NotFound();
            }

            var storage = await _db.Storages
                .FirstOrDefaultAsync(m => m.StorageId == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // GET: Storages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Storages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StorageId,StorageAdress")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                _db.Add(storage);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storage);
        }

        // GET: Storages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Storages == null)
            {
                return NotFound();
            }

            var storage = await _db.Storages.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }
            return View(storage);
        }

        // POST: Storages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StorageId,StorageAdress")] Storage storage)
        {
            if (id != storage.StorageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(storage);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageExists(storage.StorageId))
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
            return View(storage);
        }

        // GET: Storages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Storages == null)
            {
                return NotFound();
            }

            var storage = await _db.Storages
                .FirstOrDefaultAsync(m => m.StorageId == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // POST: Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Storages == null)
            {
                return Problem("Entity set 'VtorproektContext.Storages'  is null.");
            }
            var storage = await _db.Storages.FindAsync(id);
            if (storage != null)
            {
                _db.Storages.Remove(storage);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageExists(int id)
        {
          return (_db.Storages?.Any(e => e.StorageId == id)).GetValueOrDefault();
        }
    }
}
