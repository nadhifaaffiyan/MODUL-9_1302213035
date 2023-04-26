using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace modul9_1302213035
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies : Controller
    {
        public static List<Movie> mvi = new List<Movie>
        {
            new Movie {Title = "The Shawshank Redemption (1994)", Director = "Frank Darabont",
                Stars = {"Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler"},
                Description = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion."},
            new Movie {Title = "The Godfather (1972)", Director = "Francis Ford Coppola",
                Stars = {"Marlon Brando", "Al Pacino", "James Caan", "Diane Keaton"},
                Description = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son."},
            new Movie {Title = "The Dark Knight (2008)", Director = "Christopher Nolan",
                Stars = {"Christian Bale", "Heath Ledger", "Aaron Eckhart", "Michael Caine"},
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."}
        };

        // GET: api/<Movies>
        // meretur output berupa list dari semua obj mvi
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return mvi;
        }

        // GET api/<Movies>/{id}
        // meretur output berupa obj mvi ke-i
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return mvi[id];
        }

        // POST api/<Movies>
        // menambah obj mvi baru
        [HttpPost]
        public IActionResult Post([FromBody] Movie newMvi)
        {
            mvi.Add(newMvi);
            return Ok();
        }

        // DELETE api/<Movies>/{id}
        // menghapus obj mvi ke-i
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= mvi.Count)
            {
                return NotFound();
            }

            mvi.RemoveAt(id);
            return Ok();
        }
    }
    public class Movie
    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public List<string>? Stars { get; set; }
        public string? Description { get; set; }
        public Movie(string Title, string Director, List<string> Stars, string Description)
        {
            this.Title = Title;
            this.Director = Director;
            this.Stars = new List<string>();
            this.Description = Description;
        }
    }
}
