using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSMayHan2.Context;
using TSMayHan2.Models;

namespace TSMayHan2.Controllers
{
    public class device_manageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public device_manageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: device_manage
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var applicationDbContext = _context.device_manages.Include(d => d.standard);
                return View(await applicationDbContext.ToListAsync());
            }
            return RedirectToAction("Index", "parameters");
        }

        // GET: device_manage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.device_manages == null)
            {
                return NotFound();
            }

            var device_manage = await _context.device_manages
                .Include(d => d.standard)
                .FirstOrDefaultAsync(m => m.id_device == id);
            if (device_manage == null)
            {
                return NotFound();
            }

            return View(device_manage);
        }

        // GET: device_manage/Create
        public IActionResult Create()
        {
            ViewData["machine_name"] = new SelectList(_context.standards, "machine_name", "machine_name");
            return View();
        }

        // POST: device_manage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_device,machine_name,status")] device_manage device_manage)
        {
            
                _context.Add(device_manage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: device_manage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.device_manages == null)
            {
                return NotFound();
            }

            var device_manage = await _context.device_manages.FindAsync(id);
            if (device_manage == null)
            {
                return NotFound();
            }
            ViewData["machine_name"] = new SelectList(_context.standards, "machine_name", "machine_name", device_manage.machine_name);
            return View(device_manage);
        }

        // POST: device_manage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_device,machine_name,status")] device_manage device_manage)
        {
            if (id != device_manage.id_device)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(device_manage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!device_manageExists(device_manage.id_device))
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

        // GET: device_manage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.device_manages == null)
            {
                return NotFound();
            }

            var device_manage = await _context.device_manages
                .Include(d => d.standard)
                .FirstOrDefaultAsync(m => m.id_device == id);
            if (device_manage == null)
            {
                return NotFound();
            }

            return View(device_manage);
        }

        // POST: device_manage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.device_manages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.device_manages'  is null.");
            }
            var device_manage = await _context.device_manages.FindAsync(id);
            if (device_manage != null)
            {
                _context.device_manages.Remove(device_manage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool device_manageExists(int id)
        {
            return (_context.device_manages?.Any(e => e.id_device == id)).GetValueOrDefault();
        }
    }
}
