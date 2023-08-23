import { Component, OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Create_Product } from 'src/app/contracts/create_product';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private httpClientService: HttpClientService ){
    super(spinner);
  }


  ngOnInit(): void {

  }
  
  @ViewChild(ListComponent) listComponents: ListComponent;

  createdProduct(createdProduct: Create_Product){
    this.listComponents.getProducts();
  }

    // ngOnInit(): void {
      // this.showSpinner(SpinnerType.SquareJellyBox);

      // this.httpClientService.get<Product[]>({
      //   controller: "products"
      // }).subscribe(data => console.log(data))};
      
      // this.httpClientService.post({
      //   controller:"products",
      // }, {
      //   name: "Kalem",
      //   stock: 100,
      //   price: 15
      // }).subscribe();

      // this.httpClientService.post({
      //   controller:"products",
      // }, {
      //   name: "Silgi",
      //   stock: 50,
      //   price: 5
      // }).subscribe();

      // this.httpClientService.put({
      //   controller:"products"
      // }, {
      //   id: "...",
      //   stock: 100,
      //   price: 5
      // }).subscribe();

      // this.httpClientService.delete({
      //   controller: "products"
      // }, "id değeri").subscribe();

    // }
  }
