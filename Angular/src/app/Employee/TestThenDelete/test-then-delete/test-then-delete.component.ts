import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/Shared/Api/employee.service';
import { Employee } from 'src/app/Shared/Models/Employee';

@Component({
  selector: 'app-test-then-delete',
  templateUrl: './test-then-delete.component.html',
  styleUrls: ['./test-then-delete.component.css']
})
export class TestThenDeleteComponent implements OnInit {

  constructor(private es : EmployeeService) { }

  eList : Array<Employee>;

  ngOnInit(): void {
    this.es.getAll().subscribe( data => {
      console.log(data);
      this.eList = data;
  });
  }

}
