using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iceOne_Cloud.Data;
using iceOne_Cloud.Models;

namespace iceOne_Cloud.Controllers
{
    public class bnbDBsController : Controller
    {
        private readonly iceOne_CloudContext _context;

        public bnbDBsController(iceOne_CloudContext context)
        {
            _context = context;
        }


        // GET: bnbDBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.bnbDB.ToListAsync());
        }

        // GET: bnbDBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bnbDB = await _context.bnbDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bnbDB == null)
            {
                return NotFound();
            }

            return View(bnbDB);
        }

        // GET: bnbDBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: bnbDBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Address,contactEmail")] bnbDB bnbDB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bnbDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bnbDB);
        }

        // GET: bnbDBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bnbDB = await _context.bnbDB.FindAsync(id);
            if (bnbDB == null)
            {
                return NotFound();
            }
            return View(bnbDB);
        }

        // POST: bnbDBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Address,contactEmail")] bnbDB bnbDB)
        {
            if (id != bnbDB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bnbDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bnbDBExists(bnbDB.Id))
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
            return View(bnbDB);
        }

        // GET: bnbDBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bnbDB = await _context.bnbDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bnbDB == null)
            {
                return NotFound();
            }

            return View(bnbDB);
        }

    
        // POST: bnbDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bnbDB = await _context.bnbDB.FindAsync(id);
            if (bnbDB != null)
            {
                _context.bnbDB.Remove(bnbDB);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bnbDBExists(int id)
        {
            return _context.bnbDB.Any(e => e.Id == id);
        }
    }
}
