import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../../environments/environment.development';

const BASE_URL: string = environment.MOVIE_API

@Injectable({
  providedIn: 'root',
})
export class MovieService {
    private _http: HttpClient = inject(HttpClient)

    public readonly movieResponse = signal<any | null>(null)
    
    public readonly movieError = signal<any | null>(null)

    getAllMovie = () => {
        try {

            console.log("Im here");
            
            const response = this._http.get(BASE_URL+"/movie")
            console.log(response);
            
            response.subscribe({
                next: (res) => this.movieResponse.set(res),
                error: (err) => {
                    console.log(err);
                    
                    this.movieError.set(err)} 
            })

        } catch (error) {

            console.log("Something go wrong ", error);
            
        }
    }
}
