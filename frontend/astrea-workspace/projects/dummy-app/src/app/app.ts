import 'zone.js'; 
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AstreaSettings, SettingService } from 'astrea-settings';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AstreaSettings],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('dummy-app');

  constructor(private settingService: SettingService) {}

  ngOnInit(): void {
    this.settingService.getAllSettings().subscribe(users => {
      console.log('Fetched users:', users);
    });
  }
}
