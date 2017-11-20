import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { SampleValuesService } from './sample-values.service';
import { SampleValue } from './sample-values.models';

@Component({
    templateUrl: './edit.component.html'
})

export class EditComponent implements OnInit {
    value: SampleValue;

    constructor(
        private _valuesService: SampleValuesService,
        private _route: ActivatedRoute
    ) { }

    ngOnInit() {
        this._route
        .params
        .switchMap((params: Params) => this._valuesService.getItem(+params['id']))
        .subscribe(
            result => this.value = result,
            error => console.log(error)
        );
    }

    submit(value: SampleValue) {
        if (!value)
            return;

        this.value = value;
        this._valuesService.editItem(this.value.id, this.value)
            .subscribe(
                result => this._valuesService.gotoList(),
                error => console.log(error)
            );
    }
}
