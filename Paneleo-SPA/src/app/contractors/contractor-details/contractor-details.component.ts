import { Component, OnInit } from '@angular/core';
import { Contractor } from 'src/app/_models/contractor';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { OrderService } from 'src/app/_services/Order/order.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contractor-details',
  templateUrl: './contractor-details.component.html',
  styleUrls: ['./contractor-details.component.css']
})
export class ContractorDetailsComponent implements OnInit {
  public contractor: Contractor;
  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.contractor = data['contractor'].successResult;
      console.log(data);
    });
  }
}
