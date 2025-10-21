import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Setting } from '../models/setting.model';

@Injectable({
  providedIn: 'root' 
})
export class SettingService {
    private _settings = new Map<string, Setting>();

    private http = inject(HttpClient);
    private apiUrl = 'http://localhost:5062/api/Settings/GetAll'; 

    getAllSettings(): Observable<Map<string, Setting>> {
        return this.http.get<Map<string, Setting>>(this.apiUrl);
    }

}
