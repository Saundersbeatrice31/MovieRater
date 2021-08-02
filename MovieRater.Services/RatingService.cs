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
    public class RatingService
    {
        private readonly Guid _userId;
        public RatingService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRating(RatingsCreate model)
        {
            var entity =
                new Rating()
                {
                    MovieRating = model.MovieRating,
                    TheaterRating = model.TheaterRating,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RatingListItem> GetRating()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Ratings
                .Where(e => e.AuthorId == _userId)
                .Select(
                e =>
                new RatingListItem
                {
                    MovieRating = e.MovieRating,
                    TheaterRating = e.TheaterRating,
                    CreatedUtc = e.CreatedUtc
                }
            );
                return query.ToArray();
            }
        }
        public RatingDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.Id == id && e.AuthorId == _userId);
                return
                    new RatingDetail
                    {
                        Id = entity.Id,
                        MovieRating = entity.MovieRating,
                        TheaterRating = entity.TheaterRating,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public RatingDetail GetRatingByAuthorId(Guid AuthorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e =>  e.AuthorId == _userId);
                return
                    new RatingDetail
                    {
                        Id = entity.Id,
                        AuthorId = entity.AuthorId,
                        MovieRating = entity.MovieRating,
                        TheaterRating = entity.TheaterRating,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.Id == model.Id && e.AuthorId == _userId);
                entity.MovieRating = model.MovieRating;
                entity.TheaterRating = model.TheaterRating;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRating(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.Id == Id && e.AuthorId == _userId);
                ctx.Ratings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
