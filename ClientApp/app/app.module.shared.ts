import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './components/app/app.component'
import { WeatherComponent } from './components/weather/weather.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        WeatherComponent
    ],
    imports: [
        FormsModule, 
        RouterModule.forRoot([
            { path: '', redirectTo: 'weather', pathMatch: 'full' },
            { path: 'weather', component: WeatherComponent },
            { path: '**', redirectTo: 'weather' }
        ])
    ]
};
