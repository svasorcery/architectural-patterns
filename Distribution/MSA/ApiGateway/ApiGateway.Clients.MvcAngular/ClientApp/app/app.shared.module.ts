import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule, appComponents } from './app.routing';
import { FetchDataModule } from './fetch-data/fetch-data.module';

@NgModule({
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        FetchDataModule,
        AppRoutingModule
    ],
    declarations: [
        ...appComponents
    ],
})
export class AppModuleShared {
}
