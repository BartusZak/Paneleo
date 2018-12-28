import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-radiobutton',
  template: `
    <div [formGroup]="group">
      <div
        *ngFor="let item of field.options"
        class="form-check form-check-inline"
      >
        <input
          class="form-check-input"
          type="radio"
          [formControlName]="field.name"
          [id]="item"
          [value]="item"
        />
        <label class="form-check-label" [for]="item">{{ item }}</label>
      </div>
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
