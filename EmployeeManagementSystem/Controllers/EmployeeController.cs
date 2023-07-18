using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            EmployeeDbContext ob = new EmployeeDbContext();
            var emplist = ob.Employee.Where(x => x.UserType != "ADMIN").ToList();
            return View(emplist);
        }
        public IActionResult Update(int Id)
        {
            EmployeeDbContext ob = new EmployeeDbContext();
            var dbdetails = ob.Employee.FirstOrDefault(x => x.EmpId == Id);
            return View(dbdetails);
        }
        [HttpPost]
        public IActionResult Update(int Id, Employee viewModeldetails)
        {
            using (var ob = new EmployeeDbContext())
            {
                var dbdetails = ob.Employee.FirstOrDefault(x => x.EmpId == Id);
                if (dbdetails != null)
                {
                    dbdetails.Firstname = viewModeldetails.Firstname;
                    dbdetails.Lastname = viewModeldetails.Lastname;
                    dbdetails.UserType = viewModeldetails.UserType;
                    dbdetails.MobileNo = viewModeldetails.MobileNo;
                    dbdetails.EmployeeStatus = viewModeldetails.EmployeeStatus;
                    ob.Update(dbdetails);
                    ob.SaveChanges();
                    return Redirect("/Employee/Index");
                }
                else
                {
                    return View(dbdetails);
                }
            }
        }
        public IActionResult Details(int Id)
        {
            EmployeeDbContext ob = new EmployeeDbContext();
            var dbdetails = ob.Employee.FirstOrDefault(x => x.EmpId == Id);
            return View(dbdetails);
        }
        public IActionResult Delete(int Id)
        {
            EmployeeDbContext ob = new EmployeeDbContext();
            var dbdetails = ob.Employee.FirstOrDefault(x => x.EmpId == Id);
            ob.Employee.Remove(dbdetails);
            ob.SaveChanges();
            return Redirect("/Employee/Index");
        }
    }
}