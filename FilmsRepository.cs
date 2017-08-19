using System;
using System.Collections.Generic;
using static AngularFilmsTable.Controllers.SampleDataController;

public class FilmsRepository{
    private FilmsDbContext context;
    public FilmsRepository(FilmsDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Film> GetAllFilms() => context.Films;
}