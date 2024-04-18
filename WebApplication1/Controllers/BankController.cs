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
           
            return View(bankBranches);
     
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
                var name = model.Name;
                var locationURl = model.LocationURL;
                var locationName = model.LocationName;
                var BranchManager = model.BranchManager;
                var employeeCount = model.EmployeeCout;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            var bankBranch = bankBranches.FirstOrDefault(b => b.Id == id);
            if (bankBranch == null)
            {
                return RedirectToAction("Index");
            }
            return View(bankBranch);
        }
    }
}
