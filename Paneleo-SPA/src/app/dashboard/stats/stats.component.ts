import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  @Input() contractorsCount: number;
  @Input() productsCount: number;
  @Input() totalOrdersValue: number;
  @Input() ordersCount: number;

  constructor() {}

  ngOnInit() {}
}
