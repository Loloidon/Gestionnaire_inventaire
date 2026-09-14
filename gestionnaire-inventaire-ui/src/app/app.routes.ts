import { Routes } from '@angular/router';
import { ProductList } from './components/product-list/product-list';
import { ProductCreate } from './components/product-create/product-create';
import { ProductEdit } from './components/product-edit/product-edit';
export const routes: Routes = [
    {
        path:'products',
        component:ProductList
    },
    {
        path: 'products/create', 
        component: ProductCreate 
    },
    {
        path: 'products/edit/:id',
        component: ProductEdit
    }
];
