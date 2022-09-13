using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Movie
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int GenreID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; } = true;

        public Genre Genre { get; set; }
    }
}
