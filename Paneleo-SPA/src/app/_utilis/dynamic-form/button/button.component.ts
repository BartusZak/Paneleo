import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-button',
  template: `
    <div class="form-group text-center" [formGroup]="group">
      <button type="submit" class="btn btn-success" [disabled]="!group.valid">
        {{ field.label }}
      </button>
    </div>
  `,
  styles: []
})
export class ButtonComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  constructor() {}
  ngOnInit() {}
}
