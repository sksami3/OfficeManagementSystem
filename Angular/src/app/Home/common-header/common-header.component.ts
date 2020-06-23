import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'common-header',
  templateUrl: './common-header.component.html',
  styleUrls: ['./common-header.component.css']
})
export class CommonHeaderComponent implements OnInit {

  logo = "assets/logo.png";
  constructor() { }

  ngOnInit(): void {
  }

}
