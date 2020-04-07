import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from 'src/app/Shared/Models/Employee';

@Component({
  selector: 'app-employee-post',
  templateUrl: './employee-post.component.html',
  styleUrls: ['./employee-post.component.css']
})
export class EmployeePostComponent implements OnInit {

  //#region initialization
  employeeForm: FormGroup;
  post: any;
  employee: Employee;
  deptnames : Array<string> = ['','dept1','dept2', 'dept3'];
  //#endregion


  constructor(fb : FormBuilder) {
    this.employeeForm = fb.group({
      'departmentList':[null, Validators.required]
    });
  }

  ngOnInit(): void {
  }

  AddEmployee(post): void{
    
  }

}
