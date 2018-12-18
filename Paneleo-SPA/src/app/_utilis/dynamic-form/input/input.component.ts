import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
import { Observable, of } from 'rxjs';
import {
  debounceTime,
  distinctUntilChanged,
  tap,
  switchMap,
  catchError
} from 'rxjs/operators';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';
import { NgbTypeaheadConfig } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-input',
  template: `
    <ng-template #rt let-r="result" let-t="term">
      <ngb-highlight [result]="r.name" [term]="t"></ngb-highlight>
    </ng-template>

    <div class="form-group form-group-height" [formGroup]="group">
      <input
        *ngIf="!field.typeahead"
        [ngClass]="{
          'is-invalid':
            group.get(field.name).errors && group.get(field.name).touched
        }"
        class="form-control"
        [formControlName]="field.name"
        [placeholder]="field.label"
        [type]="field.inputType"
        [min]="field.min"
        [value]="field.default"
      />
      <input
        *ngIf="field.typeahead"
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
        [class.is-invalid]="searchFailed"
        [resultTemplate]="rt"
        [inputFormatter]="formatter"
      />
      <span *ngIf="searching">wyszukiwanie...</span>
      <div class="invalid-feedback" *ngIf="searchFailed">Nie znaleziono.</div>
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
  searching = false;
  searchFailed = false;

  constructor(config: NgbTypeaheadConfig) {
    config.showHint = true;
  }

  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      tap(() => (this.searching = true)),
      switchMap(term =>
        this.field.typeahead(term).pipe(
          tap(() => (this.searchFailed = false)),
          catchError(() => {
            this.searchFailed = true;
            return of([]);
          })
        )
      ),
      tap(() => (this.searching = false))
      // tslint:disable-next-line:semicolon
    );

  formatter = (x: { name: string }) => x.name;

  ngOnInit() {
    if (this.field.default) {
      this.group.value[this.field.name] = this.field.default;
    }
  }
}
