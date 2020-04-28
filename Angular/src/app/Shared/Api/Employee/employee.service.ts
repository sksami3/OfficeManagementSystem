import { Injectable } from '@angular/core';
import { IEmployeeRepository } from './iemployee-repository';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../Base/base-service.service';
import { Employee } from '../../Models/Employee';
import { Observable } from 'rxjs';
import { DataTablesResponse } from '../../Models/DataTablesResponse';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService<Employee> implements IEmployeeRepository {

  constructor(private httpp : HttpClient) {
    super(httpp,"https://localhost:44370/api/Employees")
  }
  employeeWithdeptName(something : any) : any {
    console.log("calling new m");
    return this.httpp.post("https://localhost:44370/api/Employees/GetEmployeesPost",something);
    // return this.httpp.get<DataTablesResponse>("https://localhost:44370/api/Employees/GetEmployeesPost/"+  `${something}`);
  }
  


}
