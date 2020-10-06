import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { DepartmentListComponent } from './Department/department-list/department-list.component';
import { DepartmentService } from './Shared/Api/department.service';
import { DepartmentPostComponent } from './Department/department-post/department-post.component';
import { DepartmentEditComponent } from './Department/department-edit/department-edit.component';
//import { DepartmentHeaderComponent } from './Department/department-header/department-header.component';
import { PageNotFoundComponent } from './Department/page-not-found/page-not-found.component';
import { HomeComponent } from './Home/home/home.component';

// adding rout
import { RouterModule, Routes } from '@angular/router';
//import { DepartmentSidebarComponent } from './Department/department-sidebar/department-sidebar.component';
import { EmployeePostComponent } from './Employee/employee-post/employee-post.component';
import { EmployeeListComponent } from './Employee/employee-list/employee-list.component';


const appRoutes: Routes = 
[
  { 
    path: '',
     component: HomeComponent 
  },
  { 
    path: 'Home',
     component: HomeComponent 
  },
  { 
    path: 'departments',      
    component: DepartmentListComponent,
  },
  {
    path: 'EditDepartment/:id',
    component: DepartmentEditComponent
    
  },
  {
    path: 'PostDepartment',
    component: DepartmentPostComponent
    
  },
  {
    path: 'PostEmployee',
    component: EmployeePostComponent
    
  },
  {
    path: 'Employees',
    component: EmployeeListComponent
    
  },
  
  { path: '**', component: PageNotFoundComponent }
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(
      appRoutes
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
