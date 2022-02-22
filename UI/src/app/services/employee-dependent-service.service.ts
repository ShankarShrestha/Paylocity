import { Injectable } from '@angular/core';
import { Observable, observable} from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";


import { DeductionDetail } from "../DeductionDetail";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class EmployeeDependentServiceService {

  private apiUrl = 'https://localhost:44338/api/EmployeeDependent';

  constructor(private http: HttpClient) { }


  //getDeductions() :Observable< DeductionDetail[]> {
    //const deductionDetail = of(DeductionDetails)
    //return deductionDetail;
    //return this.http.get<DeductionDetail[]>(this.apiUrl)
  //}

  addEmployeeDepedentDetail(empDepDetail: any): Observable<any[]>{
    return this.http.post<any[]>(this.apiUrl, JSON.stringify(empDepDetail) , httpOptions)
  }


}
