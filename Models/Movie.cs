using System.ComponentModel.DataAnnotations;

namespace ASPnetcoreapp.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
