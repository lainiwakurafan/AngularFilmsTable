using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularFilmsTable.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        public SampleDataController(FilmsRepository repository){
            this.repository = repository;
        } 
        /*
         public SampleDataController()
         {
             
         }
         */
        private FilmsRepository repository;

        [HttpGet("[action]")]
        public IEnumerable<Film> Films()
        {
            return repository.GetAllFilms();
        }

        [HttpPatch("[action]")]
        public IActionResult Update([FromBody]Film updatedFilm)
        {
            /*
            .Films.Attach(updatedFilm);
            context.Entry(updatedFilm).State = EntityState.Modified;
            context.SaveChanges();
            */

            return Ok();
        }

        public class Film{
            [Key]
            public Guid Id { get; internal set; }
            public string Title { get; set; }
            public string Directors { get; set; }
            public int Year { get; set; }
            public bool Watched { get; set; }
        }
    }
}
