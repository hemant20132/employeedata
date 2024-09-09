using employeedata.DAL;
using employeedata.Models.DBEntities;
using employeedata.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace employeedata.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    var employeeViewModel = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DateofBirth = employee.DateofBirth,
                        Email = employee.Email,
                        Salary = employee.Salary
                    };
                    employeeList.Add(employeeViewModel);
                }
                return View(employeeList);
            }
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeData)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var employee = new Employee()
                    {
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        DateofBirth = employeeData.DateofBirth,
                        Email = employeeData.Email,
                        Salary = employeeData.Salary
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successmessage"] = "Employee Created Successfully.";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["errorMessage"] = "Model Data is not valid.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();

            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(x=>x.Id==Id);
            if (employee != null)
            {
                var employeeView = new EmployeeViewModel()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateofBirth = employee.DateofBirth,
                    Email = employee.Email,
                    Salary = employee.Salary
                };
                return View("Edit");
            }
       
            {
                TempData["errorMessage"] = "Employee Details not available with Id:";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateofBirth = model.DateofBirth,
                        Email = model.Email,
                        Salary = model.Salary
                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Employee Details updated Successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Model data is Invalid";
                    RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }


    }
}