import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-radiobutton',
  template: `
    <div
      class="form-check form-check-inline"
      [formGroup]="group"
      [formControlName]="field.name"
    >
      <label class="radio-inline" *ngFor="let item of field.options"
        ><input [value]="field.value" type="radio" />{{ field.label }}</label
      >
    </div>
  `,
  styles: []
})
export class RadiobuttonComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  constructor() {}
  ngOnInit() {}
}

// <mat-radio-group [formControlName]="field.name">
// <mat-radio-button *ngFor="let item of field.options" [value]="item">{{
//   item
// }}</mat-radio-button>
// </mat-radio-group>
