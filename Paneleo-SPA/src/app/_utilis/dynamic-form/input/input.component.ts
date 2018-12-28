import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
import { Observable, of } from 'rxjs';
import {
  debounceTime,
  distinctUntilChanged,
  tap,
  switchMap,
  catchError,
  map
} from 'rxjs/operators';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';
import { NgbTypeaheadConfig } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
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
      tap(() => (this.searching = false)),
      tap(data => {})
      // tslint:disable-next-line:semicolon
    );

  formatter = (x: { name: string }) => x.name;

  ngOnInit() {}
}
