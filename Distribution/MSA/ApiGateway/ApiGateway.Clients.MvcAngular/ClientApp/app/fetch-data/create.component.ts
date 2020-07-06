import { Component, OnInit } from '@angular/core';

import { SampleValuesService } from './sample-values.service';
import { SampleValue } from './sample-values.models';

@Component({
    templateUrl: './create.component.html'
})

export class CreateComponent implements OnInit {
    value: SampleValue;

    constructor(private _valuesService: SampleValuesService) { 

    }

    ngOnInit() {
        this.value = new SampleValue();
    }

    submit(value: SampleValue) {
        if (!value)
            return;

        this.value = value;
        this._valuesService.createItem(this.value)
            .subscribe(
                result => this._valuesService.gotoList(),
                error => console.log(error)
            );
    }
}
