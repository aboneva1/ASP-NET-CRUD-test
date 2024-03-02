using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManagener.Data;
using CarManagener.Models;

namespace CarManagener.Controllers
{
    public class LipGlossesController : Controller
    {
        private readonly CarManagenerContext _context;

        public LipGlossesController(CarManagenerContext context)
        {
            _context = context;
        }

        // GET: LipGlosses
        public async Task<IActionResult> Index()
        {
              return _context.LipGloss != null ? 
                          View(await _context.LipGloss.ToListAsync()) :
                          Problem("Entity set 'CarManagenerContext.LipGloss'  is null.");
        }

        // GET: LipGlosses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LipGloss == null)
            {
                return NotFound();
            }

            var lipGloss = await _context.LipGloss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lipGloss == null)
            {
                return NotFound();
            }

            return View(lipGloss);
        }

        // GET: LipGlosses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LipGlosses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Model,Expiraion,Color")] LipGloss lipGloss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lipGloss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lipGloss);
        }

        // GET: LipGlosses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LipGloss == null)
            {
                return NotFound();
            }

            var lipGloss = await _context.LipGloss.FindAsync(id);
            if (lipGloss == null)
            {
                return NotFound();
            }
            return View(lipGloss);
        }

        // POST: LipGlosses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Model,Expiraion,Color")] LipGloss lipGloss)
        {
            if (id != lipGloss.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lipGloss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LipGlossExists(lipGloss.Id))
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
            return View(lipGloss);
        }

        // GET: LipGlosses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LipGloss == null)
            {
                return NotFound();
            }

            var lipGloss = await _context.LipGloss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lipGloss == null)
            {
                return NotFound();
            }

            return View(lipGloss);
        }

        // POST: LipGlosses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LipGloss == null)
            {
                return Problem("Entity set 'CarManagenerContext.LipGloss'  is null.");
            }
            var lipGloss = await _context.LipGloss.FindAsync(id);
            if (lipGloss != null)
            {
                _context.LipGloss.Remove(lipGloss);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LipGlossExists(int id)
        {
          return (_context.LipGloss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
