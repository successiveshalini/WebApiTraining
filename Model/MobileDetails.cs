using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace MyMobileApi1.Model
{
    public class MobileDetails
    {
        [Key]
       public int Id { get; set; }
       [Required]
        public string? Name { get; set; }
        [Required]  
        public string? Description { get; set; }
        [Required]  
        public float price { get; set; }
        [Required]  
        public string? color { get; set; }  

    }
}
