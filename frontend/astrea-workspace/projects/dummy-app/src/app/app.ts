import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AstreaSettings } from 'astrea-settings';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AstreaSettings],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('dummy-app');
}
