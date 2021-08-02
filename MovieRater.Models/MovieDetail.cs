using MovieRater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class MovieDetail
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RunTime { get; set; }
        public GenreType TypeOfGenres { get; set; }
        public string Actors { get; set; }
        public DateTime Release { get; set; }
    }
}
