import { Component, OnInit } from '@angular/core';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';

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
  constructor(private contractorService: ContractorService) {}

  ngOnInit() {}

  getContractors = atrib => {
    return this.contractorService.getContractors(atrib.limit, ++atrib.offset);
    // tslint:disable-next-line:semicolon
  };
}
