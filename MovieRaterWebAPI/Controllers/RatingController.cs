using Microsoft.AspNet.Identity;
using MovieRater.Models;
using MovieRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRaterWebAPI.Controllers
{
    [Authorize]
    public class RatingController : ApiController
    {
        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new RatingService(userId);
            return ratingService;
        }
        public IHttpActionResult GetRating()
        {
            RatingService ratingService = CreateRatingService();
            var rating = ratingService.GetRating();
            return Ok(rating);
        }
        public IHttpActionResult Post(RatingsCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateRatingService();
            if (!service.CreateRating(rating))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult GetRatingById(int id)
        {
            RatingService ratingService = CreateRatingService();
            var rating = ratingService.GetRatingById(id);
            return Ok(rating);
        }
        public IHttpActionResult Put(RatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateRatingService();
            if (!service.UpdateRating(rating))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRatingService();
            if (!service.DeleteRating(id))
                return InternalServerError();
            return Ok();
        }
    }
}
