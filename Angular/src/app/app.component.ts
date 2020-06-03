
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Department } from 'src/app/Shared/Models/Department';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { NotificationService } from 'src/app/Shared/NotificationService/notification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Office-Attendence-System';

  constructor(private departmentService : DepartmentService, private router : Router, private route: ActivatedRoute, private notifyService: NotificationService ) {
    this.router.errorHandler = (error: any) => {
      this.router.navigate(['departments']); // or redirect to default route
      console.log(error);
      
    }
  }
  
}

