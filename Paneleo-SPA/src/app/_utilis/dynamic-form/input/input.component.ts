import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
import { Observable, of } from 'rxjs';
import {
  debounceTime,
  distinctUntilChanged,
  map,
  tap,
  switchMap,
  catchError
} from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';
@Component({
  selector: 'app-input',
  template: `
    <div class="form-group form-group-height" [formGroup]="group">
      <input
        [ngClass]="{
          'is-invalid':
            group.get(field.name).errors && group.get(field.name).touched
        }"
        class="form-control"
        [formControlName]="field.name"
        [placeholder]="field.label"
        [type]="field.inputType"
        [min]="field.min"
        [ngbTypeahead]="search"
      />
      <ng-container *ngFor="let validation of field.validations">
        <div
          class="invalid-feedback"
          *ngIf="
            group.get(field.name).hasError(validation.name) &&
            group.get(field.name).touched
          "
        >
          {{ validation.message }}
        </div>
      </ng-container>
    </div>
  `,
  styles: []
})
export class InputComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  model: any;
  searching = false;
  searchFailed = false;

  constructor(private contractorService: ContractorService) {}

  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => (this.searching = true)),
      switchMap(term =>
    );

  ngOnInit() {}
}
