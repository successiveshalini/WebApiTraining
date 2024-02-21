using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; } 
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set;}
        public string? Productprice { get; set; }

    }
}
