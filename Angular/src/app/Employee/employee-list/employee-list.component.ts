import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from 'src/app/Shared/Models/Employee';
import { EmployeeService } from 'src/app/Shared/Api/Employee/employee.service';

// class Person {
//   id: number;
//   firstName: string;
//   lastName: string;
// }

// class DataTablesResponse {
//   data: any[];
//   draw: number;
//   recordsFiltered: number;
//   recordsTotal: number;
// }

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  //persons: Person[];
  employees: Employee[]; 

  constructor(private http: HttpClient, private employeeService : EmployeeService) { }

  ngOnInit(): void {
    const that = this;

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      serverSide: true,
      processing: true,
      ajax: (dataTablesParameters: any, callback) => {
        console.log("in aja");
        console.log(dataTablesParameters);
        this.employeeService.employeeWithdeptName(dataTablesParameters).subscribe(resp => {
            console.log(resp);
            that.employees = resp.data;
            console.log(that.employees);

            callback({
              recordsTotal: resp.recordsTotal,
              recordsFiltered: resp.recordsTotal,
              data: []
            });
            //columns: [{ data: 'id' }, { data: 'firstName' }, { data: 'lastName' },{ data: 'id' }, { data: 'firstName' }, { data: 'lastName' }]
          });
         
        }
      //, columns: [{ data: 'id' }, { data: 'firstName' }, { data: 'lastName' }]
    };
  }
}

