import { IBaseRepository } from './Base/ibase-repository';
import { Employee } from '../Models/Employee';

export interface IEmployeeRepository extends IBaseRepository<Employee> {
}
