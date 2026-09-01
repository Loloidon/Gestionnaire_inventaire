
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductCreateDto } from '../models/product-create-dto';
import { Product } from '../models/product';



@Injectable({
  providedIn: 'root'
})
export class ProductService {
    private apiUrl='https://localhost:7286/api/Products';
    

    constructor(private http: HttpClient){

    }
    getProducts()
    {
        return this.http.get<Product[]>(this.apiUrl);
    }
    getProduct(id:number)
    {
        return this.http.get<Product>(`${this.apiUrl}/${id}`);
    }
    deleteProduct(id:number)
    {
        return this.http.delete(`${this.apiUrl}/${id}`);

    }
    createProduct(product:ProductCreateDto)
    {
        return this.http.post<ProductCreateDto>(this.apiUrl,product);

    }
    putProduct(id:number,product:Product)
    {
        return this.http.put(`${this.apiUrl}/${id}`,product)
    }
}
