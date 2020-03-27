import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { Department } from 'src/app/Shared/Models/Department';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/Shared/NotificationService/notification.service';


@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  Title = "Department List";
  departmetnList: any= Array<Department>();
  constructor(private departmentServive : DepartmentService, private router: Router, private notifyService: NotificationService) {
      console.log("In Constructor");
      //this.departmetnList = departmentServive.getAll().subscribe(res=>this.departmetnList=res);
   }

   columnsToDisplay = ['id','name','edit','delete'];

   editDepartment(id : number){
      this.router.navigate(['/EditDepartment/'+id]);
      
    }

    deleteDepartment(id : number){
      console.log('delete id: '+id);
      if(id){
        // this.departmentServive.getById(id).subscribe((data: any) => 
        // { 
        //   if(data){
        //     if(data){
        //       data.isdelete = false;
        //       this.departmentServive.edit(data).subscribe(
        //        result => {
        //          console.log(result);
        //          //this.redirectToList();
        //        }, error => console.error(error))
        //     }
        //   }
        //   else{
        //     console.log('No data found with id:'+ id);
        //   }
        // }
        // )
        this.departmentServive.Delete(id).subscribe(data => 
          {
           this.notifyService.showError("Department deleted successfully !!", "OAS")
          //  setTimeout(() => 
          //   {
          //       this.router.navigate(['/departments']);
          //   },
          //   5000)
          this.refresh()
          
        ,
        error => console.error(error)
        })
      }

      
    }

    private refresh() {
      this.departmentServive.getAll().subscribe( data => {
        this.departmetnList = data;
    });
    }

  ngOnInit(): void {
    //console.log(JSON.stringify(this.departmetnList));
    this.departmentServive.getAll().subscribe( data => {
        this.departmetnList = data;
    });
  }
  

  
}
