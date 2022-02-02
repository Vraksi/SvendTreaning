import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { ProductService } from 'src/app/Services/product.service';


@Component({
  selector: 'app-productview',
  templateUrl: './productview.component.html',
  styleUrls: ['./productview.component.css']
})
export class ProductviewComponent implements OnInit {
  _products: Product[]

  constructor(
    private ProductService: ProductService
  ) {}

  ngOnInit(): void {
    this.GetProducts();
  }

  GetProducts(){
    this.ProductService.GetProducts()
      .subscribe(products => this._products = products)
  }

}
