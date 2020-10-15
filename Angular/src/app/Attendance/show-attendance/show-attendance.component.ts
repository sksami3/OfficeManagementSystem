import { Component, OnInit } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventApi, EventClickArg, EventInput, EventSourceInput, Identity } from '@fullcalendar/angular';
import { identity } from 'rxjs';
import { AttendanceService } from 'src/app/Shared/Api/Attendance/attendance.service';
import { AuthenticationService } from 'src/app/Shared/Api/authentication.service';
import { createEventId, INITIAL_EVENTS } from './event-utils';

@Component({
  selector: 'app-show-attendance',
  templateUrl: './show-attendance.component.html',
  styleUrls: ['./show-attendance.component.css']
})
export class ShowAttendanceComponent implements OnInit {

  INIT_EVENTS: EventInput[] = [];
  constructor(private _authService: AuthenticationService,private _attendanceService:AttendanceService){

  }
  ngOnInit(): void {
    this._attendanceService.PerDayCalculation(this._authService.userValue.username)
    .subscribe(val =>{
      this.INIT_EVENTS = val;
      // for (let i = 0; i < val.length; i++) {
      //   this.INIT_EVENTS[i].id = i.toString();
      //   this.INIT_EVENTS[i].title = val[i].title;
      //   this.INIT_EVENTS[i].start = val[i].date;
      // }
      // console.log(this.INIT_EVENTS);
      this.calendarOptions = {
        events:  this.INIT_EVENTS,
      };
    },
    err=>{

    });
  }
  calendarVisible = true;
  calendarOptions: CalendarOptions = {
    // headerToolbar: {
    //   left: 'prev,next today',
    //   center: 'title',
    //   right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
    // },
    initialView: 'dayGridMonth',
    eventOverlap: false,
    eventColor: '#00FF00'
    //initialEvents: INITIAL_EVENTS, // alternatively, use the `events` setting to fetch from a feed
    //weekends: true,
    //editable: true,
    //selectable: true,
    //selectMirror: true,
    //dayMaxEvents: true,
    // select: this.handleDateSelect.bind(this),
    // eventClick: this.handleEventClick.bind(this),
    // eventsSet: this.handleEvents.bind(this)
    /* you can update a remote database when these fire:
    eventAdd:
    eventChange:
    eventRemove:
    */
  };
  currentEvents: EventApi[] = [];

  handleCalendarToggle() {
    this.calendarVisible = !this.calendarVisible;
  }

  // handleWeekendsToggle() {
  //   const { calendarOptions } = this;
  //   calendarOptions.weekends = !calendarOptions.weekends;
  // }

  // handleDateSelect(selectInfo: DateSelectArg) {
  //   const title = prompt('Please enter a new title for your event');
  //   const calendarApi = selectInfo.view.calendar;

  //   calendarApi.unselect(); // clear date selection

  //   if (title) {
  //     calendarApi.addEvent({
  //       id: createEventId(),
  //       title,
  //       start: selectInfo.startStr,
  //       end: selectInfo.endStr,
  //       allDay: selectInfo.allDay
  //     });
  //   }
  // }

  // handleEventClick(clickInfo: EventClickArg) {
  //   if (confirm(`Are you sure you want to delete the event '${clickInfo.event.title}'`)) {
  //     clickInfo.event.remove();
  //   }
  // }

  // handleEvents(events: EventApi[]) {
  //   this.currentEvents = events;
  // }

}
