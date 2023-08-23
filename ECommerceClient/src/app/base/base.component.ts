import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

export class BaseComponent {
  constructor(private spinner: NgxSpinnerService){}

  showSpinner(spinnerNameType: SpinnerType) {
    this.spinner.show(spinnerNameType)

    setTimeout(() => this.hideSpinner(spinnerNameType), 750);
  }

  

  hideSpinner(spinnerNameType: SpinnerType){
    this.spinner.hide(spinnerNameType);

  }
}

export enum SpinnerType {
BallClipRotatePulse = "ball-clip-rotate-pulse",
LineScalePulseOut = "line-scale-pulse-out",
SquareJellyBox = "square-jelly-box"
}