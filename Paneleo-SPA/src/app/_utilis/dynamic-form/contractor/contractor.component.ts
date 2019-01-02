import { Component, OnInit, ViewChild } from '@angular/core';
import { Validators, FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
import { DynamicFormComponent } from '../dynamic-form.component';
import { Contractor } from 'src/app/_models/contractor';

@Component({
  selector: 'app-contractor',
  templateUrl: './contractor.component.html',
  styleUrls: ['./contractor.component.css']
})
export class ContractorComponent implements OnInit {
  @ViewChild(DynamicFormComponent) form: DynamicFormComponent;

  field: FieldConfig;
  group: FormGroup;
  contractor: Contractor;
  isCompany = true;
  companyFields: FieldConfig[] = [
    {
      type: 'input',
      label: 'Nazwa Kontrahenta',
      inputType: 'text',
      name: 'name',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'Nazwa Kontrahenta jest wymagana!'
        }
      ]
    },
    {
      type: 'nip',
      label: 'NIP',
      inputType: 'text',
      name: 'nip',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'NIP jest wymagany!'
        }
      ]
    },
    {
      type: 'input',
      label: 'Imię',
      inputType: 'text',
      name: 'firstName'
    },
    {
      type: 'input',
      label: 'Nazwisko',
      inputType: 'text',
      name: 'lastName'
    },
    {
      type: 'input',
      label: 'Ulica',
      inputType: 'text',
      name: 'street'
    },
    {
      type: 'input',
      label: 'Nr ulicy',
      inputType: 'text',
      name: 'streetNumber'
    },
    {
      type: 'input',
      label: 'Nr domu',
      inputType: 'text',
      name: 'houseNumber'
    },
    {
      type: 'input',
      label: 'Kod pocztowy',
      inputType: 'text',
      name: 'postCode'
    },
    {
      type: 'input',
      label: 'Miasto',
      inputType: 'text',
      name: 'city'
    },
    {
      type: 'input',
      label: 'Nr tel.',
      inputType: 'text',
      name: 'phone'
    }
  ];
  formattedMessage: string;
  privatePersonFields: FieldConfig[] = [
    {
      type: 'input',
      label: 'Imię',
      inputType: 'text',
      name: 'firstName',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'Imię jest wymagane!'
        }
      ]
    },
    {
      type: 'input',
      label: 'Nazwisko',
      inputType: 'text',
      name: 'lastName',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'Nazwisko jest wymagane!'
        }
      ]
    },
    {
      type: 'input',
      label: 'Ulica',
      inputType: 'text',
      name: 'street'
    },
    {
      type: 'input',
      label: 'Number ulicy',
      inputType: 'text',
      name: 'streetNumber'
    },
    {
      type: 'input',
      label: 'Numer domu',
      inputType: 'text',
      name: 'houseNumber'
    },
    {
      type: 'input',
      label: 'Kod pocztowy',
      inputType: 'text',
      name: 'postCode'
    },
    {
      type: 'input',
      label: 'Miasto',
      inputType: 'text',
      name: 'city'
    },
    {
      type: 'input',
      label: 'Nr tel.',
      inputType: 'text',
      name: 'phone'
    }
  ];

  constructor() {}

  ngOnInit() {}

  updateContractor = (value: any) => {
    this.group.patchValue({ contractor: value });
    // tslint:disable-next-line:semicolon
  };

  handleRadioInputChange() {
    this.isCompany = !this.isCompany;
  }
}
