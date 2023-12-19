using System.ComponentModel.DataAnnotations;

namespace MyWatchApi.Model
{
    public class WatchDetails
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " ID is required")]

        [StringLength(10, MinimumLength = 5)]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required] 
        public float? Price { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string? Color { get; set;}
        //public string? Password { get; set; }
        //[Required]
        //[Compare("Password")]
        //public string? ConformPassword { get; set; }  
        
    } 
}
