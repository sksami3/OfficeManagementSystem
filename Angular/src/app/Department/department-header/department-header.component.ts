import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-department-header',
  templateUrl: './department-header.component.html',
  styleUrls: ['./department-header.component.css']
})
export class DepartmentHeaderComponent implements OnInit {

  logo = "assets/logo.png";
  constructor() { }

  ngOnInit(): void {
  }

}
