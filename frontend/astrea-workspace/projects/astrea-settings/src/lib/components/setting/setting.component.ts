import {Component, Input, Output, EventEmitter, OnInit} from '@angular/core';
import {Setting} from '../../models/setting.model';
import { SettingService } from '../../services/settings.service';
import { signal, WritableSignal } from '@angular/core';

@Component({
  selector: 'setting',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.scss']
})

export class SettingComponent implements OnInit {
  private _settingService: SettingService = new SettingService();

  @Input() settingId: string = '';

  public setting: WritableSignal<Setting | undefined> = signal(undefined);

  async ngOnInit() {
      await this._settingService.ensureLoaded();
      this.setting.set(this._settingService.getSettingInfo(this.settingId))
  }
}
