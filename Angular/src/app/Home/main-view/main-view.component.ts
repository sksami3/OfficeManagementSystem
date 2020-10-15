import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/Shared/Api/authentication.service';

@Component({
  selector: 'main-view',
  templateUrl: './main-view.component.html',
  styleUrls: ['./main-view.component.css']
})
export class MainViewComponent implements OnInit {

  constructor(private auth: AuthenticationService) {
    //console.log("main view component");
   }

  ngOnInit(): void {
  }

}
