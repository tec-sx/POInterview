import axios from 'axios';

const baseURL = 'https://localhost:7182/'

export const apiClient = axios.create({
    baseURL: baseURL
});