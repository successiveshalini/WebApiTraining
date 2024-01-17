using System.ComponentModel.DataAnnotations;

namespace MyNewProjectApi.Model
{
    public class UpdateEmployeeRecord
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? EmailAddress { get; set; }
        public decimal Amount { get; set; }
        public string? Address { get; set; }
    }
}
