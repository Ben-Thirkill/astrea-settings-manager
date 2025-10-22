import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {firstValueFrom, Observable} from 'rxjs';
import { Setting } from '../models/setting.model';

@Injectable({
  providedIn: 'root'
})
export class SettingService {
    private _settings: Map<string, Setting> | null = null;
    private _loadingPromise?: Promise<void> | null;

    private http = inject(HttpClient);
    private apiUrl = 'http://localhost:5062/api/Settings/GetAll';

    getAllSettings(): Observable<Map<string, Setting>> {
        return this.http.get<Map<string, Setting>>(this.apiUrl);
    }

    public getSettingInfo(id: string) {
        if (this._settings != null) {
            return this._settings.get(id)
        }

        return undefined;
    }

    public async ensureLoaded(): Promise<void> {
      if (this._settings !== null) return;
      if (this._loadingPromise) return this._loadingPromise;

      this._loadingPromise = firstValueFrom(
          this.getAllSettings()
      ).then(result => {
          this._settings = new Map(Object.entries(result));
      }).finally(() => {
          this._loadingPromise = null;
      });

      return this._loadingPromise;
    }
}
