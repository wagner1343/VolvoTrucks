﻿import axios from 'axios';

const axiosInstance = axios.create({ baseURL: process.env.REACT_APP_API_URL });

axiosInstance.interceptors.response.use(
  (response) => response,
  (error) =>
    Promise.reject({
      ...(typeof error.response?.data !== 'string' && error.response?.data),
      response: error.response
    })
);

export default axiosInstance;
