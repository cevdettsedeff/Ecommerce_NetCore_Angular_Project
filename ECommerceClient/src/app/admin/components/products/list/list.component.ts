import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { List_Product } from 'src/app/contracts/list_product';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

declare var $: any;
// jquery dahil edildi.

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent extends BaseComponent  implements OnInit{


  constructor(spinner: NgxSpinnerService,
    private productService: ProductService,
    private alertifyService: AlertifyService) {
    super(spinner)
  }

  displayedColumns: string[] = ['name','stock','price','createdDate','updatedDate','edit','delete']

  dataSource:MatTableDataSource<List_Product> = null;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  async ngOnInit() {
    await this.getProducts();
  }

  async pageChanged() {
    await this.getProducts();
  }

async getProducts() {
    this.showSpinner(SpinnerType.SquareJellyBox);
    const allProducts: { totalProductCount: number; products: List_Product[] } = await this.productService.read(this.paginator ? this.paginator.pageIndex : 0, this.paginator ? this.paginator.pageSize : 5, () => this.hideSpinner(SpinnerType.LineScalePulseOut), errorMessage => this.alertifyService.message(errorMessage, {
      dissmissOthers: true,
      messageType: MessageType.Error,
      position: Position.TopRight
    }))
    this.dataSource = new MatTableDataSource<List_Product>(allProducts.products);
    this.paginator.length = allProducts.totalProductCount;
  }


    

  
}
