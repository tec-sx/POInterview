import axios from 'axios';

const baseURL = 'https://localhost:7182/'

export const api = axios.create({
    withCredentials: false,
    baseURL: baseURL
});

const errorHandler = (error: any) => {
    const statusCode = error.response?.status

    if (statusCode && statusCode !== 401) {
      console.error(error)
    }
  
    return Promise.reject(error)
  }

  api.interceptors.response.use(undefined, (error) => {
    return errorHandler(error)
  })