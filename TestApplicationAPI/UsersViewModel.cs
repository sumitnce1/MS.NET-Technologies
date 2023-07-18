using System.ComponentModel.DataAnnotations;

namespace TestApplicationAPI
{
    public class UsersViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MobileNo { get; set; }
        public string? Password { get; set; }
        public string? EmailId { get; set; }
        public string? UserType { get; set; }
        public DateTime? CreationTime { get; set; }

        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public string? CourseName { get; set; }
        public string? AdmissionStatus { get; set; }
    }
}
