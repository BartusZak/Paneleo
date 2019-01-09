import { Contractor } from './contractor';
import { Product } from './product';
import { Entity } from './entity';

export class Order extends Entity {
  name: string;
  place: string;
  contractor: Contractor;
  products: Array<Product>;
  netPrice: number;
  grossPrice: number;
}
