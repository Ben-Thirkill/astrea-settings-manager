import {Component, Input, OnInit, signal, WritableSignal} from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'text-setting',
  templateUrl: './text-setting.component.html',
    imports: [InputTextModule],
  styleUrls: ['./text-setting.component.scss']
})

export class TextSettingComponent implements OnInit {
    @Input() serializedValue: string = '';
    public value: WritableSignal<string> = signal('');

    ngOnInit() {
        this.value.set(this.deserialize(this.serializedValue))
    }

    public deserialize(serializedValue: string): string {
        return serializedValue;
    }

}
