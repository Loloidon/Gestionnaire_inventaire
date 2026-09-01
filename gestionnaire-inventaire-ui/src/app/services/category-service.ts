import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
    private apiUrl='https://localhost:7286/api/Categories';

    constructor(private http:HttpClient)
    {
    }
    getCategories()
    {
        return this.http.get<Category[]>(this.apiUrl);
    }
}
