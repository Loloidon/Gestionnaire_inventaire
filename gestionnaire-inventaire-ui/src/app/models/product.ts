import { Category  } from "../models/category"
import { Supplier } from "../models/supplier"
export interface Product {
    id:number;
    name:string;
    description:string;
    price:number;
    stockQuantity:number;
    createdAt:Date;
    categoryId:number;
    category:Category;
    cupplierId:number;
    supplier:Supplier;

}
