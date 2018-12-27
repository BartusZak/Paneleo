import { Component, OnInit, ChangeDetectorRef } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { FieldConfig } from "src/app/_models/field.interface";
import { ContractorService } from "src/app/_services/Contractor/contractor.service";

@Component({
  selector: "app-nip",
  templateUrl: "./nip.component.html",
  styleUrls: ["./nip.component.css"]
})
export class NipComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;

  constructor(
    private contractorService: ContractorService,
    private ref: ChangeDetectorRef
  ) {}

  ngOnInit() {}

  onGusButtonClick(event) {
    event.preventDefault();
    event.stopPropagation();
    this.contractorService.getContractorByNip(this.group.value.nip).subscribe(
      data => {
        console.log(data);
        this.group.value.name = data.successResult.name;
        this.group.value.firstName = data.successResult.firstName;
        console.log(this.group.value);
        this.ref.detectChanges();
      },
      error => {
        console.log(error);
      }
    );
  }
}
