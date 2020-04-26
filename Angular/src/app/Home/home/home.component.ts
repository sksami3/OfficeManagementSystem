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
  loadData(data: DepartmentWiseEmployeeStatisticsVM[]): any {
    data.forEach(function (value) {
      this.doughnutChartData.push(value.total);
      this.doughnutChartLabels.push(value.departmentName);

      // data.map(item => {
      //   return {
      //     Name: item.Name
      //   }
      // }).forEach(item => this.doughnutChartLabels.push(item));

      // data.map(item2 => {
      //   return {
      //     Total: item2.Total
      //   }
      // }).forEach(item2 => this.doughnutChartData.push(item2));

      this.chartReady = true;
    });
  }

  ngOnInit(): void {
    this.departmentServive.getAllDepartmentStat().subscribe(data => {
      // this.DepartmentStatList = data;
      // this.DepartmentStatList.forEach(function(value){
      //   this.doughnutChartLabels = value.Name;
      // });
      // this.DepartmentStatList.forEach(function(value){
      //   this.doughnutChartData = value.Total;
      //   this.chartReady = true;
      // });

      //  this.doughnutChartLabels = ['Sales Q1', 'Sales Q2', 'Sales Q3', 'Sales Q4'];
      // this.doughnutChartData = [120, 150, 180, 90];
      // this.chartReady = true;
      for (let i = 0; i < data.length; i++) {
        console.log(data[i].total);
        this.doughnutChartLabels.push(data[i].departmentName);
        this.doughnutChartData.push(data[i].total);
        this.chartReady = true;
      }
      this.doughnutChartType = 'doughnut';

      // var namelist : Array<string>;
      // var countlist : Array<number>;
      // data.forEach(element => {
      //   namelist.push(element.Name);
      //   countlist.push(<number>element.Total);
      // });
      // console.log(namelist);
      // this.doughnutChartLabels = namelist;
      // this.doughnutChartData = countlist;

      //this.loadData(data);
    });


  }

}
