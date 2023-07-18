using Microsoft.AspNetCore.Mvc;
using SeconMvcApp.Models;

namespace SeconMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(UtilsDB utilsDB)
        {
            List<EmployeeViewModel> userList = utilsDB.GetEmployeeViews();
            return View(userList);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            EmployeeViewModel? employeeViewModel = UtilsDB.GetEmployee(Convert.ToInt32(id));
            return View(employeeViewModel);
        }
        public IActionResult Details(string id)
        {
            EmployeeViewModel? employeeViewModel = UtilsDB.GetEmployee(Convert.ToInt32(id));
            return View(employeeViewModel);
        }
        public IActionResult Delete(string id)
        {
            EmployeeViewModel employeeViewModel = UtilsDB.GetEmployee(Convert.ToInt32(id));
            UtilsDB.DeleteEmployee(employeeViewModel);
            return Redirect("/Employee/Index");
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            UtilsDB.UpdateEmployee(employeeViewModel);
            return Redirect("/Employee/Index");
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            UtilsDB.AddEmployee(employeeViewModel);
            return Redirect("/Employee/Index");
            //return View();
        }
    }
}

