import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FetchDataRoutingModule, fetchDataComponents } from './fetch-data.routing';
import { SampleValuesService } from './sample-values.service';


@NgModule({
    imports: [
        CommonModule,
        FetchDataRoutingModule
    ],
    declarations: [
        ...fetchDataComponents
    ],
    providers: [
        SampleValuesService
    ],
    exports: [
        
    ],
})
export class FetchDataModule { }
