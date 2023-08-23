import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';
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
  constructor(private element:ElementRef,private _renderer:Renderer2, private productService:ProductService,private spinner:NgxSpinnerService) {
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
    // this.spinner.show(SpinnerType.SquareJellyBox);
    const td: HTMLTableCellElement = this.element.nativeElement;
    await this.productService.delete(this.id);
    $(td.parentElement).fadeOut(1000, () => {
      this.callback.emit();
    }); // işlem bittikten sonra callback fonksiyonunu tetikliyoruz ve bu sayede liste güncelleniyor.
   }

}
