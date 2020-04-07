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
import {MatTableModule} from '@angular/material/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// adding rout
import { RouterModule, Routes } from '@angular/router';
import { DepartmentPostComponent } from './Department/department-post/department-post.component';
import { DepartmentSidebarComponent } from './Department/department-sidebar/department-sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { EmployeePostComponent } from './Employee/employee-post/employee-post.component';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    DepartmentListComponent,
    DepartmentEditComponent,
    DepartmentHeaderComponent,
    HomeComponent,
    DepartmentPostComponent,
    DepartmentSidebarComponent,
    EmployeePostComponent   
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatTableModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AppRoutingModule
  ],
  providers: [DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
