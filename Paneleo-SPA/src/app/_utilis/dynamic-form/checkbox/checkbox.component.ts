import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-checkbox',
  template: `
    <div class="demo-full-width margin-top" [formGroup]="group">
      <input type="checkbox" [formControlName]="field.name" />
    </div>
  `,
  styles: []
})
export class CheckboxComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  constructor() {}
  ngOnInit() {}
}
