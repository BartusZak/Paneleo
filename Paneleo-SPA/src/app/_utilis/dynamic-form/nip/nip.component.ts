import { Component, OnInit, ChangeDetectorRef, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-nip',
  templateUrl: './nip.component.html',
  styleUrls: ['./nip.component.css']
})
export class NipComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  searchFailed = false;
  nipError = '';

  constructor(
    private contractorService: ContractorService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {}

  onGusButtonClick(event) {
    event.preventDefault();
    event.stopPropagation();
    this.contractorService.getContractorByNip(this.group.value.nip).subscribe(
      data => {
        const contractorFromGus = data.successResult;
        this.group.patchValue({
          name: contractorFromGus.name,
          firstName: contractorFromGus.firstName,
          lastName: contractorFromGus.lastName,
          street: contractorFromGus.street,
          streetNumber: contractorFromGus.streetNumber,
          houseNumber: contractorFromGus.houseNumber,
          city: contractorFromGus.city,
          postCode: contractorFromGus.postCode,
          phone: contractorFromGus.phone
        });
        this.alertify.success('Wczytano Kontrahenta!');
        this.searchFailed = false;
      },
      error => {
        this.nipError = error.slice(0, -5);
        this.searchFailed = true;
        this.alertify.error(error);
      }
    );
  }
}
