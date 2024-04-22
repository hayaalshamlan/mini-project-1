using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BankController : Controller
    {


        private static List<BankBranch> bankBranches = new List<BankBranch>
        {
                new BankBranch { Id = 1, Name = "kfh", LocationURL = "jjhshshs", LocationName = "kwt", BranchManager = "sara", EmployeeCount = 23 },
                new BankBranch {Id = 2, Name = "nbk", LocationURL = "ggahah", LocationName = "sura", BranchManager = "haya", EmployeeCount = 45 }
        };
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
        public IActionResult Add(NewBranchForm model)
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
                var bankBranch = bankBranches.FirstOrDefault(b => b.Id == id);
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
                if(branch == null)
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
    }
}


