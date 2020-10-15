import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AttendanceService } from 'src/app/Shared/Api/Attendance/attendance.service';
import { AuthenticationService } from 'src/app/Shared/Api/authentication.service';
import { EmployeeService } from 'src/app/Shared/Api/Employee/employee.service';
import { Attendance } from 'src/app/Shared/Models/Attendance';
import { NotificationService } from 'src/app/Shared/NotificationService/notification.service';
import { DeviceDetectorService } from 'ngx-device-detector';

@Component({
  selector: 'app-create-attendance',
  templateUrl: './create-attendance.component.html',
  styleUrls: ['./create-attendance.component.scss']
})
export class CreateAttendanceComponent implements OnInit {

  date: Date;
  isAttendedForToday: boolean = false;
  isAttendanceCompletedForToday: boolean = false;
  attendance: Attendance;
  attendanceForm: FormGroup;
  deviceInfo;

  constructor(private _empService: EmployeeService,
    private _authService: AuthenticationService,
    private _notifyService: NotificationService,
    private fb: FormBuilder,
    private _attendanceSevice: AttendanceService,
    private deviceService: DeviceDetectorService) {
    this.createFormGroup();

    setInterval(() => {
      this.date = new Date()
    }, 1000);
    _empService.getTodaysAttendanceInformationByUsername(_authService.userValue.username)
      .subscribe(
        val => {
          if (val != null) {
            var att =JSON.parse(JSON.stringify(val));
            if (att.start != null && att.end == null) {
              console.log("val.Start && val.End == null")
              this.isAttendedForToday = true;
            }
            else if (att.start != null && att.end != null) {
              console.log("val.Start!=null && val.End != null")
              this.isAttendanceCompletedForToday = true;
            }
          }
        },
        err => this._notifyService.showError(err.message, "Error!!")
      );
  }

  ngOnInit(): void {

  }

  StartEvent(event: any) {
    if (event.currentTarget.checked) {
      var atten = new Attendance();
      var isLoggedFromDesktop = (this.deviceService.isDesktop) ? "yes" : "no";
      atten.Start = new Date();
      atten.ClientsDeviceInfo = "Login from desktop:" + isLoggedFromDesktop +
        ";brower:" + this.deviceService.browser +
        ";browser version:" + this.deviceService.browser_version +
        ";OS:" + this.deviceService.os +
        ";OS Version:" + this.deviceService.os_version +
        ";Device:" + this.deviceService.device;
      console.log(atten.ClientsDeviceInfo);
      this._attendanceSevice.InsertAttendance(atten)
        .subscribe(val => { this.attendance = val; this.isAttendedForToday = true; },
          err => this._notifyService.showError(err.message, "Error!!")
        );
    }
  }

  EndEvent(event: any) {
    if (event.currentTarget.checked) {
      var atten = new Attendance();
      atten.End = new Date();
      this._attendanceSevice.UpdateAttendance(atten)
        .subscribe(val => { this.attendance = val; this.isAttendanceCompletedForToday = true },
          err => this._notifyService.showError(err.message, "Error!!")
        );
    }
  }

  createFormGroup() {
    this.attendanceForm = this.fb.group({
      Start: [''],
      End: [''],
      WorkDetails: ['']
    });
  };

}
