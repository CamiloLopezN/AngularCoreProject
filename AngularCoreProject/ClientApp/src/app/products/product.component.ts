import {Component, OnInit} from "@angular/core";
import {ProductService} from "../services/product.service";

@Component({
  selector: 'app-product-component',
  templateUrl: 'product.component.html'
})

export class ProductComponent implements OnInit {

  public listProducts!: any[];

  constructor(private productService: ProductService) {

  }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts().subscribe(response => {
      this.listProducts = response.resultObject;
    });
  }

}
