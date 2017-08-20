using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class FilmsService
{
    private readonly FilmsRepository repository;

    public FilmsService(FilmsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> SetWatched(int id)
    {
        var film = await this.repository.Get(id);
        if (film == null) return new NotFoundResult();

        var result = await this.repository.SetWatched(film);
        if (result > 0) return new OkResult();

        return new BadRequestResult();
    }

    internal async Task<IEnumerable<Film>> GetAll() => await repository.GetAll().ToList();

    internal async Task<IActionResult> Update(Film updatedFilm)
    {
        var result = await this.repository.Update(updatedFilm);
        if (result > 0) return new OkResult();
        return new BadRequestResult();
    }

    internal async Task<IActionResult> Delete(int id)
    {
        var result = await this.repository.Delete(id);
        if (result > 0) return new OkResult();
        return new BadRequestResult();
    }

    internal async Task<IActionResult> Add(Film film)
    {
        var result = await this.repository.Add(film);
        if (result > 0) return new OkObjectResult(result);
        return new BadRequestResult();
    }
}