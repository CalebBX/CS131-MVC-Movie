using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;
using Newtonsoft.Json;

namespace MovieApp.Controllers
{
    public class DbCommandsController : Controller
    {
        private readonly MovieAppContext _context;
        public DbCommandsController(MovieAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<string> SeedMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (StreamReader r = new StreamReader("temp/MovieData.json"))
            {
                string json = r.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            foreach(Movie movie in movies)
            {
                await _context.Movie.AddAsync(movie);
            }
            await _context.SaveChangesAsync();
            return "Successfully seeded movies";
        }
    }
}