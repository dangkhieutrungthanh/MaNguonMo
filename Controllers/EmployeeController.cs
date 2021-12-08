using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnet.Data;
using dotnet.Models;
using dotnet.Models.Process;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dotnet.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly IConfiguration _Configuration;
        private ExcelProcess _excelPro = new ExcelProcess();
        public EmployeeController(MvcMovieContext context, IConfiguration Configuration)
        {
            _context = context;
            _Configuration = Configuration;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            var model = _context.Employee.ToList();
            if (model.Count == 0) ViewBag.id = "NV001";
            else
            {
                var id = model.OrderByDescending(s => s.EmployeeId).FirstOrDefault().EmployeeId;
                ViewBag.id = ProcessString.AutoKey(id);
            }
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,EmployeePhoneNumber,EmployeeAddress")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,EmployeeName,EmployeePhoneNumber,EmployeeAddress")] Employee employee, IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    //tao duong dan /Uploads/Excels de luu file upload len server
                    var fileName = "Ten file muon luu";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                    var fileLocation = new FileInfo(filePath).ToString();

                    if (ModelState.IsValid)
                    {
                        //upload file to server
                        if (file.Length > 0)
                        {
                            _context.Add(employee);
                            await _context.SaveChangesAsync();
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                //_excelPro la doi tuong xu ly file excel ExcelProcess
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                WriteInformaticResult(dt);
                                //ghi du lieu datatable vao database

                            }
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            return View(file);
        }
        private int WriteInformaticResult(DataTable dt)
        {
            try
            {
                var con = _Configuration.GetConnectionString("MvcMovieContext");
                SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
                bulkcopy.DestinationTableName = "Employee";
                bulkcopy.ColumnMappings.Add(0, "EmployeeId");
                bulkcopy.ColumnMappings.Add(1, "EmployeeName");
                bulkcopy.ColumnMappings.Add(2, "EmployeePhoneNumber");
                bulkcopy.ColumnMappings.Add(3, "EmployeeAddress");
            }
            catch
            {
                return 0;
            }
            return dt.Rows.Count;
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
