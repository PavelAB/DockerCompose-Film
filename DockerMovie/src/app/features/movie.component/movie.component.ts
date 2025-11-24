import { Component, effect, inject, OnInit } from '@angular/core';
import { MovieService } from './services/movie.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-movie',
  imports: [],
  templateUrl: './movie.component.html',
  styleUrl: './movie.component.scss',
})
export class MovieComponent implements OnInit {
    private _movieService = inject(MovieService)
    
    allMovie = this._movieService.movieResponse
    Error = this._movieService.movieError

    logMovieResponse = effect(()=>{
        console.log("MovieResponse -->", this.allMovie());
        console.log("Docker works");
        
    })
    
    ngOnInit(): void {
        this._movieService.getAllMovie()
        console.log("Response --->", this.allMovie());
        console.log("Error --> ", this.Error())
        
    }
}
