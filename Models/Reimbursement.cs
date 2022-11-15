using System;

namespace WebApplication4.Models
{
    public class Reimbursement
    {
        public int Id { get; set; } = 0;
        public string EmpId { get; set; }
        public string EmailId { get; set; }
        public string Type { get; set; }
        public string Attachment { get; set; }
        public string remarks { get; set; }
        public string status { get; set; }
        public DateTime CurrentDateTime { get; set; }


    }
}
