using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
        public string? MobileNo { get; set; }
        public string? EmployeeStatus { get; set;}

    }
}
