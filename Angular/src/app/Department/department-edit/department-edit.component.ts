import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute, Params} from '@angular/router';
import { Department } from 'src/app/Shared/Models/Department';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/Shared/NotificationService/notification.service';

@Component({
  selector: 'app-department-edit',
  templateUrl: './department-edit.component.html',
  styleUrls: ['./department-edit.component.css']
})
export class DepartmentEditComponent implements OnInit {

  department_from_get : Department = new Department();
  department : Department;
  departmentEditForm: FormGroup;
  id : number;

  constructor(private formBuilder: FormBuilder,private route : ActivatedRoute, private _departmentService : DepartmentService,private notifyService:NotificationService) { 

  }

  ngOnInit(): void {
    // this.id = this.route.snapshot.paramMap.get('id');
    // this._departmentService.getById(Number(this.id)).subscribe(
    //   (data: any) => { this.department_from_get = data }
    // )
    this.departmentEditForm = this.formBuilder.group({
      Name: ['', Validators.compose([Validators.required])],
      Id: ['', Validators.compose([Validators.required])],
      //CreateDate: ['', Validators.compose([Validators.required])],
      //UpdatedDate: ['', Validators.compose([Validators.required])],
      //IsDelete: ['', Validators.compose([Validators.required])]
    });

    this.route.params.subscribe(params => {
      this.id = params['id'];
      if(this.id){
        this._departmentService.getById(this.id).subscribe((data: any) => 
        { 
          if(data){
            // console.log(data);
            this.department_from_get = data;
            
            this.departmentEditForm.setValue({
              Name: data.name,
              Id: data.id
            });
          }
          else{
            console.log('No data found with id:'+ this.id);
          }
        }
        )
      }
    });
  }

  update(form : any){
    // var data=form.fields;
     this.department = <Department>form; 
     console.log(this.department.Id);
     if(this.department.Id == this.id){
       this._departmentService.edit(this.department).subscribe(
        result => {
          this.notifyService.showInfo("Department updated successfully !!", "OAS")
          //this.redirectToList();
        }, error => console.error(error))
     }
      
  }

}
