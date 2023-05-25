import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private httpClient: HttpClient, @Inject("baseUrl") private baseUrl: string) { }

  get<T>(requestParameter:Partial<RequestParameters>){ //T türünde get isteğine göre nesne dönecektir.

    let url: string = "";

    url = `${this.baseUrl}/${controller}/${action}`;

  }

  post(){


  }

  put(){


  }

  delete(){


  }


}

export class RequestParameters {
  controller?: string;
  action?: string;

  headers?: HttpHeaders;
  baseUrl?: string;
  fullEndPoint?: string; //farklı yerlere istekte bulunmak için bunu da ekledik.
}