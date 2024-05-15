using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using site.Data;
using site.Data.Models;

namespace site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasageController : Controller
    {
        private readonly Context _context;

        public MasageController(Context context)
        {
            _context = context;
        }

        // GET: Masage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Message.ToListAsync());
        }

        // GET: Masage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msg = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (msg == null)
            {
                return NotFound();
            }

            return View(msg);
        }

        // GET: Masage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Masage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,message,date,title,sender_id")] msg msg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(msg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(msg);
        }

        // GET: Masage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msg = await _context.Message.FindAsync(id);
            if (msg == null)
            {
                return NotFound();
            }
            return View(msg);
        }

        // POST: Masage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,message,date,title,sender_id")] msg msg)
        {
            if (id != msg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(msg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!msgExists(msg.Id))
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
            return View(msg);
        }

        // GET: Masage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msg = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (msg == null)
            {
                return NotFound();
            }

            return View(msg);
        }

        // POST: Masage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var msg = await _context.Message.FindAsync(id);
            if (msg != null)
            {
                _context.Message.Remove(msg);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool msgExists(int id)
        {
            return _context.Message.Any(e => e.Id == id);
        }
    }
}
