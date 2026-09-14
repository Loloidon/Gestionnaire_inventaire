import { Component } from '@angular/core';
import { ProductService } from '../../services/ProductService';
import { Category } from '../../models/category';
import { Supplier } from '../../models/supplier';
import { CategoryService } from '../../services/category-service';
import { SupplierService } from '../../services/supplier-service';
import { FormControl,FormGroup,ReactiveFormsModule } from '@angular/forms';
import { signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-edit',
  imports: [ReactiveFormsModule],
  templateUrl: './product-edit.html',
  styleUrl: './product-edit.css',

})
export class ProductEdit 
{
  
  
  suppliers = signal<Supplier[]>([]);
  categories = signal<Category[]>([]);
  constructor(
    private route:ActivatedRoute,
    private router:Router,
    private productService:ProductService,
    private categoryService:CategoryService,
    private supplierService:SupplierService
    
  ){
    
  };
  productForm= new FormGroup({
    name:new FormControl(''),
    description: new FormControl(''),
    price:new FormControl(0),
    stockQuantity:new FormControl(0),
    categoryId: new FormControl(0),
    supplierId: new FormControl(0)
  });
  ngOnInit() {
  const id = Number(this.route.snapshot.paramMap.get('id'));

  this.productService.getProduct(id).subscribe(product => {
    this.productForm.patchValue({
      name: product.name,
      description: product.description,
      price: product.price,
      stockQuantity: product.stockQuantity,
      categoryId: product.categoryId,
      supplierId: product.supplierId
    });
  });

  this.categoryService.getCategories().subscribe(categories => {
    this.categories.set(categories);
  });

  this.supplierService.getSuppliers().subscribe(suppliers => {
    this.suppliers.set(suppliers);
  });
}
  PutProduct() {
  const id = Number(this.route.snapshot.paramMap.get('id'));
  const product = this.productForm.value;
  console.log("id:",id);
  console.log("form:",product)
  
  this.productService.putProduct(id,product as any)
  .subscribe(result => {
    console.log("Produit modifié:");
    this.router.navigate(['/products']);
  })
}
}
  

