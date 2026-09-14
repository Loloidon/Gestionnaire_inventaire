
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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
    getSupplier(id:number)
    {
        return this.http.get<Supplier>(`${this.apiUrl}/${id}`);
    }
    deleteSupplier(id:number)
    {
        return this.http.delete<Supplier[]>(`${this.apiUrl}/${id}`);
    }
    putSupplier(id:number ,supplier:Supplier)
    {
        return this.http.put<Supplier[]>(`${this.apiUrl}/${id}`,supplier);
    }

}
