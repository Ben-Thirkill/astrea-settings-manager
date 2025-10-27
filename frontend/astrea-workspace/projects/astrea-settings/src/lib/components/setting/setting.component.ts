import {Component, Input, Output, EventEmitter, OnInit} from '@angular/core';
import {Setting} from '../../models/setting.model';
import { SettingService } from '../../services/settings.service';
import { signal, WritableSignal } from '@angular/core';
import {TextSettingComponent} from '../setting-types/text-setting/text-setting.component';
import {BooleanSettingComponent} from '../setting-types/boolean-setting/boolean-setting.component';

@Component({
    selector: 'setting',
    templateUrl: './setting.component.html',
    imports: [
        TextSettingComponent,
        BooleanSettingComponent
    ],
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
