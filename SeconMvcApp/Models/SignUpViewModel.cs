using System.ComponentModel.DataAnnotations;
using Xunit;

namespace SeconMvcApp.Models
{
    public class SignUpViewModel
    {
        [Display(Name = "Enter User ID")]
        [Required(ErrorMessage = "Enter email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RetypePassword { get; set; }

        [Display(Name = "Enter Mobile Number")]
        [Required(ErrorMessage = "Enter Mobile")]
        [MaxLength(10, ErrorMessage = "Mobile number should be maximum 10 characters")]
        public string MobileNo { get; set; }

        public string Name { get; set; }

        public string UserType { get; set; }
    }
    public class UserDBModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
    }
}