import { Component, Input, Output, EventEmitter } from '@angular/core';

import { SampleValuesService } from './sample-values.service';
import { SampleValue } from './sample-values.models';

@Component({
    selector: 'sample-values-form',
    templateUrl: './form.component.html'
})

export class SampleValuesFormComponent {
    @Input() value: SampleValue;
    @Output("save") onSave: EventEmitter<SampleValue> = new EventEmitter<SampleValue>();

    constructor() { }

    submit() {
        this.onSave.emit(this.value);
    }
}
