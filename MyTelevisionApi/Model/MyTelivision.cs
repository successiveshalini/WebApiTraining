using System.ComponentModel.DataAnnotations;

namespace MyTelevisionApi.Model
{
    public class MyTelivision
    {
        [Key]
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public string? Description { get; set; }
          
        public string? color { get; set; }   
    }
}
