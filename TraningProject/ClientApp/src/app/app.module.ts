import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { Exercise1Component } from './exercise1/exercise-1.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { Exercise2Component } from './exercise2/exercise-2.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    Exercise1Component,
    NavMenuComponent,
    Exercise2Component,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '', component: HomeComponent, pathMatch: 'full',
      },
      {
        path: 'exercise-1', component: Exercise1Component, pathMatch: 'full',
      },
      {
        path: 'exercise-2', component: Exercise2Component, pathMatch: 'full',
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
