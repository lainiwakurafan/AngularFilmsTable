using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FilmsService
{
    private readonly FilmsRepository repository;

    public FilmsService(FilmsRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> SetWatchedAsync(int id)
    {
        var film = await this.repository.GetAsync(id);
        if (film == null) return new NotFoundResult();

        try
        {
            var result = await this.repository.SetWatchedAsync(film);
            if (result > 0) return new OkResult();
        }
        catch (DbUpdateConcurrencyException)
        {
            return new BadRequestObjectResult(
                $"The object you are trying to save (id={id}) was changed by another user");
        }

        return new BadRequestResult();
    }

    internal async Task<IEnumerable<Film>> GetAllAsync() => await repository.GetAllAsync().ToList();

    internal async Task<IActionResult> UpdateAsync(Film updatedFilm)
    {
        try
        {
            var result = await this.repository.UpdateAsync(updatedFilm);
            if (result > 0) return new OkResult();
        }
        catch (DbUpdateConcurrencyException)
        {
            return new BadRequestObjectResult(
                $"The object you are trying to save (id={updatedFilm.Id}) was changed by another user");
        }
        return new BadRequestResult();
    }

    internal async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var result = await this.repository.DeleteAsync(id);
            if (result > 0) return new OkResult();
            return new BadRequestResult();
        }
        catch (DbUpdateConcurrencyException)
        {
            return new BadRequestObjectResult(
                $"The object you are trying to remove (id={id}) was changed by another user");
        }
    }

    internal async Task<IActionResult> AddAsync(Film film)
    {
        var result = await this.repository.AddAsync(film);
        if (result > 0) return new OkObjectResult(result);
        return new BadRequestResult();
    }
}