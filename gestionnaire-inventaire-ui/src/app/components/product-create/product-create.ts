import { Component } from '@angular/core';
import { ProductCreateDto } from '../../models/product-create-dto';
import { ProductService } from '../../services/ProductService';
@Component({
  selector: 'app-product-create',
  imports: [],
  templateUrl: './product-create.html',
  styleUrl: './product-create.css',
})
export class ProductCreate {

constructor(private productService:ProductService)
{
}
createProduct(product:ProductCreateDto)
{
  this.productService.createProduct(product).subscribe(result => {
    
  })
}

}
