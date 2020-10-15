import { IBaseRepository } from '../Base/ibase-repository';
import { Employee } from '../../Models/Employee';
import { Observable } from 'rxjs';
import { Attendance } from '../../Models/Attendance';


export interface IEmployeeRepository extends IBaseRepository<Employee> {
    employeeWithdeptName(filterdata:any): any;

    getTodaysAttendanceInformationByUsername(username:string): Observable<Attendance>;
}
