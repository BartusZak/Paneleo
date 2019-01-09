export class Product {
  id: number;
  name: string;
  brand: string;
  quantity: number;
  unitOfMeasure: string;
  netPrice: number;
  grossPrice: number;
}

export class ProductForOrder extends Product {
  productQuantity: number;
  totalNetPrice: number;
  totalGrossPrice: number;
}
