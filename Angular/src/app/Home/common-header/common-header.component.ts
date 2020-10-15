import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from '../../Shared/Api/authentication.service'

@Component({
  selector: 'common-header',
  templateUrl: './common-header.component.html',
  styleUrls: ['./common-header.component.css']
})
export class CommonHeaderComponent implements OnInit {

  logo = "assets/logo.png";
  constructor(private auth: AuthenticationService) { }

  ngOnInit(): void {
  }
  logout(): void {
    console.log("logout button working");
    this.auth.logout();
  }
  

}
