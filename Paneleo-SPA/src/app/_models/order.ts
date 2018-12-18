export class Order {
  id: number;
  place: string;
  contractorId: number;
  // products: Array<{ productId: number; quantity: number; totalCost: number }>;
  products: any;
  dateOfIssue: Date;
  dateOfSell: Date;
  totalCost: number;

  // constructor(
  //   id: number,
  //   note: string,
  //   client: string,
  //   items: Array<{ id: number; text: string }>,
  //   dateOfIssue: Date,
  //   endDate: Date,
  //   pleace: string
  // ) {
  //   this.id = id;
  //   this.client = client;
  //   this.items = items;
  //   this.note = note;
  //   this.dateOfIssue = dateOfIssue;
  //   this.endDate = endDate;
  //   this.pleace = pleace;
  // }
}
