using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public enum GenreType
    {
        Horror = 1,
        RomCom,
        Documentary,
        Bromance,
        Drama,
        Action
    }
    public enum MaturityRating
    {
        G = 1,
        PG,
        PG_13,
        R,
        NC_17
    }
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int RunTime { get; set; }
        public GenreType TypeOfGenres { get; set; }
        public string Actors { get; set; }
        public DateTime Release { get; set; }
        public MaturityRating Maturity { get; set; }

        //public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        //public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        //public virtual ICollection<Theater> Theaters { get; set; } = new List<Review>();

    }
}
