import { Injectable } from '@angular/core';
import { HttpClient,  HttpErrorResponse } from '@angular/common/http';
import { Armazem } from 'src/app/model/armazem';
import {catchError, map, Observable, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArmazemService {

  private url = 'https://localhost:5001/api/RegistarArmazém';
  constructor(private httpClient: HttpClient) { }


  criarCamiao(camiao: Armazem): Observable<any>{

    return this.httpClient.post(this.url, camiao).pipe(map(this.extractData));
  
  }

  public extractData(res:any){
    return res || {};
  }
}
