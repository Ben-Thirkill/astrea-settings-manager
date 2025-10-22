import 'zone.js';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AstreaSettings, SettingComponent, SettingService } from 'astrea-settings';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AstreaSettings, SettingComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('dummy-app');

  constructor(private settingService: SettingService) {}

}
