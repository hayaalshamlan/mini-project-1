using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BankController : Controller
    {


       
        public IActionResult Index()
        {
            var context = new BankContext();
            return View(context.BankBranches.ToList());

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewBranchForm model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new BankContext())
                {
                    var bank = new BankBranch();
                    var name = model.Name;
                    var locationURl = model.LocationURL;
                    var locationName = model.LocationName;
                    var BranchManager = model.BranchManager;
                    var employeeCount = model.EmployeeCout;
                    bank.Name = name; ;
                    bank.LocationURL = locationURl;
                    bank.LocationName = locationName;
                    bank.BranchManager = BranchManager;
                    bank.EmployeeCount = employeeCount;
                    context.BankBranches.Add(bank);
                    context.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            using (var context = new BankContext())
            {
                var bankBranch = context.BankBranches.Include(r=> r.Employees).FirstOrDefault(b => b.Id == id);
                if (bankBranch == null)
                {
                    return NotFound();
                }
                return View(bankBranch);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var context = new BankContext())
            {
                var branch = context.BankBranches.Find(id);
                if (branch == null)
                {
                    return RedirectToAction("Index");
                }
                var form = new NewBranchForm();
                form.LocationURL = branch.LocationURL;
                form.LocationName = branch.LocationName;
                form.BranchManager = branch.BranchManager;
                form.Name = branch.Name;
                form.EmployeeCout = branch.EmployeeCount;
                return View(form);

            }

        }
        [HttpPost]
        public IActionResult Edit(int id, NewBranchForm newBranchForm)
        {
            using (var context = new BankContext())
            {
                var branch = context.BankBranches.Find(id);
                if (branch == null)
                {
                    branch.Name = newBranchForm.Name;
                    branch.LocationURL = newBranchForm.LocationURL;
                    branch.LocationName = newBranchForm.LocationName;
                    branch.BranchManager = newBranchForm.BranchManager;
                    branch.EmployeeCount = newBranchForm.EmployeeCout;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddEmployee(int Id)
        {
            ViewBag.BranchId = Id;
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(int Id, AddEmployeeForm form)
        {
            if (ModelState.IsValid)
            {
                var database = new BankContext();
                var bankBranch = database.BankBranches.Find(Id);
                var newEmployee = new Employee();

                //newEmployee.Id = form.Id;
                newEmployee.Name = form.Name;
                newEmployee.CivilId = form.CivilId;
                newEmployee.Position = form.Position;
                //newEmployee.BankBranchId = form.BankBranchId;

                // database.Employees.Add(newEmployee);
                bankBranch.Employees.Add(newEmployee);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(form);
        }
    }
}


