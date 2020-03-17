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
// adding rout
import { RouterModule, Routes } from '@angular/router';


const appRoutes: Routes = 
[
  { 
    path: '',
     component: HomeComponent 
  },
  { 
    path: 'api/departments',      
    component: DepartmentListComponent,
    data: { title: 'Heroes List' } 
  },
  {
    path: 'api/EditDepartment/:id',
    component: DepartmentEditComponent
    
  },
  
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    DepartmentListComponent,
    DepartmentEditComponent,
    DepartmentHeaderComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    MatTableModule 
  ],
  providers: [DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
