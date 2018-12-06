import { Component, OnInit, ViewChild } from '@angular/core';
import { DynamicFormComponent } from 'src/app/_utilis/dynamic-form/dynamic-form.component';
import { FieldConfig } from 'src/app/_models/field.interface';
import { Validators } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';

@Component({
  selector: 'app-contractor-add',
  templateUrl: './contractor-add.component.html',
  styleUrls: ['./contractor-add.component.css']
})
export class ContractorAddComponent implements OnInit {
  @ViewChild(DynamicFormComponent) form: DynamicFormComponent;
  regConfig: FieldConfig[] = [
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
      type: 'input',
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
      type: 'button',
      label: 'Dodaj'
    }
  ];

  constructor(
    private alertify: AlertifyService,
    private contractorService: ContractorService
  ) {}

  ngOnInit() {}

  submit(value: any) {
    this.contractorService.addContractor(value).subscribe(
      () => {
        this.alertify.success('Dodano nowego Kontrahenta!');
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
