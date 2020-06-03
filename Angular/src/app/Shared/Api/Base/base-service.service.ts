import { Injectable } from '@angular/core';
import { IBaseRepository } from './ibase-repository';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Base } from '../../Models/Base';
import { Component, OnInit } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
export class BaseService<T extends Base> implements IBaseRepository<T> {

  constructor(private http : HttpClient,private URL : string) 
  { 
      console.log(URL);
  }

  getAll() : Observable<T[]>{
    return this.http.get<T[]>(this.URL);
  }
  getById(Id: number) : Observable<T> {
    return this.http.get<T>(`${this.URL}/${Id}`)
  }
  edit(entity: T) : Observable<any> {
    return this.http.put(`${this.URL}/${entity.Id}`,entity);
  }
  Insert(entity: T) : Observable<any> {
    console.log(entity);
    return this.http.post(`${this.URL}`,entity)
  }
  Delete(id: number) : Observable<any> {
    return this.http.delete(`${this.URL}/${id}`)
  }
  ngOnInit(): void {
    
  }
}
