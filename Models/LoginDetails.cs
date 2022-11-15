using System;

namespace WebApplication4.Models
{
    public class LoginDetails
    {
        public int Id { get; set; } = 0;
        public string EmpID { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}
