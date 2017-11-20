import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FetchDataComponent } from './fetch-data.component';
import { ListComponent } from './list.component';
import { DetailsComponent } from './details.component';
import { SampleValuesFormComponent } from './form.component';
import { CreateComponent } from './create.component';
import { EditComponent } from './edit.component';

const routes: Routes = [
    { 
        path: 'values', 
        component: FetchDataComponent,
        children: [
            {
                path: '',
                component: ListComponent
            },
            {
                path: 'create',
                component: CreateComponent
            },
            {
                path: ':id',
                component: DetailsComponent
            },
            {
                path: ':id/edit',
                component: EditComponent
            }
        ] 
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ],
})
export class FetchDataRoutingModule { }

export const fetchDataComponents = [
    FetchDataComponent,
    ListComponent,
    DetailsComponent,
    SampleValuesFormComponent,
    CreateComponent,
    EditComponent
];