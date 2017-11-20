import { Component, OnInit } from '@angular/core';

import { SampleValuesService } from './sample-values.service';
import { SampleValue } from './sample-values.models';

@Component({
    templateUrl: './list.component.html'
})

export class ListComponent implements OnInit {
    values: SampleValue[];

    constructor(private _valuesService: SampleValuesService) { 

    }

    ngOnInit() {
        this._valuesService.getList()
            .subscribe(
                result => this.values = result,
                error => console.log(error)
            )
    }

    selectItem(id: number) {
        this._valuesService.gotoDetails(id);
    }

    createItem() {
        this._valuesService.gotoCreate();
    }
}
