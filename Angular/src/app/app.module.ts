import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DepartmentListComponent } from './Department/department-list/department-list.component';
import { DepartmentService } from './Shared/Api/department.service';
import { DepartmentEditComponent } from './Department/department-edit/department-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentListComponent,
    DepartmentEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
