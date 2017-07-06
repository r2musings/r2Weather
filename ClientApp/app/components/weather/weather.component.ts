import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'weather',
    template: require('./weather.component.html'),
    styleUrls: ['./weather.component.css']
})
export class WeatherComponent {
    public weather: Weather;

    constructor(private http: Http) {
    }

    public getWeather(zip: string) {
        this.http.get('/api/weather/zip/' + zip).subscribe(result => {
            this.weather = result.json();
        });
    }
}

interface Weather {
    currentTemp: number;
    minTemp: number;
    maxTemp: number;
    humidity: number;
    summary: string;
    zip: string;
    city: string;
}