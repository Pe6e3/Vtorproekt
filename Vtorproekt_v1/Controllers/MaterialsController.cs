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
    public class MaterialsController : Controller
    {
        private readonly VtorproektContext _db;

        public MaterialsController(VtorproektContext db)
        {
            _db = db;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
              return _db.Materials != null ? 
                          View(await _db.Materials.ToListAsync()) :
                          Problem("Entity set 'VtorproektContext.Materials'  is null.");
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Materials == null)
            {
                return NotFound();
            }

            var material = await _db.Materials
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialId,MaterialNameStart,MaterialNameFinish")] Material material)
        {
            if (ModelState.IsValid)
            {
                _db.Add(material);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Materials == null)
            {
                return NotFound();
            }

            var material = await _db.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialId,MaterialNameStart,MaterialNameFinish")] Material material)
        {
            if (id != material.MaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(material);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.MaterialId))
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
            return View(material);
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Materials == null)
            {
                return NotFound();
            }

            var material = await _db.Materials
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Materials == null)
            {
                return Problem("Entity set 'VtorproektContext.Materials'  is null.");
            }
            var material = await _db.Materials.FindAsync(id);
            if (material != null)
            {
                _db.Materials.Remove(material);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
          return (_db.Materials?.Any(e => e.MaterialId == id)).GetValueOrDefault();
        }
    }
}
