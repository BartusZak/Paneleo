export class Product {
  id: number;
  name: string;
  brand: string;
  quantity: number;
  unitOfMeasure: string;
  pricePerUnit: number;
}

export class ProductForOrder extends Product {
  productsQuantity: number;
  totalCost: number;
}
