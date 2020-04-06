import { Injectable } from '@angular/core';
import { BaseService } from './Base/base-service.service';
import { Employee } from '../Models/Employee';
import { IEmployeeRepository } from './iemployee-repository';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService<Employee> implements IEmployeeRepository {

  constructor(private httpp : HttpClient) {
    super(httpp,"https://localhost:44370/api/Employees")//, new Employee());
  }
 
}
