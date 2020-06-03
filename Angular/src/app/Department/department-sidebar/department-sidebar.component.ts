import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'department-sidebar',
  templateUrl: './department-sidebar.component.html',
  styleUrls: ['./department-sidebar.component.css']
})
export class DepartmentSidebarComponent implements OnInit {

  constructor(private router : Router) { 
    // this.router.errorHandler = (error: any) => {
    //   this.router.navigate(['departments']); // or redirect to default route
    //   console.log(error);
      
    // }
  }

  ngOnInit(): void {
  }

}
