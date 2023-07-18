using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SeconMvcApp.Models;
using System.Data;

namespace SeconMvcApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            /*ProDBContext proDBContext = new ProDBContext();
            List<SignUpViewModel> signUpViewModels = new List<SignUpViewModel>();
            var userlist = proDBContext.Users.ToList();
            *//*string myConnectionString = "server=localhost;port=3306;database=dotnet;uid=root;pwd=Admin@123;";
            MySqlConnection sqlConnection = new MySqlConnection(myConnectionString);
            MySqlCommand sql = new MySqlCommand("SELECT * FROM users", sqlConnection);
            sqlConnection.Open();
            MySqlDataReader sqlDataReader = sql.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqlDataReader);

            foreach (DataRow dr in dt.Rows)
            {
                signUpViewModels.Add(new SignUpViewModel
                {
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    MobileNo = dr["MobileNo"].ToString(),
                    Password = dr["Password"].ToString(),
                    UserType = dr["UserType"].ToString(),
                });
            }*/


            ProDBContext proDBContext = new ProDBContext();
            List<UserDBModel> signUpViewModels = new List<UserDBModel>();
            var userlist = proDBContext.Users.ToList();
            return View(userlist);
        }

    }
}
