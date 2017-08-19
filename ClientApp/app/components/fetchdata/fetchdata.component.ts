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
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})

export class FetchDataComponent {
    public films: Film[];
    public forecasts: WeatherForecast[];

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) {
        this.loadFilms();
    }
    public loadFilms()
    {
        this.http.get(this.originUrl + '/api/SampleData/Films').subscribe(result => {
            this.films = result.json() as Film[];
        });
    }

    public save(film:Film, rowForm: NgForm)
    {
        if (rowForm.invalid) {
            alert("row form is invalid");
            return;
        }

        this.http.patch(this.originUrl + '/api/SampleData/Update', {
            Title: rowForm.value.filmTitle,
            Directors: rowForm.value.filmDirectors,
            Year: rowForm.value.filmYear
        }).subscribe(result => {
            alert(result.ok);
            if (result.ok){
                film.isEditing = false;
                film.title = rowForm.value.filmTitle;
                film.directors = rowForm.value.filmDirectors;
                film.year = rowForm.value.filmYear;
            };
        });
    }

    public update

    public cancel(film:Film)
    {
        film.isEditing = false;
    }

    public del(film:Film)
    {
        this.deleteFilm(film);
    }
    
    deleteFilm(film:Film) {
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
            title: addNewFilmForm.value.newFilmTitle,
            directors:addNewFilmForm.value.newFilmDirectors,
            year: addNewFilmForm.value.newFilmYear,
            isEditing:false,
            watched: false
        };
        this.films.push(newFilm);
    }

    public checkboxChange(film:Film)
    {
        film.watched = true;
        alert(film.watched);
    }
}
class Repository
{
    http: Http;
    originUrl: string;
    /**
     *
     */
    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        
        this.http = http;
        this.originUrl = originUrl;
    }

    /**
     * name
     */
    public update(film:Film) {
        
    }
    public get()
    {
        return ;
    }

}

interface Film{
    title: string;
    directors: string;
    year: number;
    isEditing: boolean;
    watched: boolean;
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
