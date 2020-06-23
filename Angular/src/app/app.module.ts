import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DepartmentListComponent } from './Department/department-list/department-list.component';
import { DepartmentService } from './Shared/Api/department.service';
import { DepartmentEditComponent } from './Department/department-edit/department-edit.component';
//import { DepartmentHeaderComponent } from './Department/department-header/department-header.component';
import { PageNotFoundComponent } from './Department/page-not-found/page-not-found.component';
import { HomeComponent } from './Home/home/home.component';
import {MatTableModule} from '@angular/material/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbTimepickerModule } from '@ng-bootstrap/ng-bootstrap';
// adding rout
import { RouterModule, Routes } from '@angular/router';
import { DepartmentPostComponent } from './Department/department-post/department-post.component';
//import { DepartmentSidebarComponent } from './Department/department-sidebar/department-sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { EmployeePostComponent } from './Employee/employee-post/employee-post.component';
import { ToastrModule } from 'ngx-toastr';
import { CoolDialogsModule } from '@angular-cool/dialogs';
import { ChartsModule } from 'ng2-charts';
import { DataTablesModule } from 'angular-datatables';
import { EmployeeListComponent } from './Employee/employee-list/employee-list.component';
import { CommonHeaderComponent } from './Home/common-header/common-header.component';
import { CommonSidebarComponent } from './Home/common-sidebar/common-sidebar.component';


@NgModule({
  declarations: [
    AppComponent,
    DepartmentListComponent,
    DepartmentEditComponent,
    //DepartmentHeaderComponent,
    HomeComponent,
    DepartmentPostComponent,
    //DepartmentSidebarComponent,
    EmployeePostComponent,
    EmployeeListComponent,
    CommonHeaderComponent,
    CommonSidebarComponent       
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
    AppRoutingModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    CoolDialogsModule,
    ChartsModule,
    DataTablesModule
  ],
  providers: [DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
