using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Model;

namespace Final.Controllers
{
    public class InterpolFbisController : Controller
    {
        private readonly FinalContext _context;

        public InterpolFbisController(FinalContext context)
        {
            _context = context;
        }

        // GET: InterpolFbis
        public async Task<IActionResult> Index()
        {
              return _context.InterpolFbi != null ? 
                          View(await _context.InterpolFbi.ToListAsync()) :
                          Problem("Entity set 'FinalContext.InterpolFbi'  is null.");
        }

        // GET: InterpolFbis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InterpolFbi == null)
            {
                return NotFound();
            }

            var interpolFbi = await _context.InterpolFbi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interpolFbi == null)
            {
                return NotFound();
            }

            return View(interpolFbi);
        }

        // GET: InterpolFbis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterpolFbis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ForeName,Languages,Sex,Description,Nationality")] InterpolFbi interpolFbi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interpolFbi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interpolFbi);
        }

        // GET: InterpolFbis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InterpolFbi == null)
            {
                return NotFound();
            }

            var interpolFbi = await _context.InterpolFbi.FindAsync(id);
            if (interpolFbi == null)
            {
                return NotFound();
            }
            return View(interpolFbi);
        }

        // POST: InterpolFbis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ForeName,Languages,Sex,Description,Nationality")] InterpolFbi interpolFbi)
        {
            if (id != interpolFbi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interpolFbi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterpolFbiExists(interpolFbi.Id))
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
            return View(interpolFbi);
        }

        // GET: InterpolFbis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InterpolFbi == null)
            {
                return NotFound();
            }

            var interpolFbi = await _context.InterpolFbi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interpolFbi == null)
            {
                return NotFound();
            }

            return View(interpolFbi);
        }

        // POST: InterpolFbis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InterpolFbi == null)
            {
                return Problem("Entity set 'FinalContext.InterpolFbi'  is null.");
            }
            var interpolFbi = await _context.InterpolFbi.FindAsync(id);
            if (interpolFbi != null)
            {
                _context.InterpolFbi.Remove(interpolFbi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterpolFbiExists(int id)
        {
          return (_context.InterpolFbi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
