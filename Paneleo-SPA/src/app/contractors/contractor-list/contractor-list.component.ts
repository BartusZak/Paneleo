import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contractor-list',
  templateUrl: './contractor-list.component.html',
  styleUrls: ['./contractor-list.component.css']
})
export class ContractorListComponent implements OnInit {
  contractorsColumns = [
    { prop: 'id', summaryFunc: () => null },
    { prop: 'name', name: 'Nazwa', summaryFunc: () => null },
    { prop: 'nip', name: 'NIP', summaryFunc: () => null }
  ];
  constructor() {}

  ngOnInit() {}
}
