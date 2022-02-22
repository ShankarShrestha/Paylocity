import { Component, OnInit } from '@angular/core';
import { EmployeeDependentServiceService } from "../../services/employee-dependent-service.service";

import { TransportService } from 'src/app/services/transport.service';



@Component({
  selector: 'app-detail-result',
  templateUrl: './detail-result.component.html',
  styleUrls: ['./detail-result.component.css']
})
export class DetailResultComponent implements OnInit {

  CalculatedDeductions: any[] = []; 
  constructor(private employeeDependentService: EmployeeDependentServiceService,
      private transport: TransportService
    ) { }

  ngOnInit(): void {
    this.transport.sendMessage.subscribe((message) => {
      this.CalculatedDeductions.push(message)
      //console.log(this.CalculatedDeductions[0][0].EmployeeDeduction)
    })
  }

}
