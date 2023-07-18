using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionApps.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class AdminController : Controller
    {
        [Route("UserList")]
        public IActionResult Index()
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            var userlist = ob.Users.Where(x => x.UserType != "ADMIN").ToList();
            return View(userlist);
        }
        public IActionResult Edit(int Id)
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            var dbuserdetails = ob.Users.FirstOrDefault(x => x.Id == Id);
            return View(dbuserdetails);
        }
        [HttpPost]
        public IActionResult Edit(Users viewModeldetails)
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            var dbuserdetails = ob.Users.FirstOrDefault(x => x.Id == viewModeldetails.Id);
            if (dbuserdetails != null)
            {
                dbuserdetails.Name = viewModeldetails.Name;
                dbuserdetails.CreationTime = viewModeldetails.CreationTime;
                dbuserdetails.FatherName = viewModeldetails.FatherName;
                dbuserdetails.CourseName = viewModeldetails.CourseName;
                dbuserdetails.MotherName = viewModeldetails.MotherName;
                dbuserdetails.Address = viewModeldetails.Address;
                dbuserdetails.State = viewModeldetails.State;
                dbuserdetails.City = viewModeldetails.City;
                dbuserdetails.Pincode = viewModeldetails.Pincode;
                dbuserdetails.AdmissionStatus = viewModeldetails.AdmissionStatus;
                ob.Update(dbuserdetails);
                ob.SaveChanges();
                return Redirect("/UserList");
            }
            else
            {
                return View(dbuserdetails);
            }
        }
        public IActionResult Details(int Id)
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            var dbuserdetails = ob.Users.FirstOrDefault(x => x.Id == Id);
            return View(dbuserdetails);
        }
        public IActionResult Delete(int Id)
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            var dbuserdetails = ob.Users.FirstOrDefault(x => x.Id == Id);
            ob.Users.Remove(dbuserdetails);
            ob.SaveChanges();
            return Redirect("/UserList");
        }
    }
}
