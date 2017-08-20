using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private FilmsService service;
        public FilmsController(FilmsService service)
        {
            this.service = service;
        } 

        [HttpGet]
        public async Task<IEnumerable<Film>> All() => await this.service.GetAll();

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Film updatedFilm)
        {
            return await this.service.Update(updatedFilm);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> SetWatched(int id)
        {
            return await this.service.SetWatched(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await this.service.Delete(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Film film)
        {
            return await this.service.Add(film);
        }
    }
}
