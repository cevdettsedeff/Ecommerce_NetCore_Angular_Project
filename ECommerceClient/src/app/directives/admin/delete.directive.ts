import { HttpErrorResponse } from '@angular/common/http';
import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';
import { DeleteDialogComponent } from 'src/app/dialogs/delete-dialog/delete-dialog.component';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { DialogService } from 'src/app/services/common/dialog.service';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ProductService } from 'src/app/services/common/models/product.service';

declare var $: any;
//Jquery eklenmiş oldu.

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  // Silme işlemlerini bu directive üzerinden yapacağız.
  // Bu directive çağırıldığı an silme işlemi için buton oluşturmaya gerek kalmayacak.
  constructor(private element: ElementRef, private _renderer: Renderer2, private productService: ProductService, private spinner: NgxSpinnerService, public dialog: MatDialog, private httpClientService: HttpClientService, private alertifyService: AlertifyService, private dialogService: DialogService) {
    const img = _renderer.createElement("img");
    img.setAttribute("src", "/assets/delete.png");
    img.setAttribute("style", "cursor: pointer;");
    img.width = 25;
    img.height = 25;
    _renderer.appendChild(element.nativeElement, img);

  }

  @Input() id: string;
  @Input() controller: string;
  @Output() callback: EventEmitter<any> = new EventEmitter();

  @HostListener("click")
  async onClick() {
    this.dialogService.openDialog({
      componentType: DeleteDialogComponent,
      data: DeleteState.Yes,
      afterClosed: async () => {

        this.spinner.show(SpinnerType.SquareJellyBox);
        const td: HTMLTableCellElement = this.element.nativeElement;

        //await this.productService.delete(this.id);
        this.httpClientService.delete({
          controller: this.controller
        }, this.id).subscribe(data => {
          $(td.parentElement).animate({
            opacity: 0,
            left: "+=50",
            height: "toggle"
          }, 500, () => {
            this.callback.emit();
            this.alertifyService.message("Ürün başarıyla silinmiştir.", {
              dissmissOthers: true,
              messageType: MessageType.Success,
              position: Position.TopRight,
            });
          });
        }, (errorResponse: HttpErrorResponse) => {
          this.spinner.hide(SpinnerType.SquareJellyBox);
          this.alertifyService.message("Ürün silinirken bir hatayla karşılaşıldı!", {
            dissmissOthers: true,
            messageType: MessageType.Error,
            position: Position.TopRight,
          }); // işlem bittikten sonra callback fonksiyonunu tetikliyoruz ve bu sayede liste güncelleniyor.
        });
      }
    });

  }

  //callBack fonksiyon
  //   openDialog(afterClosed: any): void {
  //     const dialogRef = this.dialog.open(DeleteDialogComponent, {
  //       width: '300px',
  //       data: DeleteState.Yes,
  //     });

  //     dialogRef.afterClosed().subscribe(result => {
  //       if (result == DeleteState.Yes) {
  //         afterClosed();
  //       }

  //     });
  //   }
}

export enum DeleteState {
  Yes,
  No
}


