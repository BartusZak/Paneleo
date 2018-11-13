export class Order {
  id: number;
  note: string;
  //   dateOfIssue: Date;
  //   dateOfSell: Date;
  //   endDate: Date;
  //   pleace: string;

  constructor(
    id: number,
    note: string
    // dateOfIssue: Date,
    // endDate: Date,
    // pleace: string
  ) {
    this.id = id;
    this.note = note;
    // this.dateOfIssue = dateOfIssue;
    // this.endDate = endDate;
    // this.pleace = pleace;
  }
}
