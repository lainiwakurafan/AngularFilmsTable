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
        public async Task<IEnumerable<Film>> GetAllAsync() => await this.service.GetAllAsync();

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]Film updatedFilm)
        {
            return await this.service.UpdateAsync(updatedFilm);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> SetWatchedAsync(int id)
        {
            return await this.service.SetWatchedAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await this.service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]Film film)
        {
            return await this.service.AddAsync(film);
        }
    }
}
