import React, { useEffect, useState } from 'react';
import './App.css';
import WeatherForcastApi from './api/weather';
import { WeatherForecastResponse } from './types/Response.types';

function App() {
  const [weatherRecords, setWeatherForecast] = useState<WeatherForecastResponse[]>([]);

  useEffect(() => {
    WeatherForcastApi.getWeather()
      .then(response => {
        setWeatherForecast(response)})
      .catch(err => console.log(err));
  }, []);

  return (
    <div className="App">
      <ul>
        {weatherRecords.map((list, i) =>(
          <li key={i}>
            <span>{list.temperatureC}</span>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
