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

    public IAsyncEnumerable<Film> GetAll() => context.Films.ToAsyncEnumerable();

    internal async Task<int> Update(Film updatedFilm)
    {
        context.Films.Attach(updatedFilm);
        context.Entry(updatedFilm).State = EntityState.Modified;
        context.Entry(updatedFilm).Property(f => f.Watched).IsModified = false;
        return await context.SaveChangesAsync();
    }

    internal async Task<int> SetWatched(Film film)
    {
        film.Watched = true;
        context.Films.Attach(film);
        context.Entry(film).Property(f => f.Watched).IsModified = true;
        return await context.SaveChangesAsync();
    }
    
    internal async Task<Film> Get(int id)
    {
        return await context.FindAsync<Film>(id);
    }

    internal async Task<int> Delete(int id)
    {
        var film = new Film {Id = id};
        context.Entry(film).State = EntityState.Deleted;
        return await context.SaveChangesAsync();
    }

    internal async Task<int> Add(Film film)
    {
        var result = await context.AddAsync(film);

        if (result.IsKeySet && (await context.SaveChangesAsync() > 0)) {
            return result.Entity.Id;
        }
        return -1;
    }
}