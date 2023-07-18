using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSMayHan2.Context;
using TSMayHan2.Models;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using OfficeOpenXml;

namespace TSMayHan2.Controllers
{
    public class parametersController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public parametersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: parameters
        /*public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.parameters.Include(p => p.standard);
            return View(await applicationDbContext.ToListAsync());
        }*/
        public IActionResult Index(string searchQuery)
        {

            var selectmay = _context.standards.Select(e => e.machine_name).ToList();

            ViewBag.selectmay = selectmay;

            //var selectmay = _context.standards.Select(e => e.machine_name).ToList();
            var properties = new List<string> { "cycle", "string_time", "pk_pwr", "energy", "total_abs", "weld_col", "total_col", "trigger_force", "weld_force", "freq_chg", "set_ampA", "set_ampB", "velocity" };
            ViewBag.properties = properties;
            
            var machineNames = _context.parameters.Select(d => d.standard.machine_name).Distinct().ToList();

            ViewBag.MachineNames = new SelectList(machineNames, "Chọn tên máy");

            var devices = _context.parameters.Include(d => d.standard).ToList();

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != "Chọn tên máy")
            {
                devices = devices.Where(d => d.machine_name == searchQuery).ToList();
            }

            return View(devices);
        }
        // GET: parameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameter = await _context.parameters
                .Include(p => p.standard)
                .FirstOrDefaultAsync(m => m.id_parameter == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }
        public IActionResult ExportToExcel()
        {
            var data = _context.parameters.ToList(); // Lấy dữ liệu từ DbContext

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Thêm tiêu đề cột
                //worksheet.Cells[1, 1].Value = "id";
                worksheet.Cells[1, 1].Value = "machine_name";
                worksheet.Cells[1, 2].Value = "cycle";
                worksheet.Cells[1, 3].Value = "StringTime";
                worksheet.Cells[1, 4].Value = "PkPwr";
                worksheet.Cells[1, 5].Value = "Energy";
                worksheet.Cells[1, 6].Value = "TotalAbs";
                worksheet.Cells[1, 7].Value = "WeldCol";
                worksheet.Cells[1, 8].Value = "TotalCol";
                worksheet.Cells[1, 9].Value = "TriggerForce";
                worksheet.Cells[1, 10].Value = "WeldForce";
                worksheet.Cells[1, 11].Value = "FreqChg";
                worksheet.Cells[1, 12].Value = "SetAmpA";
                worksheet.Cells[1, 13].Value = "SetAmpB";
                worksheet.Cells[1, 14].Value = "Velocity";
                worksheet.Cells[1, 15].Value = "Device_id";
                worksheet.Cells[1, 16].Value = "port_name";
                worksheet.Cells[1, 17].Value = "create_at";
                worksheet.Cells[1, 18].Value = "create_by";
                worksheet.Cells[1, 19].Value = "last_modify_at";
                worksheet.Cells[1, 20].Value = "last_modify_by";


                // ...

                // Thêm dữ liệu từ danh sách vào file Excel
                var row = 2; // Bắt đầu từ hàng thứ 2
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.machine_name;
                    worksheet.Cells[row, 2].Value = item.cycle;
                    worksheet.Cells[row, 3].Value = item.string_time;
                    worksheet.Cells[row, 4].Value = item.pk_pwr;
                    worksheet.Cells[row, 5].Value = item.energy;
                    worksheet.Cells[row, 6].Value = item.total_abs;
                    worksheet.Cells[row, 7].Value = item.weld_col;
                    worksheet.Cells[row, 8].Value = item.total_col;
                    worksheet.Cells[row, 9].Value = item.trigger_force;
                    worksheet.Cells[row, 10].Value = item.weld_force;
                    worksheet.Cells[row, 11].Value = item.freq_chg;
                    worksheet.Cells[row, 12].Value = item.set_ampA;
                    worksheet.Cells[row, 13].Value = item.set_ampB;
                    worksheet.Cells[row, 14].Value = item.velocity;
                    worksheet.Cells[row, 15].Value = item.device_id;
                    worksheet.Cells[row, 16].Value = item.port_name;
                    worksheet.Cells[row, 17].Value = item.create_at;
                    worksheet.Cells[row, 18].Value = item.create_by;
                    worksheet.Cells[row, 19].Value = item.last_modify_at;
                    worksheet.Cells[row, 20].Value = item.last_modify_by;

                    // ...
                    row++;
                }

                // Stream file Excel về client
                MemoryStream stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = "data.xlsx"; // Tên file Excel
                string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                return File(stream, mimeType, excelName);
            }
        }
        public IActionResult Bieudo()
        {
            var selectmay = _context.standards.Select(e => e.machine_name).ToList();

            ViewBag.selectmay = selectmay;
            
            //var selectmay = _context.standards.Select(e => e.machine_name).ToList();
            var properties = new List<string> { "cycle", "string_time", "pk_pwr", "energy", "total_abs", "weld_col", "total_col", "trigger_force", "weld_force", "freq_chg", "set_ampA", "set_ampB", "velocity" };
            ViewBag.properties = properties;
            return View();

        }
        public IActionResult ShowData(string selectedMachine, string selectedProperty)
        {
            var machines = _context.parameters
           .Where(p => p.machine_name == selectedMachine)
           .ToList();

            var propertyValues = machines.Select(m =>
            {
                PropertyInfo propertyInfo = m.GetType().GetProperty(selectedProperty);
                if (propertyInfo != null)
                    return propertyInfo?.GetValue(m) ?? 0;
                else
                    return null;
            }).ToList();
            var numericValues = propertyValues.SelectMany(p => double.TryParse(p.ToString(), out var value) ? new double?[] { value } : new double?[] { }).ToList();
            var min = numericValues.Min();
            var max = numericValues.Max();

            ViewBag.MaxData = max ;
            ViewBag.MinData = min;
            ViewBag.PropertyValues = propertyValues;
            ViewBag.Label = selectedProperty;
            var machine = _context.standards.FirstOrDefault(p => p.machine_name == selectedMachine);
            if (selectedProperty == "cycle")
            {           
                string cycleMin = machine.cycle_min;
                string cycleMax = machine.cycle_max;     
                ViewBag.max = cycleMax;
                ViewBag.min = cycleMin;
            }
            else if(selectedProperty == "string_time")
            {            
                string Min = machine.string_time_min;
                string Max = machine.string_time_max;             
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "pk_pwr")
            {
                string Min = machine.pk_pwr_min;
                string Max = machine.pk_pwr_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "energy")
            {
                string Min = machine.energy_min;
                string Max = machine.energy_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "total_abs")
            {
                string Min = machine.total_abs_min;
                string Max = machine.total_abs_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "weld_col")
            {
                string Min = machine.weld_col_min;
                string Max = machine.weld_col_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "total_col")
            {
                string Min = machine.total_col_min;
                string Max = machine.total_col_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "trigger_force")
            {
                string Min = machine.trigger_force_min;
                string Max = machine.trigger_force_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "weld_force")
            {
                string Min = machine.weld_force_min;
                string Max = machine.weld_force_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "freq_chg")
            {
                string Min = machine.freq_chg_min;
                string Max = machine.freq_chg_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "set_ampA")
            {
                string Min = machine.set_ampA_min;
                string Max = machine.set_ampA_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else if (selectedProperty == "set_ampB")
            {
                string Min = machine.set_ampB_min;
                string Max = machine.set_ampB_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            else
            {
                string Min = machine.velocity_min;
                string Max = machine.velocity_max;
                ViewBag.max = Max;
                ViewBag.min = Min;
            }
            return View();
            
        }
        public IActionResult ShowData1(string selectedMachine, string selectedProperty)
        {
           /* var entities = _context.standards
            .Where(e => e.Property == selectedProperty && e.MachineName == selectedMachine)
            .ToList();*/

            //return View(entities);
            /*var thongso1 = _context.standards.Select(e => e.cycle_min).ToList();
            return Json(thongso1);*/

            var entityType = typeof(parameter);
            var properties = entityType.GetProperties();
            ViewBag.Machine = selectedMachine;
            var matchingProperties = properties.Where(p =>  p.Name == selectedProperty );


            /*var values = _context.standards
                .Where(e => e.machine_name == selectedMachine && selectedProperties.Contains(e.PropertyName))
                .Select(e => new { e.PropertyName, e.PropertyValue })
                .ToList();*/
            var data = new List<object>();
            foreach (var property in matchingProperties)
            {
                
                /*if (selectedProperty == "cycle")
                {
                   var  thongso = _context.standards.Select(e => e.cycle_min).ToList();
                    ViewBag.min = thongso;
                }
                var k1 = properties.Where(p =>  p.Name == selectedMachine);
                var machines = _context.parameters
                    .Where(p => p.property == selectedProperty && p.Name == selectedMachine)
                    .ToList();
                var values = _context.parameters.Select(e => property.GetValue(e)).ToList();

                
                ViewBag.Label = selectedProperty;
                ViewBag.PropertyValues = values;*/
                var propertyValue = property.GetValue(_context.parameters.FirstOrDefault());
                if (propertyValue == selectedMachine)
                {
                    data.Add(propertyValue);
                }
                return Json(data);
            }

                
            //return Json(2);
            return NotFound();


        }
        // GET: parameters/Create
        public IActionResult Create()
        {
            ViewData["machine_name"] = new SelectList(_context.standards, "machine_name", "machine_name");
            return View();
        }

        // POST: parameters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_parameter,machine_name,cycle,string_time,pk_pwr,energy,total_abs,weld_col,total_col,trigger_force,weld_force,freq_chg,set_ampA,set_ampB,velocity,device_id,port_name,create_at,create_by,last_modify_at,last_modify_by")] parameter parameter)
        {
            
                _context.Add(parameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: parameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameter = await _context.parameters.FindAsync(id);
            if (parameter == null)
            {
                return NotFound();
            }
            ViewData["machine_name"] = new SelectList(_context.standards, "machine_name", "machine_name", parameter.machine_name);
            return View(parameter);
        }

        // POST: parameters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_parameter,machine_name,cycle,string_time,pk_pwr,energy,total_abs,weld_col,total_col,trigger_force,weld_force,freq_chg,set_ampA,set_ampB,velocity,device_id,port_name,create_at,create_by,last_modify_at,last_modify_by")] parameter parameter)
        {
            if (id != parameter.id_parameter)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(parameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!parameterExists(parameter.id_parameter))
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

        // GET: parameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameter = await _context.parameters
                .Include(p => p.standard)
                .FirstOrDefaultAsync(m => m.id_parameter == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // POST: parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.parameters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.parameters'  is null.");
            }
            var parameter = await _context.parameters.FindAsync(id);
            if (parameter != null)
            {
                _context.parameters.Remove(parameter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool parameterExists(int id)
        {
            return (_context.parameters?.Any(e => e.id_parameter == id)).GetValueOrDefault();
        }
    }
}
