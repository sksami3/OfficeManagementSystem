import { Component, OnInit, OnDestroy } from '@angular/core';
import { Department } from 'src/app/Shared/Models/Department';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-department-post',
  templateUrl: './department-post.component.html',
  styleUrls: ['./department-post.component.css']
})
export class DepartmentPostComponent implements OnInit,OnDestroy {

  sub : Subscription;
  de : Department;

  constructor(private departmentService : DepartmentService, private router : Router) {
  }

  save(form : any){
    // var data=form.fields;
    this.de = <Department>form;
    console.log(this.de);
      this.departmentService.Insert(this.de).subscribe(
        result => {
          this.redirectToList();
      }, error => console.log(error))
  }


  ngOnDestroy(): void {
    throw new Error("Method not implemented.");
  }

  ngOnInit(): void {
    
  }

  redirectToList(){
    this.router.navigate['api/departments'];
  }

}
