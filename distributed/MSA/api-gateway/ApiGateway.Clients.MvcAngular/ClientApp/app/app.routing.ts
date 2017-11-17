import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [
      RouterModule.forRoot(routes)
    ],
  exports: [
      RouterModule
    ],
})
export class AppRoutingModule { }

export const appComponents = [
    AppComponent,
    NavMenuComponent,
    HomeComponent
];