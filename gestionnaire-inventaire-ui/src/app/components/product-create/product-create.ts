import { Component } from '@angular/core';
import { ProductCreateDto } from '../../models/product-create-dto';
import { ProductService } from '../../services/ProductService';
import { FormControl,FormGroup,ReactiveFormsModule } from '@angular/forms';
import { signal } from '@angular/core';
import { Category } from '../../models/category';
import { Supplier } from '../../models/supplier';
import { CategoryService } from '../../services/category-service';
import { SupplierService } from '../../services/supplier-service';

@Component({
  selector: 'app-product-create',
  imports: [ReactiveFormsModule],
  templateUrl: './product-create.html',
  styleUrl: './product-create.css',
})
export class ProductCreate {
  
  suppliers=signal<Supplier[]>([]);  
  categories = signal<Category[]>([]);
  productForm= new FormGroup({
    name:new FormControl(''),
    description: new FormControl(''),
    price:new FormControl(0),
    stockQuantity:new FormControl(0),
    categoryId: new FormControl(0),
    supplierId: new FormControl(0)
  });
  constructor(private productService:ProductService, private categoryService : CategoryService, private supplierService:SupplierService)
  {
     
  }
  ngOnInit()
  {
    this.categoryService.getCategories().subscribe(categories=>{
      console.log("Réponse API :", categories);
      this.categories.set(categories);
      console.log("LOCAL :", this.categories);

    });

    this.supplierService.getSuppliers().subscribe(suppliers=>{
      console.log("Réponse API :",suppliers);
      this.suppliers.set(suppliers);
      console.log("LOCAL:",this.suppliers);
    })
  }
  createProduct()
  {
    const product = this.productForm.value;
    this.productService.createProduct(product as ProductCreateDto)
    .subscribe(result => {
      console.log('Produit crée :', result)
      
    });
  }
  
}
