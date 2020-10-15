import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
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
import { CommonFooterComponent } from './Home/common-footer/common-footer.component';
import { EscapeHtmlPipe } from './Shared/Utility/keep-html.pipe';
import { CreateAttendanceComponent } from './Attendance/create-attendance/create-attendance.component';
import { CanvasClockComponent } from './Attendance/canvas-clock/canvas-clock.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card'; 
import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import {
  GoogleLoginProvider,
  FacebookLoginProvider,
  AmazonLoginProvider,
} from 'angularx-social-login';
import { AccountModule } from './Home/Account/account/account.module';
import { AuthenticationService } from './Shared/Api/authentication.service';
import { MainViewComponent } from './Home/main-view/main-view.component';
import { JwtInterceptor } from './Shared/helper/jwt.interceptor';
import { ErrorInterceptor } from './Shared/helper/error.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    CommonHeaderComponent,
    CommonSidebarComponent,
    CommonFooterComponent,
    DepartmentPostComponent,
    DepartmentListComponent,
    DepartmentEditComponent,
    //DepartmentHeaderComponent,
    HomeComponent,
    //DepartmentSidebarComponent,
    EmployeePostComponent,
    EmployeeListComponent,
   
    EscapeHtmlPipe,
    CreateAttendanceComponent,
    CanvasClockComponent,
    MainViewComponent    
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
    DataTablesModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatCardModule,
    SocialLoginModule,
    AccountModule,
  ],
  providers: [
    DepartmentService,
    AuthenticationService,
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              'clientId'
            ),
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider('clientId'),
          },
          {
            id: AmazonLoginProvider.PROVIDER_ID,
            provider: new AmazonLoginProvider(
              'clientId'
            ),
          },
        ],
      } as SocialAuthServiceConfig,
    },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
