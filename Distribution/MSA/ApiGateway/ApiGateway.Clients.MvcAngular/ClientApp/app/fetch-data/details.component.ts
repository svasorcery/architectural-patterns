import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { SampleValuesService } from './sample-values.service';
import { SampleValue } from './sample-values.models';

@Component({
    templateUrl: './details.component.html'
})

export class DetailsComponent implements OnInit {
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

    editItem() {
        if(!this.value)
            return;
            
        this._valuesService.gotoEdit(this.value.id);
    }

    deleteItem() {
        if(!this.value)
            return;

        if (confirm(`Are you sure want to delete \'${this.value.name}\'?`)) { 
            this._valuesService.deleteItem(this.value.id);
        }
    }
}
