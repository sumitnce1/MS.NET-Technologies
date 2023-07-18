using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SeconMvcApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SeconMvcApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        public bool CheckMobileNo(string mobileNo)
        {
            string myConnectionString = "server=localhost;port=3306;database=dotnet;uid=root;pwd=Admin@123;";
            string sqlquery = $"SELECT COUNT(*) From users Where MobileNo='{mobileNo}'";
            MySqlConnection sqlConnection = new MySqlConnection(myConnectionString);///
            MySqlCommand command = new MySqlCommand(sqlquery, sqlConnection);
            sqlConnection.Open();
            command.CommandType = CommandType.Text;
            int Count = Convert.ToInt32(command.ExecuteScalar());
            sqlConnection.Close();
            if (Count > 0)
                return true;
            else
                return false;
        }
        public bool CheckMEmail(string email)
        {
            string myConnectionString = "server=localhost;port=3306;database=dotnet;uid=root;pwd=Admin@123;";
            string sqlquery = $"SELECT COUNT(*) From users Where Email='{email}'";
            MySqlConnection sqlConnection = new MySqlConnection(myConnectionString);///
            MySqlCommand command = new MySqlCommand(sqlquery, sqlConnection);
            sqlConnection.Open();
            command.CommandType = CommandType.Text;
            int Count = Convert.ToInt32(command.ExecuteScalar());
            sqlConnection.Close();
            if (Count > 0)
                return true;
            else
                return false;
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            string myConnectionString = "server=localhost;port=3306;database=dotnet;uid=root;pwd=Admin@123;";
            string sqlquery = "INSERT INTO users(Email, Password, MobileNo, Name, UserType) VALUES (@Email, @Password, @MobileNo, @Name, @UserType)";
            using (MySqlConnection sqlConnection = new MySqlConnection(myConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlquery, sqlConnection);
                sqlConnection.Open();
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = signUpViewModel.Email;
                command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = signUpViewModel.Password;
                command.Parameters.Add("@MobileNo", MySqlDbType.VarChar).Value = signUpViewModel.MobileNo;
                command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = signUpViewModel.Name;
                command.Parameters.Add("@UserType", MySqlDbType.VarChar).Value = "STUDENT";
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    ViewData["MSG"] = "Account Created";
                    ModelState.Clear();
                    return View(null);
                }
                else
                {
                    ViewData["MSG"] = "Network error";
                    return View(signUpViewModel);
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Email == "Test@gmail.com" && loginViewModel.Password == "Test@123")
            {
                return Redirect("/Account/Dashboard");
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel vw)
        {
            if (vw.NewPassword != vw.RetypePassword)
            {
                ViewData["MSG"] = "New Password does not match.";
                return View(vw);
            }
            else
            {
                ViewData["MSG"] = "Password Changed";
                ModelState.Clear();
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
