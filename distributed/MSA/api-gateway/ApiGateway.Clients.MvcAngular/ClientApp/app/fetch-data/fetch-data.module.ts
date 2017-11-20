import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { FetchDataRoutingModule, fetchDataComponents } from './fetch-data.routing';
import { SampleValuesService } from './sample-values.service';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
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
