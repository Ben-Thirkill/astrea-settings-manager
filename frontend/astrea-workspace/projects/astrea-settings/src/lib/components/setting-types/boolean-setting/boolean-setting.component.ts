import {Component, Input, OnInit, signal, WritableSignal} from '@angular/core';
import { ToggleSwitchModule } from 'primeng/toggleswitch';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'boolean-setting',
  templateUrl: './boolean-setting.component.html',
    imports: [ToggleSwitchModule, FormsModule],
  styleUrls: ['./boolean-setting.component.scss']
})

export class BooleanSettingComponent implements OnInit {
    @Input() serializedValue: string = '';
    public value: WritableSignal<boolean> = signal(false);

    ngOnInit() {
        this.value.set(this.deserialize(this.serializedValue))
    }

    public deserialize(serializedValue: string): boolean {
        if (serializedValue === "true") {
            return true;
        }

        if (serializedValue === "false") {
            return false;
        }

        throw new Error('Invalid boolean setting value');
    }

}
