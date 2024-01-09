//using System.ComponentModel.DataAnnotations
   // {
        public class WatchDetails
        {
           // [Key]
            public int Id { get; set; }
            //[Required]
            //[Required(ErrorMessage = " ID is required")]

            //[StringLength(10, MinimumLength = 5)]
            public string? Name { get; set; }
            
            public string? Description { get; set; }
           

           // [Range(0, 999, ErrorMessage = "Out of Range ")]
            public float? Price { get; set; }

            //[StringLength(10, MinimumLength = 2)]
            public string? Color { get; set; }
        }
   // }

    