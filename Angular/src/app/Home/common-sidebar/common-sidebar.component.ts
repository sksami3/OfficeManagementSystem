import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'common-sidebar',
  templateUrl: './common-sidebar.component.html',
  styleUrls: ['./common-sidebar.component.css']
})
export class CommonSidebarComponent implements OnInit {

  constructor(private router : Router) { 
    // this.router.errorHandler = (error: any) => {
    //   this.router.navigate(['commons']); // or redirect to default route
    //   console.log(error);
      
    // }
  }

  ngOnInit(): void {
  }

}
