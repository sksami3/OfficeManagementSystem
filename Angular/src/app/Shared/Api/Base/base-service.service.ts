import { Injectable } from '@angular/core';
import { IBaseRepository } from './ibase-repository';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Base } from '../../Models/Base';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T extends Base> implements IBaseRepository<T> {

  constructor(private http : HttpClient)//,private e : T) 
  { 

  }
  getById(Id: number) {
    throw new Error("Method not implemented.");
  }
  edit(entity: T) {
    throw new Error("Method not implemented.");
  }
  Insert(entity: T) {
    throw new Error("Method not implemented.");
  }
  Delete(id: number) {
    throw new Error("Method not implemented.");
  }

  getAll() : Observable<T[]>{
    return this.http.get<T[]>('https://localhost:44370/api/Employees');
  }
  // getById(Id: number) : Observable<T> {
  //   return this.http.get<T>(`${this.e.URL}/${Id}`)
  // }
  // edit(entity: T) : Observable<any> {
  //   return this.http.put(`${this.e.URL}/${entity.Id}`,entity);
  // }
  // Insert(entity: T) : Observable<any> {
  //   return this.http.post(`${this.e.URL}`,entity)
  // }
  // Delete(id: number) : Observable<any> {
  //   return this.http.delete(`${this.e.URL}/${id}`)
  // }
}
