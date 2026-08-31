import { TestBed } from '@angular/core/testing';

import { Product } from '../models/product';
import { HttpClient } from '@angular/common/http';

describe('Product', () => {
  let service: Product;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Product);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
