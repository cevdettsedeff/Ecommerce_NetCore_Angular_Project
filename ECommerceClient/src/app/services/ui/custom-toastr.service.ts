import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CustomToastrService {

  constructor(private toastr: ToastrService) { }

   message(message: string, title: string, toastrOptions: Partial<ToastrOptions>){
    this.toastr[toastrOptions.messageType](message, title, {
     positionClass: toastrOptions.position

    })
   }
}

export enum ToastrMessageType{
Success = "success",
Info = "info",
Error = "error",
Warning = "warning"
}

export enum ToastrPosition {
  TopCenter = "toast-top-center",
  TopRight = "toast-top-right",
  TopLeft = "top-left",
  TopFullWidth = "toast-top-full-width",
  BottomRight = "toast-bottom-right",
  BottomCenter = "toast-bottom-center",
  BottomLeft = "toast-bottom-left",
  BottomFullWidth = "toast-bottom-full-width"
}

export class ToastrOptions {
  messageType: ToastrMessageType;
  position: ToastrPosition;s
}