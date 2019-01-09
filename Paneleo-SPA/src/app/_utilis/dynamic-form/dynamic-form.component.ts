import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';

@Component({
  exportAs: 'dynamicForm',
  // tslint:disable-next-line:component-selector
  selector: 'dynamic-form',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.css']
})
export class DynamicFormComponent implements OnInit {
  @Input() fields: FieldConfig[] = [];
  @Input() updateContractor: any;
  @Output() submit: EventEmitter<any> = new EventEmitter<any>();

  form: FormGroup;

  get value() {
    return this.form.value;
  }

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.form = this.createControl();
    this.onChanges();
  }

  onChanges(): void {
    this.form.valueChanges.subscribe(val => {
      if (this.updateContractor) {
        this.updateContractor(this.form.value);
      }
    });
  }

  onSubmit(event: Event) {
    event.preventDefault();
    event.stopPropagation();
    if (this.form.valid) {
      console.log(this.form.value);
      this.submit.emit(this.form.value);
    } else {
      this.validateAllFormFields(this.form);
    }
  }

  createControl() {
    const group = this.fb.group({});
    this.fields.forEach(field => {
      // tslint:disable-next-line:curly
      if (field.type === 'button') return;
      const control = this.fb.control(
        field.default ? (field.value = field.default) : field.value,
        this.bindValidations(field.validations || [])
      );
      group.addControl(field.name, control);
      if (field.name === 'products') {
        group.addControl('netCost', control);
        group.addControl('grossCost', control);
      }
    });
    if (group.controls['orderDate']) {
      group.controls['orderDate'].disable();
    }
    return group;
  }

  bindValidations(validations: any) {
    if (validations.length > 0) {
      const validList = [];
      validations.forEach(valid => {
        validList.push(valid.validator);
      });
      return Validators.compose(validList);
    }
    return null;
  }

  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      control.markAsTouched({ onlySelf: true });
    });
  }
}
