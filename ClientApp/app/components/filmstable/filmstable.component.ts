import { NgModule } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgForm } from '@angular/forms';

@NgModule({
  imports: [     
    BrowserModule,
	FormsModule
  ]
}) 

@Component({
    selector: 'filmstable',
    templateUrl: './filmstable.component.html'
})

export class FilmsTableComponent {
    public films: Film[];

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) {
        this.loadFilms();
    }
    public loadFilms()
    {
        this.http.get(this.originUrl + '/api/films').subscribe(result => {
            this.films = result.json() as Film[];
        });
    }

    public save(film:Film, rowForm: NgForm)
    {
        if (rowForm.invalid) {
            alert("row form is invalid");
            return;
        }

        this.http.put(this.originUrl + '/api/films', {
            Id: rowForm.value.filmId,
            Title: rowForm.value.filmTitle,
            Directors: rowForm.value.filmDirectors,
            Year: rowForm.value.filmYear,
        }).subscribe(result => {
            if (result.ok){
                film.title = rowForm.value.filmTitle;
                film.directors = rowForm.value.filmDirectors;
                film.year = rowForm.value.filmYear;
                film.isEditing = false;
            };
        });
    }

    public cancel(film:Film)
    {
        film.isEditing = false;
    }

    public del(film:Film)
    {
        this.http.delete(this.originUrl + "/api/films/" + film.id).subscribe(result => {
            if (result.ok) {
                this.deleteFilm(film);
            }
        });
    }
    
    public deleteFilm(film:Film) {
        let index: number = this.films.indexOf(film);
        if (index !== -1) {
            this.films.splice(index, 1);
        }        
    }

    public add(addNewFilmForm:NgForm)
    {
        if (addNewFilmForm.invalid) {
            alert("add new film form is invalid");
            return;
        }

        var newFilm = {
            id: null,
            title: addNewFilmForm.value.newFilmTitle,
            directors:addNewFilmForm.value.newFilmDirectors,
            year: addNewFilmForm.value.newFilmYear,
            isEditing:false,
            watched: false
        };
        
        this.http.post(
            this.originUrl + "/api/films",
            {Title: newFilm.title, Directors: newFilm.directors, Year: newFilm.year}
        ).subscribe(result => {
            if (result.ok){
                newFilm.id = result.json() as number;
                this.films.push(newFilm);
            }
        });
    }

    public checkboxChange(film:Film)
    {
        this.http.patch(this.originUrl + '/api/films/' + film.id, null).subscribe(result => {
            if (result.ok){
                film.watched = true;
            };
        });
    }
}

interface Film{
    id:number;
    title: string;
    directors: string;
    year: number;
    isEditing: boolean;
    watched: boolean;
}