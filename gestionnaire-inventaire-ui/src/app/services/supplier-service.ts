
import { HttpClient } from '@angular/common/http';
import { Injectable, Service } from '@angular/core';
import { Supplier } from '../models/supplier';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
    private apiUrl='https://localhost:7286/api/Suppliers';

    constructor(private http:HttpClient)
    {

    }
    getSuppliers()
    {
        return this.http.get<Supplier[]>(this.apiUrl);
    }
}
