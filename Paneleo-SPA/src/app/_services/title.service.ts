import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TitleService {
  siteTitle: BehaviorSubject<string> = new BehaviorSubject<string>('');
  constructor() {}

  setTitle(title: string) {
    this.siteTitle.next(title);
  }
}
