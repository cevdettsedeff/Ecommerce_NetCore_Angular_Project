import { Injectable } from '@angular/core';
declare var alertify: any //Alertify kütüphanesini kullanmak için bunu belirtiyoruz.

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  message(message: string, options: Partial<AlertifyOptions>){
    //message : string, messageType: MessageType, position: Position, delay: number = 5, dismissOthers: boolean = false
    // JS'de metotları ilgili sınıfın ixdexer'ı üzerinden tetikleyebiliriz.

    alertify[options.messageType](message);
    alertify.set('notifier', 'delay', options.delay)
    alertify.set('notifier', 'position', options.position);
  }

  dismiss(){
    alertify.dismissAll();

  }
}

export enum MessageType {
  Error = "error",
  Message = "message",
  Notify = "notify",
  Success = "success",
  Warning = "warning"
}

export enum Position{
  TopCenter = "top-center",
  TopRight = "top-right",
  TopLeft = "top-left",
  BottomRight = "bottom-right",
  BottomCenter = "bottom-center",
  BottomLeft = "bottom-left"

}

//default değerleri atıyoruz.
export class AlertifyOptions {
  messageType: MessageType = MessageType.Message;
  position: Position = Position.BottomLeft;
  delay: number = 4;
  dissmissOthers: boolean = false;
}