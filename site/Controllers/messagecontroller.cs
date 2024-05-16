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
    [Route("api/message")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly Context _context;

        public MessageController(Context context)
        {
            _context = context;
        }

        //// GET: Message
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Message.ToListAsync());
        //}

        //// GET: Message/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var msg = await _context.Message
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (msg == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(msg);
        //}

        //// GET: Message/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Message/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,message,date,title,sender_id")] msg msg)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(msg);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(msg);
        //}

        //// GET: Message/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var msg = await _context.Message.FindAsync(id);
        //    if (msg == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(msg);
        //}

        //// POST: Message/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,message,date,title,sender_id")] msg msg)
        //{
        //    if (id != msg.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(msg);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!msgExists(msg.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(msg);
        //}

        //// GET: Message/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var msg = await _context.Message
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (msg == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(msg);
        //}

        //// POST: Message/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var msg = await _context.Message.FindAsync(id);
        //    if (msg != null)
        //    {
        //        _context.Message.Remove(msg);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private List<msg> _messages = new List<msg>
    {
        new msg { Id = 1, message = "Привет, мир!" },
        new msg { Id = 2, message = "Это сообщение 2" },
        new msg { Id = 3, message = "И это сообщение 3" }
    };



        [HttpGet]
        public IActionResult GetMessages()
        {
            
            var allmsg = _context.Message.ToList();
            return Ok(allmsg); // Возвращает все сообщения в виде JSON
            
        }

        //private bool msgExists(int id)
        //{
        //    return _context.Message.Any(e => e.Id == id);
        //}
    }
}
