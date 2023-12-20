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
        [Required]using System.ComponentModel.DataAnnotations;

namespace MyWatchApi.Model
    {
        public class WatchDetails
        {
            [Key]
            public int Id { get; set; }
            [Required]
            //[Required(ErrorMessage = " ID is required")]

            [StringLength(10, MinimumLength = 5)]
            public string? Name { get; set; }
            [Required]
            public string? Description { get; set; }
            [Required]

            [Range(0, 999, ErrorMessage = "Out of Range ")]
            public decimal? Price { get; set; }

            [StringLength(10, MinimumLength = 2)]
            public string? Color { get; set; }
        }
    }

    public string? Description { get; set; }
        [Required]

        public float? Price { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string? Color { get; set; }
    }
}
