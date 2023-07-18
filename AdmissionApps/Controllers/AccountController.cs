using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AdmissionApps.Models;

namespace AdmissionApps.Controllers
{
    public class AccountController : Controller
    {
        [Route("SignUp")]
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
            AdmissionDbContext ob = new AdmissionDbContext();
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var dbuserdetails = ob.Users.FirstOrDefault(x => x.Id == UserId);
            return View(dbuserdetails);
        }
        [HttpPost]
        public IActionResult Profile(Users viewModeldetails)
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var dbuserdetails = ob.Users.FirstOrDefault(x => x.Id == UserId);
            if (dbuserdetails != null)
            {
                dbuserdetails.Name = viewModeldetails.Name;
                dbuserdetails.FatherName = viewModeldetails.FatherName;
                dbuserdetails.CourseName = viewModeldetails.CourseName;
                dbuserdetails.MotherName = viewModeldetails.MotherName;
                dbuserdetails.Address = viewModeldetails.Address;
                dbuserdetails.City = viewModeldetails.City;
                dbuserdetails.Pincode = viewModeldetails.Pincode;
                dbuserdetails.State = viewModeldetails.State;
                dbuserdetails.AdmissionStatus = "FILLED";
                ob.Users.Update(dbuserdetails);
                ob.SaveChanges();
                ViewData["MSG"] = "Profile Updated";
                //ModelState.Clear();
                return View(viewModeldetails);
            }
            else
            {
                ViewData["MSG"] = "Network Error";
                return View(viewModeldetails);

            }
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel viewModel)
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            int UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = ob.Users.FirstOrDefault(x => x.Password == viewModel.OldPassword && x.Id == UserId);
            if (user != null)
            {
                user.Password = viewModel.NewPassword;
                ob.Users.Update(user);
                ob.SaveChanges();
                ViewData["MSG"] = "Password Changed";
                ModelState.Clear();
                return View(null);
            }
            else
            {
                ViewData["MSG"] = "Old Password Not match";
                return View(viewModel);

            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        [Authorize(Roles = "STUDENT")]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            AdmissionDbContext ob = new AdmissionDbContext();
            var user = ob.Users.FirstOrDefault(x => x.EmailId == viewModel.Email && x.Password == viewModel.Password);
            if (user != null)
            {
                var claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.UserType),
                        new Claim("MobileNo", user.MobileNo)
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
        public IActionResult SignUp(Users user)
        {
            AdmissionDbContext ob = new AdmissionDbContext();

            bool IsMobile = ob.Users.Any(x => x.MobileNo == user.MobileNo);
            bool IsEmail = ob.Users.Any(x => x.EmailId == user.EmailId);
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
            user.UserType = "STUDENT";
            ob.Users.Add(user);
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
