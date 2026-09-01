import { Component } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/ProductService';
import { signal } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-product-list',
  imports: [RouterLink],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList {
  products = signal<Product[]>([]);
  constructor(private productService:ProductService){
    
  }
  ngOnInit(){
    this.productService.getProducts().subscribe(products=>{
      console.log("Réponse API :", products);
      this.products.set(products);
      console.log("LOCAL :", this.products);

    });
  }
  deleteProduct(id:number){
    this.productService.deleteProduct(id).subscribe(()=>{
      this.products.update(products=>
        products.filter(product=>product.id !== id)
        
      );
    });
  }
}
