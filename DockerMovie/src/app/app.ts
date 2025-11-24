import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MovieComponent } from "./features/movie.component/movie.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MovieComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('DockerMovie');
}
