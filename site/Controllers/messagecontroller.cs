using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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



        [HttpGet]
        public IActionResult GetMessages()
        {


            //public int Id { get; set; }
            //public string message { get; set; }

            //[Column(TypeName = "timestamp")]
            //public DateTime date { get; set; }



            //public int sender_id { get; set; } = 1;
            try
            {

                var allmsg = _context.Message.Join(_context.Users, b => b.sender_id, a => a.Id, (table1, table2) => new
                {
                    message = table1.message,
                    date = table1.date,
                    name = table2.Name
                })
                    .ToList();
                return Ok(allmsg); // Возвращает все сообщения в виде JSON
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return NotFound();
            }

        }

        //private bool msgExists(int id)
        //{
        //    return _context.Message.Any(e => e.Id == id);
        //}
    }
}
