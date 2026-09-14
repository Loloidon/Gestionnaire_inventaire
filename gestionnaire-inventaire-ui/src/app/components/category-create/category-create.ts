import { Component } from '@angular/core';
import { signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Category } from '../../models/category';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoryService } from '../../services/category-service';
@Component({
  selector: 'app-category-create',
  imports: [RouterLink],
  templateUrl: './category-create.html',
  styleUrl: './category-create.css',
})
export class CategoryCreate {
  categories=signal<Category[]>([]);
  categoryForm= new FormGroup({
    name: new FormControl('')
  })
constructor(categoryService : CategoryService)
{
  
}
}
