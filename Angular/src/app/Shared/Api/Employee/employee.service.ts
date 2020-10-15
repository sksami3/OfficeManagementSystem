import { Injectable } from '@angular/core';
import { IEmployeeRepository } from './iemployee-repository';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseService } from '../Base/base-service.service';
import { Employee } from '../../Models/Employee';
import { Observable } from 'rxjs';
import { DataTablesResponse } from '../../Models/DataTablesResponse';
import { Attendance } from '../../Models/Attendance';
import { baseURL } from '../../baseurl';
import { catchError } from 'rxjs/operators';
import { ProcessHTTPMsgService } from '../process-httpmsg.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService<Employee> implements IEmployeeRepository {

  constructor(private httpp : HttpClient,private processHTTPMsgService: ProcessHTTPMsgService) {
    super(httpp,"https://localhost:44370/api/Employees/")
  }
  getTodaysAttendanceInformationByUsername(username: string): Observable<Attendance> {
    const httpOptions = {
      headers : new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

    return this.httpp.post<Attendance>(baseURL + 'api/Employees/GetTodaysAttendanceInformationByUsername?username='+username,httpOptions)
    .pipe(catchError(this.processHTTPMsgService.handleError));
  }
  employeeWithdeptName(employee : Employee) : Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      })
  };
    return this.httpp.post("https://localhost:44370/api/Employees/GetEmployeesPost",employee,httpOptions)
    .pipe(catchError(this.processHTTPMsgService.handleError));;
    // return this.httpp.get<DataTablesResponse>("https://localhost:44370/api/Employees/GetEmployeesPost/"+  `${something}`);
  }
  


}
