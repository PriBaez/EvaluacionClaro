using System.ComponentModel.DataAnnotations;

namespace evaluacionAPI.Models
{
    public partial class Books
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Title length can't be more than 30.")]
        public string title { get; set;} = null!;

        [Required]
        [StringLength(30, ErrorMessage = "Author length can't be more than 30.")]
        public string author { get; set; } = null!;

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Release date is required")]
        public DateTime release_date { get; set; }

        [Required]
        [StringLength(40)]
        public string genre { get; set; } = null!;
    }
}