import { Base } from './Base';

export class Employee extends Base{

    data?: any[];
    draw?: number;
    recordsFiltered?: number;
    recordsTotal?: number;

    Name? : string;
    Age? : number;
    Salary? : number;
    JoiningDate? : Date;
    DateOfBirth? : Date;
    DepartmentId? : number;
    Email? : string;
    ContactNumber : number;

    DepartmentName? : string;
}