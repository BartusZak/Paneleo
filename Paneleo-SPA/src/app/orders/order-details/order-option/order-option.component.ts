import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-order-option',
  templateUrl: './order-option.component.html',
  styleUrls: ['./order-option.component.css']
})
export class OrderOptionComponent implements OnInit {
  @Input() label: string;
  @Input() icon: string;

  constructor() {}

  ngOnInit() {}
}
