import { Component, OnInit,AfterViewInit, ViewChild } from '@angular/core';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { Department } from 'src/app/Shared/Models/Department';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/Shared/NotificationService/notification.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

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

    async deleteDepartment(id : number){
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
        await this.departmentServive.Delete(id).subscribe(data => 
        {
          //  this.notifyService.showError("Department deleted successfully !!", "OAS")
          //  this.refresh()
          this.RefreshWithMessage("Department deleted successfully !!",async () =>{
           await this.refresh();  
        })
        ,
        error => this.notifyService.showError(error, "OAS");
        })
      }
      else{
        this.notifyService.showWarning(id+' not found', "OAS");
      }
    }
    private async refresh(){
      await this.departmentServive.getAll().subscribe( data => {
        this.departmetnList = data;
      });
    }

    private RefreshWithMessage(message,callback){
      this.notifyService.showError(message, "OAS");
      if (typeof callback == "function") {
        console.log('in callback');
        callback();
      }
      
    }

  ngOnInit(): void {
    //console.log(JSON.stringify(this.departmetnList));
    this.departmentServive.getAll().subscribe( data => {
        this.departmetnList = data;
    });
  }
  

  
}
