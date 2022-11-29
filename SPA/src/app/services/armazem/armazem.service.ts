import { Injectable } from '@angular/core';
import { HttpClient,  HttpErrorResponse } from '@angular/common/http';
import { Armazem } from 'src/app/model/armazem';
import {catchError, map, Observable, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArmazemService {

  private url = 'https://localhost:5001/api/armazem';
  constructor(private httpClient: HttpClient) { }


  criarArmazem(identificador: string, designacao: string, codigoPostal: string, numeroPorta: number, nomeRua: string, localidade: string,
    pais: string, municipio: string, latitude: number,longitude: number): Observable<any>{

    const body = {"Identificador":identificador, "Designação":designacao, "CódigoPostal":codigoPostal, "NúmeroPorta":numeroPorta,
    "NomeRua":nomeRua, "Localidade":localidade, "País":pais, "Munícipio":municipio, "Latitude":latitude, "Longitude": longitude}
    console.log(body);
      
    return this.httpClient.post(this.url, body).pipe(catchError(err => {
      if (err.status == 400) {
        alert('Armazém não criado!');
      }
      if (err.status == 500) {
        alert('Armazém inválido:\nPoderá já existir um armazém com o ID introduzido!');
      }
      return throwError(err);
    }));
  
  }

  listarArmazens(): Observable<any> {
    return this.httpClient.get(this.url).pipe(map(this.extractData));
  }

  public extractData(res:any){
    return res || {};
  }
}
