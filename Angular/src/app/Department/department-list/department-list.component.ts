import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/Shared/Api/department.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  Title = "Department List";
  departmetnList;
  constructor(private departmentServive : DepartmentService) {
      this.departmetnList = departmentServive.getAll();
   }

  ngOnInit(): void {
  }

  
}
