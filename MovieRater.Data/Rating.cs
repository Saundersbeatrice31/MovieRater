using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 10)]
        public double MovieRating { get; set; }
        [Required]
        [Range(0, 10)]
        public double  TheaterRating { get; set; }
        public Guid AuthorId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        [ForeignKey(nameof(Movie))]
        public int RatId { get; set; }
        //Navigation Property
        public virtual Movie Movie { get; set; }

        //[ForeignKey(nameof(Theater))]
        //public int TheatId { get; set; }
        
        //public virtual Theater Theater { get; set; }


    }
}
