import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrOptions, ToastrPosition } from './services/ui/custom-toastr.service';
import { Position } from './services/admin/alertify.service';
declare var $:any

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ECommerceClient';

  constructor(private toastrService: CustomToastrService){
    // toastrService.message("Hoşgeldiniz!","E-Ticaret", {
    //   messageType: ToastrMessageType.Success,
    //   position: ToastrPosition.BottomFullWidth
    // });

    // toastrService.message("Hoşgeldiniz!","E-Ticaret", {
    //   messageType: ToastrMessageType.Error,
    //   position: ToastrPosition.TopFullWidth
    // });
  }


  }

// $.get("https://localhost:7126/api/products", data => {
//   console.log(data)
// })
