import { Component, OnInit, ViewChild } from "@angular/core";
import { DynamicFormComponent } from "src/app/_utilis/dynamic-form/dynamic-form.component";
import { FieldConfig } from "src/app/_models/field.interface";
import { Validators } from "@angular/forms";
import { AlertifyService } from "src/app/_services/alertify.service";
import { ContractorService } from "src/app/_services/Contractor/contractor.service";

@Component({
  selector: "app-contractor-add",
  templateUrl: "./contractor-add.component.html",
  styleUrls: ["./contractor-add.component.css"]
})
export class ContractorAddComponent implements OnInit {
  @ViewChild(DynamicFormComponent) form: DynamicFormComponent;
  isCompany = true;
  companyFields: FieldConfig[] = [
    {
      type: "input",
      label: "Nazwa Kontrahenta",
      inputType: "text",
      name: "name",
      validations: [
        {
          name: "required",
          validator: Validators.required,
          message: "Nazwa Kontrahenta jest wymagana!"
        }
      ]
    },
    {
      type: "input",
      label: "NIP",
      inputType: "text",
      name: "nip",
      validations: [
        {
          name: "required",
          validator: Validators.required,
          message: "NIP jest wymagany!"
        }
      ]
    },
    {
      type: "input",
      label: "Imię",
      inputType: "text",
      name: "firstName"
    },
    {
      type: "input",
      label: "Nazwisko",
      inputType: "text",
      name: "lastName"
    },
    {
      type: "input",
      label: "Ulica",
      inputType: "text",
      name: "street"
    },
    {
      type: "input",
      label: "Number ulicy",
      inputType: "text",
      name: "streetNumber"
    },
    {
      type: "input",
      label: "Numer domu",
      inputType: "text",
      name: "houseNumber"
    },
    {
      type: "input",
      label: "Miasto",
      inputType: "text",
      name: "city"
    },
    {
      type: "input",
      label: "Kod pocztowy",
      inputType: "text",
      name: "postCode"
    },
    {
      type: "input",
      label: "Nr tel.",
      inputType: "text",
      name: "phone"
    },
    {
      type: "button",
      label: "Dodaj"
    }
  ];

  privatePersonFields: FieldConfig[] = [
    {
      type: "input",
      label: "Imię",
      inputType: "text",
      name: "firstName",
      validations: [
        {
          name: "required",
          validator: Validators.required,
          message: "Imię jest wymagane!"
        }
      ]
    },
    {
      type: "input",
      label: "Nazwisko",
      inputType: "text",
      name: "lastName",
      validations: [
        {
          name: "required",
          validator: Validators.required,
          message: "Nazwisko jest wymagane!"
        }
      ]
    },
    {
      type: "input",
      label: "Ulica",
      inputType: "text",
      name: "street"
    },
    {
      type: "input",
      label: "Number ulicy",
      inputType: "text",
      name: "streetNumber"
    },
    {
      type: "input",
      label: "Numer domu",
      inputType: "text",
      name: "houseNumber"
    },
    {
      type: "input",
      label: "Miasto",
      inputType: "text",
      name: "city"
    },
    {
      type: "input",
      label: "Kod pocztowy",
      inputType: "text",
      name: "postCode"
    },
    {
      type: "input",
      label: "Nr tel.",
      inputType: "text",
      name: "phone"
    },
    {
      type: "button",
      label: "Dodaj"
    }
  ];

  constructor(
    private alertify: AlertifyService,
    private contractorService: ContractorService
  ) {}

  ngOnInit() {
    this.contractorService.getContractorByNip(7171642051).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }

  submit(value: any) {
    this.contractorService.addContractor(value).subscribe(
      () => {
        this.alertify.success("Dodano nowego Kontrahenta!");
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  handleRadioInputChange() {
    this.isCompany = !this.isCompany;
  }
}
