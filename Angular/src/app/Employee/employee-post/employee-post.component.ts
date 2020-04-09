import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from 'src/app/Shared/Models/Employee';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { EmployeeService } from 'src/app/Shared/Api/Employee/employee.service';
import { Department } from 'src/app/Shared/Models/Department';
import { error } from '@angular/compiler/src/util';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { typeSourceSpan } from '@angular/compiler';
import { NotificationService } from 'src/app/Shared/NotificationService/notification.service';

@Component({
  selector: 'app-employee-post',
  templateUrl: './employee-post.component.html',
  styleUrls: ['./employee-post.component.css'],
  animations: [
    trigger('toggleHeight', [
      state('hide', style({
        height: '0px',
        opacity: '0',
        overflow: 'hidden',
        // display: 'none'
      })),
      state('show', style({
        height: '*',
        opacity: '1',
        // display: 'block'
      })),
      transition('hide => show', animate('300ms ease-in')),
      transition('show => hide', animate('300ms ease-out'))
    ])
  ],
})
export class EmployeePostComponent implements OnInit {

  //#region initialization
  employeeForm: FormGroup;
  post: any;
  dropdownSelectedValue: any;
  isShow: any;
  employee: Employee;
  deptnames: Array<Department>;
  selectedDate: Date;

  _departmentService: DepartmentService;
  _employeeService: EmployeeService;

  isRequiredValidator: string = " is required";
  //#region initialization end

  constructor(private fb: FormBuilder, private departmentService: DepartmentService, private employeeService: EmployeeService, private notifyService: NotificationService) {
    this.employeeForm = fb.group({
      'departmentList': [null, Validators.required],
      'name': [null, [Validators.required, Validators.maxLength(20), Validators.minLength(3)]],
      'dob': [null, Validators.required],
      'age': [],
      'email': [null, Validators.required],
      'contactnumber': [null, Validators.required],
      'salary': [null, Validators.required],
      'joiningdate': [null, Validators.required]

    });
    this._departmentService = departmentService;
    this._employeeService = employeeService;
  }

  ngOnInit(): void {
    this.isShow = 'hide';

    this._departmentService.getAll().subscribe(data => {
      if (data) {
        this.deptnames = data;
        console.log(this.deptnames);
      }
      else {
        console.error(error);
      }
    })
  }

  AddEmployee(post): void {
    let e = new Employee();
    // this.employee = <Employee>post;
    console.log(post.dateofbirth);
    e.Age = post.age;
    e.ContactNumber = post.contactnumber;
    e.DateOfBirth = new Date;//post.dob;
    e.DepartmentId = post.departmentList;
    e.Email = post.email;
    e.JoiningDate = new Date;//post.joiningdate;
    e.Name = post.name;
    e.Salary = post.salary;

    this._employeeService.Insert(e).subscribe(data => {
      if(data){
        console.log("In data"+data);
        this.notifyService.showSuccess("Employee added successfully !!", "OAS")
        this.employeeForm.reset();
      }
      else{
        console.log(data);
      }
    },
    error => console.log(error)
    //this.notifyService.showError(error, "OAS"),
    )
  }

  onDateSelect(selectedDate): void {
    //console.log(selectedDate.day + selectedDate.year + selectedDate.month);
    let now = new Date();
    let age = Math.abs(Number(now.getFullYear()) - Number(selectedDate.year));
    this.employeeForm.get('age').setValue(age);
  }

  onChange(dropdownSelectedValue) {

    console.log(dropdownSelectedValue);
    if (dropdownSelectedValue.length != 0) {
      this.isShow = 'show';
    }
    else {
      this.isShow = 'hide';
    }
    //isShow = (isShow==='show')? 'hide' : 'show'"
  }


  closeDatepicker(id){
    id.close();
  }

}
