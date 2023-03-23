import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './exercise-1.component.html'
})
export class Exercise1Component {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;

      this.forecasts.forEach((f) => {
        f.temperature.temperatureF = this.calculateFTemperature(f.temperature.temperatureC);
      })

      this.filterData();
    }, error => console.error(error));
  }

  public calculateFTemperature = (temperatureC) => {
    return (temperatureC + 32) / 0.5556;
  }

  public filterData = () => {
    //Only keep data with Type is not null
    this.forecasts = this.forecasts.filter(f => !f.type);
  }
}

interface WeatherForecast {
  date: string;
  temperature: Temperature;
  summary: string;
  type: any;
}

interface Temperature {
  temperatureC: any;
  temperatureF: any;
}
