using System.ComponentModel.DataAnnotations;

namespace ConsumeWebApi.Model
{
    public class ProductList
    {
        public int Id { get; set; }
        [Required]
        public string? ProductNmae { get; set; }
        [Required]  
        public double? Price { get; set; }
        [Required]  
        public int Quantities { get; set; }
    }
}
