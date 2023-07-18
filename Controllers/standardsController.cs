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
    public class standardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public standardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: standards
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return _context.standards != null ?
                        View(await _context.standards.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.standard'  is null.");
            }
            return RedirectToAction("Index", "parameters");
        }

        // GET: standards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.standards == null)
            {
                return NotFound();
            }

            var standard = await _context.standards
                .FirstOrDefaultAsync(m => m.machine_name == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }
        
        // GET: standards/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: standards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("machine_name,cycle_min,cycle_max,string_time_min,string_time_max,pk_pwr_min,pk_pwr_max,energy_min,energy_max,total_abs_min,total_abs_max,weld_col_min,weld_col_max,total_col_min,total_col_max,trigger_force_min,trigger_force_max,weld_force_min,weld_force_max,freq_chg_min,freq_chg_max,set_ampA_min,set_ampA_max,set_ampB_min,set_ampB_max,velocity_min,velocity_max,modify_by,modify_at")] standard standard)
        {
            
                _context.Add(standard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: standards/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.standards == null)
            {
                return NotFound();
            }

            var standard = await _context.standards.FindAsync(id);
            if (standard == null)
            {
                return NotFound();
            }
            return View(standard);
        }

        // POST: standards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("machine_name,cycle_min,cycle_max,string_time_min,string_time_max,pk_pwr_min,pk_pwr_max,energy_min,energy_max,total_abs_min,total_abs_max,weld_col_min,weld_col_max,total_col_min,total_col_max,trigger_force_min,trigger_force_max,weld_force_min,weld_force_max,freq_chg_min,freq_chg_max,set_ampA_min,set_ampA_max,set_ampB_min,set_ampB_max,velocity_min,velocity_max,modify_by,modify_at")] standard standard)
        {
            if (id != standard.machine_name)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(standard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!standardExists(standard.machine_name))
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

        // GET: standards/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.standards == null)
            {
                return NotFound();
            }

            var standard = await _context.standards
                .FirstOrDefaultAsync(m => m.machine_name == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }

        // POST: standards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.standards == null)
            {
                return Problem("Entity set 'ApplicationDbContext.standard'  is null.");
            }
            var standard = await _context.standards.FindAsync(id);
            if (standard != null)
            {
                _context.standards.Remove(standard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool standardExists(string id)
        {
            return (_context.standards?.Any(e => e.machine_name == id)).GetValueOrDefault();
        }
    }
}
