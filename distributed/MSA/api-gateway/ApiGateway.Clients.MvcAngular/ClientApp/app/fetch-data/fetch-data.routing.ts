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
        path: 'fetch-data', 
        component: FetchDataComponent,
        children: [
            {
                path: '',
                redirectTo: 'list',
                pathMatch: 'full'
            },
            {
                path: 'list',
                component: ListComponent
            },
            {
                path: 'create',
                component: CreateComponent
            },
            {
                path: 'details/:id',
                component: DetailsComponent
            },
            {
                path: 'edit/:id',
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