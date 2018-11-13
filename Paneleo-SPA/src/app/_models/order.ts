export class Order {
  id: number;
  note: string;
  client: string;
  items: Array<{ id: number; text: string }>;
  dateOfIssue: Date;
  dateOfSell: Date;
  endDate: Date;
  pleace: string;

  constructor(
    id: number,
    note: string,
    client: string,
    items: Array<{ id: number; text: string }>,
    dateOfIssue: Date,
    endDate: Date,
    pleace: string
  ) {
    this.id = id;
    this.client = client;
    this.items = items;
    this.note = note;
    this.dateOfIssue = dateOfIssue;
    this.endDate = endDate;
    this.pleace = pleace;
  }
}
