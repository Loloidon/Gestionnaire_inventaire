import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { signal } from '@angular/core';
import { Category } from '../../models/category';
import { CategoryService } from '../../services/category-service';

@Component({
  selector: 'app-category-list',
  imports: [RouterLink],
  templateUrl: './category-list.html',
  styleUrl: './category-list.css',
})
export class CategoryList {
  category= signal<Category[]>([]);

  constructor(private categoryService:CategoryService)
  {

  }
  ngOnInit(){
    this.categoryService.getCategories().subscribe(category=>{
      console.log("Réponse API :", category);
      this.category.set(category);
      console.log("LOCAL :", this.category);

    });
  }
  deleteCategory(id:number){
    this.categoryService.deleteCategory(id).subscribe(()=>{
      this.category.update(category=>
        category.filter(category=>category.id !== id)
        
      );
    });
  }
}
