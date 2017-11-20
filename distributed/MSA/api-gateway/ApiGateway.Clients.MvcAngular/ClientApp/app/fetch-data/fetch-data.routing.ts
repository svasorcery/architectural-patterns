import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FetchDataComponent } from './fetch-data.component';
import { ListComponent } from './list.component';

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
    ListComponent
];