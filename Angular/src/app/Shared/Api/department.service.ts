import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs/Observable';
import { Department } from 'src/app/Shared/Models/Department'
import { Observable } from 'rxjs';
import { DepartmentWiseEmployeeStatisticsVM } from '../Models/DepartmentWiseEmployeeStatisticsVM';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http : HttpClient) { }

  // public API = 'https://192.168.0.109:44305/api';
  public API = 'https://localhost:44370/api';
  public DepartmetAPI = `${this.API}/Departments`;

  getAll() : Observable<Department[]>{
    return this.http.get<Department[]>(`${this.DepartmetAPI}`);
  }

  getAllDepartmentStat() : Observable<DepartmentWiseEmployeeStatisticsVM[]>{
    return this.http.get<DepartmentWiseEmployeeStatisticsVM[]>(`${this.DepartmetAPI}/GetDepartmertStat`);
  }

  getById(Id : number) : Observable<Department>{
    return this.http.get<Department>(`${this.DepartmetAPI}/${Id}`);
  }

  edit(department : Department) : Observable<any>{
    console.log('On edit');
    return this.http.put(`${this.DepartmetAPI}/${department.Id}`,department);
  }

  Insert(department : Department) : Observable<any>{
    if(department){
      console.log('In Insert method');
      return this.http.post(`${this.DepartmetAPI}/`,department);
    }
  }

  Delete(id : number) : Observable<any>{
    if(id){
      console.log('In delte method');
      return this.http.delete(`${this.DepartmetAPI}/${id}`);
    }
  }
}
