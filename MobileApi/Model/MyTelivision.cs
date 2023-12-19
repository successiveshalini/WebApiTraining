using System.ComponentModel.DataAnnotations;

namespace MyTelevisionApi.Model
{
    public class MyTelivision
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]  
        public string? color { get; set; }   
    }
}
