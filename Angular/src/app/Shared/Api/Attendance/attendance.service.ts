import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { baseURL } from '../../baseurl';
import { Attendance } from '../../Models/Attendance';
import { BaseService } from '../Base/base-service.service';
import { ProcessHTTPMsgService } from '../process-httpmsg.service';
import { IAttendanceRepository } from './iattendance-repository';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService extends BaseService<Attendance> implements IAttendanceRepository {

  constructor(private httpp : HttpClient,private processHTTPMsgService: ProcessHTTPMsgService) {
    super(httpp,"https://localhost:44370/api/Employees")
  }
  InsertAttendance(att: Attendance) : Observable<any> {
    const httpOptions = {
      headers : new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

    return this.httpp.post(baseURL + 'api/Employees/PresentPlease',att,httpOptions)
    .pipe(catchError(this.processHTTPMsgService.handleError));
  }
  UpdateAttendance(att: Attendance) : Observable<any> {
    const httpOptions = {
      headers : new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

    return this.httpp.post(baseURL + 'api/Employees/GoodByeForToday',att,httpOptions)
    .pipe(catchError(this.processHTTPMsgService.handleError));
  }
}
