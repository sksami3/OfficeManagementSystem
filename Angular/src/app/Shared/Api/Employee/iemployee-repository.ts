import { IBaseRepository } from '../Base/ibase-repository';
import { Employee } from '../../Models/Employee';
import { Observable } from 'rxjs';


export interface IEmployeeRepository extends IBaseRepository<Employee> {
    employeeWithdeptName(filterdata:any): any;
}
