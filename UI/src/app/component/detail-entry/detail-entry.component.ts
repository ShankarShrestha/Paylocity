import { Component, OnInit } from '@angular/core';
import { EmployeeDependentServiceService } from "../../services/employee-dependent-service.service";
import { FormArray, FormBuilder,FormGroup,Validators } from '@angular/forms';
import { TransportService } from 'src/app/services/transport.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detail-entry',
  templateUrl: './detail-entry.component.html',
  styleUrls: ['./detail-entry.component.css']
})
export class DetailEntryComponent implements OnInit {
  
  constructor(private employeeDependentService: EmployeeDependentServiceService, 
    private fb:FormBuilder,
    private transportService : TransportService,
    private _router: Router
    ) { }

  userForm = this.fb.group({
    Employees: this.fb.group({
      Name: ["", Validators.required],
      yearlySalary: ["", Validators.required],
    }),
   
    Dependents: this.fb.array([])
  })

  dependentType: string[] = ["Spouse", "Children"];

  CalculatedDeductions: any[] = [];  //this will contain all the returned value from API

  ngOnInit() : void {

  }

  
  clearField(){
    this.userForm.reset();
  }

  onSubmit(){
    this.employeeDependentService.addEmployeeDepedentDetail(this.userForm.value).subscribe((result) => {
      this.transportService.communicateMessage(result);
    });

    //navigate to result compnent 
    this._router.navigate(['result']);
  }

  get userName(){
    return this.userForm.get("userName");
  }

  addDependent(){
    this.Dependents.push(this.fb.group({Name: '', Type: ''}));
  }

  get Dependents(){
    return this.userForm.get("Dependents") as FormArray;
  }

  onRemoveDependent(depIndex: number){
    this.Dependents.removeAt(depIndex);
  }


}
