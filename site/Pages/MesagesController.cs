using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using site.Data;
using site.Data.Models;

namespace site.Pages
{
    public class MesagesController : Controller
    {
        private readonly Context _context;

        public MesagesController(Context context)
        {
            _context = context;
        }

        // GET: Mesages
        public async Task<IActionResult> Index()
        {
            return View(await _context.dvoiki.ToListAsync());
        }

        // GET: Mesages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dva = await _context.dvoiki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dva == null)
            {
                return NotFound();
            }

            return View(dva);
        }

        // GET: Mesages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,imya")] dva dva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dva);
        }

        // GET: Mesages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dva = await _context.dvoiki.FindAsync(id);
            if (dva == null)
            {
                return NotFound();
            }
            return View(dva);
        }

        // POST: Mesages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,imya")] dva dva)
        {
            if (id != dva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dvaExists(dva.Id))
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
            return View(dva);
        }

        // GET: Mesages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dva = await _context.dvoiki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dva == null)
            {
                return NotFound();
            }

            return View(dva);
        }

        // POST: Mesages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dva = await _context.dvoiki.FindAsync(id);
            if (dva != null)
            {
                _context.dvoiki.Remove(dva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dvaExists(int id)
        {
            return _context.dvoiki.Any(e => e.Id == id);
        }
    }
}
