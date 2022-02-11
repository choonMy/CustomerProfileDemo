import { ICustomer } from './../models/customer';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<ICustomer[]>(this.baseUrl + 'customer');
  }

  getCustomer(id: number) {
    return this.http.get<ICustomer>(this.baseUrl + `customer/${id}`);
  }

  create(profile: any) {
    return this.http.post(this.baseUrl + 'customer', profile);
  }
  update(profile: any) {
    return this.http.put(this.baseUrl + 'customer', profile);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `customer/${id}`);
  }
}
