import { WeatherForecastResponse } from "../types/Response.types";
import { apiClient } from "./client";

async function getWeather() {
    const response = await apiClient.get<WeatherForecastResponse[]>('WeatherForecast');
    return response.data;
}

export default {getWeather};