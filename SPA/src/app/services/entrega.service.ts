import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EntregaService {
  private url = 'https://localhost:5001/api/Entrega';
  constructor(private httpClient: HttpClient) { }

  criarEntrega(identificador: string,
    armazemID: string,
    dia:number,
    mes:number,
    ano:number,
    massa: number,
    tempoColocacao: number,
    tempoRetirada: number): Observable<any> {


      const body = {"Identificador": identificador, "Armazém": armazemID, "Dia": dia, "Mes": mes, "Ano": ano, "Massa":massa,"TempoColocação":tempoColocacao, "TempoRetirada":tempoRetirada}
      console.log(body);
      return this.httpClient.post(this.url, body).pipe(map(this.extractData));
    }

    public extractData(res: any) {
      return res || {};
    }

    private handleError(error: HttpErrorResponse) {
      if (error.status === 0) {
        // A client-side or network error occurred. Handle it accordingly.
        console.error('Ocorreu um erro:', error.error);
      } else {
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong.
        console.error(
          `Backend returnou o código ${error.status}, menssagem: `, error.error);
      }
      // Return an observable with a user-facing error message.
      return throwError(() => new Error('Aconteceu algo; por favor tente mais tarde'));
    }



}
