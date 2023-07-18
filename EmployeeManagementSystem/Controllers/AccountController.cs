using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace EmployeeManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Profile()
        {
            int EmpId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            EmployeeDbContext ob = new EmployeeDbContext();
            var dbempdetails = ob.Employee.FirstOrDefault(x => x.EmpId == EmpId);
            if (dbempdetails != null)
            {
                return View(dbempdetails);
            }
            else
            {
                return View("AccessDenied");
            }
        }

        [HttpPost]
        public IActionResult Profile(Employee viewModeldetails)
        {
            int EmpId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            EmployeeDbContext ob = new EmployeeDbContext();
            var dbempdetails = ob.Employee.FirstOrDefault(x => x.EmpId == EmpId);
            if (dbempdetails != null)
            {
                dbempdetails.Firstname = viewModeldetails.Firstname;
                dbempdetails.Lastname = viewModeldetails.Lastname;
                dbempdetails.Email = viewModeldetails.Email;
                dbempdetails.EmployeeStatus = "FILLED";
                ob.Employee.Update(dbempdetails);
                ob.SaveChanges();
                ViewData["MSG"] = "Profile Updated";
                return RedirectToAction("Profile");
            }
            else
            {
                ViewData["MSG"] = "Oops! Profile Not Updated :(";
                return RedirectToAction("Profile");
            }
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel viewModel)
        {
            EmployeeDbContext ob = new EmployeeDbContext();
            int EmpId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = ob.Employee.FirstOrDefault(x => x.Password == viewModel.OldPassword && x.EmpId == EmpId);
            if (user != null)
            {
                user.Password = viewModel.NewPassword;
                ob.Employee.Update(user);
                ob.SaveChanges();
                ViewData["MSG"] = "Password Changed";
                ModelState.Clear();
                return View(null);
            }
            else
            {
                ViewData["MSG"] = "Opps! Old Password Not match Try Again!!";
                return View(viewModel);

            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        [Authorize(Roles = "EMPLOYEE")]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            EmployeeDbContext ob = new EmployeeDbContext();
            var emp = ob.Employee.FirstOrDefault(x => x.Email == viewModel.Email && x.Password == viewModel.Password);
            if (emp != null)
            {
                var claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier, Convert.ToString(emp.EmpId)),
                        new Claim(ClaimTypes.Email, emp.Email),
                        new Claim(ClaimTypes.Role, emp.UserType)
                };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
                return Redirect("/Account/Dashboard");
            }
            else
            {
                ViewData["MSG"] = "Invalid UserName or Password";
                return View(viewModel);
            }

        }
        [HttpPost]
        public IActionResult SignUp(Employee user)
        {
            EmployeeDbContext ob = new EmployeeDbContext();

            bool IsMobile = ob.Employee.Any(x => x.MobileNo == user.MobileNo);
            bool IsEmail = ob.Employee.Any(x => x.Email == user.Email);
            if (IsMobile)
            {
                ViewData["MSG"] = "MobileNo Already Exist";
                return View(user);
            }
            if (IsEmail)
            {
                ViewData["MSG"] = "EmailID Already Exist";
                return View(user);
            }
            user.UserType = "EMPLOYEE";
            ob.Employee.Add(user);
            int result = ob.SaveChanges();
            if (result > 0)
            {
                ViewData["MSG"] = "Account Created Please Login";
                ModelState.Clear();
                return View(null);
            }
            else
            {
                ViewData["MSG"] = "Opps! Account Not Created !!!";
                return View(user);
            }
        }
    }
}

