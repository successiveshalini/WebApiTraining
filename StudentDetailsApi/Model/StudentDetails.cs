using System.ComponentModel.DataAnnotations;

namespace SimpleWebApiProject.Model
{
    public class StudentDetails
    {
        [Key]
        public int StudentId { get; set; }
        public string? Name { get; set; } 
        public int Age { get; set; } 
        public long Phone { get; set; }
        public string? EmailAddress { get; set; }
        public string? Address { get; set; }
    }
}
