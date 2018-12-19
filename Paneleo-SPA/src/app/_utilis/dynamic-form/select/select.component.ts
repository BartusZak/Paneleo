import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-select',
  template: `
    <div class="form-group form-group-height" [formGroup]="group">
      <select class="form-control" [formControlName]="field.name">
        <option *ngFor="let item of field.options" [value]="item">{{
          item
        }}</option>
      </select>
    </div>
  `,
  styles: []
})
export class SelectComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  constructor() {}
  ngOnInit() {}
}

// <mat-form-field class="demo-full-width margin-top" [formGroup]="group">
//   <mat-select [placeholder]="field.label" [formControlName]="field.name">
//     <mat-option *ngFor="let item of field.options" [value]="item">{{
//       item
//     }}</mat-option>
//   </mat-select>
// </mat-form-field>
