import { Entity } from './entity';

export class Contractor extends Entity {
  isCompany: boolean;
  nip: string;
  name: string;
  firstName: string;
  lastName: string;
  street: string;
  streetNumber: string;
  houseNumber: string;
  city: string;
  postCode: string;
  postCity: string;
  phone: string;
  email: string;
  www: string;
}
