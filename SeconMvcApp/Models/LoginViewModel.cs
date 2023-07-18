using Microsoft.AspNetCore.Mvc;

namespace SeconMvcApp.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class EmployeeViewModel
    {
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
    }
    public class ChangePasswordViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RetypePassword { get; set; }
    }
/*    public class SignUpViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RetypePassword { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
    }*/
}