import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';
import { DeleteDialogComponent } from 'src/app/dialogs/delete-dialog/delete-dialog.component';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ProductService } from 'src/app/services/common/models/product.service';

declare var $:any;
//Jquery eklenmiş oldu.

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  // Silme işlemlerini bu directive üzerinden yapacağız.
  // Bu directive çağırıldığı an silme işlemi için buton oluşturmaya gerek kalmayacak.
  constructor(private element:ElementRef,private _renderer:Renderer2, private productService:ProductService,private spinner:NgxSpinnerService, public dialog:MatDialog) {
    const img = _renderer.createElement("img");
    img.setAttribute("src", "/assets/delete.png");
    img.setAttribute("style", "cursor: pointer;");
    img.width = 25;
    img.height = 25;
    _renderer.appendChild(element.nativeElement, img);

   }

  @Input() id:string
  @Output() callback: EventEmitter<any> = new EventEmitter();

   @HostListener("click")
   async onClick(){
    this.openDialog(async ()=> {
    this.spinner.show(SpinnerType.SquareJellyBox);
    const td: HTMLTableCellElement = this.element.nativeElement;
    await this.productService.delete(this.id);
    $(td.parentElement).animate({
      opacity:0,
      left: "+=50",
      height: "toggle"
    }, 500, () => {
      this.callback.emit();
    }); // işlem bittikten sonra callback fonksiyonunu tetikliyoruz ve bu sayede liste güncelleniyor.
  });
   }

   //callBack fonksiyon
   openDialog(afterClosed:any): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width:'250px',
      data: DeleteState.Yes,
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if(result == DeleteState.Yes){
        afterClosed();
      }
      
    });
  }
}

export enum DeleteState{
  Yes,
  No
}


