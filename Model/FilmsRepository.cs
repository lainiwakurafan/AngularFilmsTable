using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static FilmsApp.Controllers.FilmsController;

public class FilmsRepository{
    private FilmsDbContext context;
    public FilmsRepository(FilmsDbContext context)
    {
        this.context = context;
    }

    public IAsyncEnumerable<Film> GetAllAsync() => context.Films.ToAsyncEnumerable();

    internal async Task<int> UpdateAsync(Film updatedFilm)
    {
        context.Films.Attach(updatedFilm);
        context.Entry(updatedFilm).State = EntityState.Modified;
        context.Entry(updatedFilm).Property(f => f.Watched).IsModified = false;
        return await context.SaveChangesAsync();
    }

    internal async Task<int> SetWatchedAsync(Film film)
    {
        film.Watched = true;
        context.Films.Attach(film);
        context.Entry(film).Property(f => f.Watched).IsModified = true;
        return await context.SaveChangesAsync();
    }
    
    internal async Task<Film> GetAsync(int id)
    {
        return await context.FindAsync<Film>(id);
    }

    internal async Task<int> DeleteAsync(int id)
    {
        var film = new Film {Id = id};
        context.Entry(film).State = EntityState.Deleted;
        return await context.SaveChangesAsync();
    }

    internal async Task<int> AddAsync(Film film)
    {
        var result = await context.AddAsync(film);

        if (result.IsKeySet && (await context.SaveChangesAsync() > 0)) {
            return result.Entity.Id;
        }
        return -1;
    }
}