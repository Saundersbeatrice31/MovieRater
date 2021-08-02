using MovieRater.Data;
using MovieRater.Models;
using MovieRaterWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class MovieService
    {
        private readonly Guid _userId;
        public MovieService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    Title = model.Title,
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MovieListItem> GetMovies(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Movies
                .Where(e => e.Title == title)
                .Select(
                e =>
                new MovieListItem
                {
                    ID = e.ID,
                    Title = e.Title,
                    TypeOfGenres = e.TypeOfGenres,
                    Description = e.Description
                }
            );
                return query.ToArray();
            }
        }
        public IEnumerable<MovieListItem> GetMoviesByRunTime(int runtime)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Movies
                .Where(e => e.RunTime == runtime)
                .Select(
                e =>
                new MovieListItem
                {
                    ID = e.ID,
                    Title = e.Title,
                    TypeOfGenres = e.TypeOfGenres,
                    Description = e.Description
                }
            );
                return query.ToArray();
            }
        }
        public IEnumerable<MovieListItem> GetMoviesByRelease(DateTime release)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Movies
                .Where(e => e.Release == release)
                .Select(
                e =>
                new MovieListItem
                {
                    ID = e.ID,
                    Title = e.Title,
                    TypeOfGenres = e.TypeOfGenres,
                    Description = e.Description
                }
            );
                return query.ToArray();
            }
        }
        public MovieDetail GetMovieById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.ID == id);
                return
                    new MovieDetail
                    {
                        ID = entity.ID,
                        Title = entity.Title,
                        TypeOfGenres = entity.TypeOfGenres,
                        Actors = entity.Actors,
                        Description = entity.Description,
                        RunTime = entity.RunTime,
                        Release = entity.Release

                    };
            }
        }
        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.ID == model.ID);
                entity.Title = model.Title;                
                entity.Actors = model.Actors;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMovies(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.ID == Id);
                ctx.Movies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
