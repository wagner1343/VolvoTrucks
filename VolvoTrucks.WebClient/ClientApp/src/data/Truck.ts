import BaseEntity from "src/data/BaseEntity";
import TruckModel from "src/data/TruckModel";

export default interface Truck extends BaseEntity {
  model: TruckModel;
  modelYear: number;
  manufacturingYear: number;
  name: string;
}