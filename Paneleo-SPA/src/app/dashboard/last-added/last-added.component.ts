import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-last-added',
  templateUrl: './last-added.component.html',
  styleUrls: ['./last-added.component.css']
})
export class LastAddedComponent implements OnInit {
  @Input() array: Array<any>;
  @Input() name: string;
  @Input() link: string;

  constructor() {}

  ngOnInit() {}
}
