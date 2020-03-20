import { Component, OnInit, OnDestroy } from '@angular/core';
import { Department } from 'src/app/Shared/Models/Department';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-department-post',
  templateUrl: './department-post.component.html',
  styleUrls: ['./department-post.component.css']
})
export class DepartmentPostComponent implements OnInit,OnDestroy {

  sub : Subscription;
  department : Department;

  constructor(private departmentService : DepartmentService, private router : Router, private route: ActivatedRoute) {
  }

  save(form : any){
    // var data=form.fields;
     this.department = <Department>form;
    //  this.department.CreateDate = new Date();
    //  this.department.UpdatedDate = new Date();
    //  this.department.IsDelete = false;     
      this.departmentService.Insert(this.department).subscribe(
        result => {
          console.log('In result');
          this.redirectToList();
      }, error => console.error(error))
  }


  ngOnDestroy(): void {
    throw new Error("Method not implemented.");
  }

  ngOnInit(): void {
    
  }

  redirectToList(){
    console.log('In redirectToList');
    this.router.navigate(['api/departments'], {relativeTo: this.route});
  }

}
