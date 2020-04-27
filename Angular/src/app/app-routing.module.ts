import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DepartmentListComponent } from './Department/department-list/department-list.component';
import { DepartmentService } from './Shared/Api/department.service';
import { DepartmentEditComponent } from './Department/department-edit/department-edit.component';
import { DepartmentHeaderComponent } from './Department/department-header/department-header.component';
import { PageNotFoundComponent } from './Department/page-not-found/page-not-found.component';
import { HomeComponent } from './Home/home/home.component';

// adding rout
import { RouterModule, Routes } from '@angular/router';
import { DepartmentPostComponent } from './Department/department-post/department-post.component';
import { DepartmentSidebarComponent } from './Department/department-sidebar/department-sidebar.component';
import { EmployeePostComponent } from './Employee/employee-post/employee-post.component';


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
  
  { path: '**', component: PageNotFoundComponent }
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
