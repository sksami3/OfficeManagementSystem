import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { Department } from 'src/app/Shared/Models/Department';
import { Router } from '@angular/router';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  Title = "Department List";
  departmetnList: any= Array<Department>();
  constructor(private departmentServive : DepartmentService, private router: Router) {
      console.log("In Constructor");
      //this.departmetnList = departmentServive.getAll().subscribe(res=>this.departmetnList=res);
   }

   columnsToDisplay = ['id','name','actions'];

   editDepartment(){
     console.log("Edit department");
      this.router.navigate(['']);
    }

  ngOnInit(): void {
    console.log("ngOnInit");
    //console.log(JSON.stringify(this.departmetnList));
    this.departmentServive.getAll().subscribe( data => {
        this.departmetnList = data;
    });

    
  }
  

  
}
