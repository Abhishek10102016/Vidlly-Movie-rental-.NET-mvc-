using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidlly.Dtos;
using Vidlly.Models;

namespace Vidlly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
                c => c.id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                c => newRental.MovieId.Contains(c.Id)).ToList();

            foreach(var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented= DateTime.Now
                };
                _context.Rental.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
            throw new NotImplementedException();
        }
    }
}
