import {AxiosInstance} from "axios";
import Truck from "src/data/Truck";
import axiosInstance from "src/utils/axios";

export default class TrucksApi {
  axios: AxiosInstance;

  constructor(axios: AxiosInstance) {
    this.axios = axios;
  }
  
  async list(): Promise<ListTrucksResponse> {
    const response = await this.axios.get<ListTrucksResponse>("trucks");
    return response.data;
  }
  
  async delete(truckId: number): Promise<void> {
    await this.axios.delete(`trucks/${truckId}`);
  }
  
  async update(truckId: number, request: UpdateTruckRequest) : Promise<void>  {
    await this.axios.put(`trucks/${truckId}`, request);
  }
  
  async create(request: CreateTruckRequest) : Promise<CreateTruckResponse> {
    const response = await this.axios.post<CreateTruckResponse>("trucks", request);
    return response.data
  }
}

export interface UpdateTruckRequest {
  modelId: number;
  modelYear: number;
}


export interface ListTrucksResponse {
  data: Truck[];
}

export interface CreateTruckResponse {
  data: Truck;
}

export interface CreateTruckRequest {
  modelId: number;
  modelYear: number;
  name: string;
}

export const trucksApi = new TrucksApi(axiosInstance);