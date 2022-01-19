import {AxiosInstance} from "axios";
import Truck from "src/data/Truck";
import axiosInstance from "src/utils/axios";

export default class TruckModelsApi {
  axios: AxiosInstance;

  constructor(axios: AxiosInstance) {
    this.axios = axios;
  }
  
  async list(): Promise<ListTrucksResponse> {
    const response = await this.axios.get<ListTrucksResponse>("truckmodels");
    return response.data;
  }
  
}

export interface ListTrucksResponse {
  data: Truck[];
}

export const truckModelsApi = new TruckModelsApi(axiosInstance);