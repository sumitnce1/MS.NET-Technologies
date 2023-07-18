using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations;

namespace AdmissionApps
{
    public class Users
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
