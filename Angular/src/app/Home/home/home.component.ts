import { Component, OnInit } from '@angular/core';
import { DepartmentService } from 'src/app/Shared/Api/department.service';
import { DepartmentWiseEmployeeStatisticsVM } from 'src/app/Shared/Models/DepartmentWiseEmployeeStatisticsVM';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public DepartmentStatList: Array<DepartmentWiseEmployeeStatisticsVM>;
  public doughnutChartLabels: Array<string> = []; //= ['Sales Q1', 'Sales Q2', 'Sales Q3', 'Sales Q4'];
  public doughnutChartData: Array<number> = []; //= [120, 150, 180, 90];
  public doughnutChartType : string;// = 'doughnut';
  public chartReady: boolean = false;

  constructor(private departmentServive: DepartmentService) { }
  
  ngOnInit(): void {
    this.departmentServive.getAllDepartmentStat().subscribe(data => {
      for (let i = 0; i < data.length; i++) {
        console.log(data[i].total);
        this.doughnutChartLabels.push(data[i].departmentName);
        this.doughnutChartData.push(data[i].total);
        this.chartReady = true;
      }
      this.doughnutChartType = 'doughnut';
    });


  }

}
