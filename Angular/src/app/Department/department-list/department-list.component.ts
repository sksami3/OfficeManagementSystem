import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { Department } from 'src/app/Shared/Models/Department';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  Title = "Department List";
  departmetnList: any= Array<Department>();
  constructor(private departmentServive : DepartmentService) {
      console.log("In Constructor");
      //this.departmetnList = departmentServive.getAll().subscribe(res=>this.departmetnList=res);
   }

   columnsToDisplay = ['name'];

  ngOnInit(): void {
    console.log("ngOnInit");
    //console.log(JSON.stringify(this.departmetnList));
    this.departmentServive.getAll().subscribe( data => {
        this.departmetnList = data;
    });

    
  }
  

  
}
