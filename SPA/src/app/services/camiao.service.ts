import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map, Observable, throwError } from 'rxjs';
import { Camiao } from '../model/camiao';

@Injectable({
  providedIn: 'root'
})
export class CamiaoService {
  private url = 'http://localhost:3000/api/camiao';
  constructor(private httpClient: HttpClient) { }


  criarCamiao(matricula: string, caracteristica: string, autonomia:number, capacidadeTransporte:number, capacidadeBateria:number,
    tara: number, tempoCarregamento:string): Observable<any> {

    this.verificarAtributos(matricula, caracteristica, autonomia, capacidadeTransporte, capacidadeBateria,tara, tempoCarregamento);
    
    const body = {"matricula":matricula,"caracteristica":caracteristica,
    "autonomia":autonomia, "capacidadeTransporte":capacidadeTransporte, "capacidadeBateria":capacidadeBateria, "tara": tara, "tempoCarregamento":tempoCarregamento}
    
    console.log(body);
    return this.httpClient.post(this.url, body).pipe(map(this.extractData));

  }
  
/*
  atualizarCamio(matricula: string, caracteristica: string, autonomia:number, capacidadeTransporte:number, capacidadeBateria:number,
    tara: number, tempoCarregamento:string): Observable<any>{

    this.verificarAtributos(matricula, caracteristica, autonomia, capacidadeTransporte, capacidadeBateria,tara, tempoCarregamento);
    
    const body = {"matricula":matricula,"caracteristica":caracteristica,
    "autonomia":autonomia, "capacidadeTransporte":capacidadeTransporte, "capacidadeBateria":capacidadeBateria, "tara": tara, "tempoCarregamento":tempoCarregamento}
    
    console.log(body);
    return this.httpClient.put(this.url, body).pipe(map(this.extractData));
  }
*/


  listarCamioes(): Observable<any> {
    return this.httpClient.get(this.url).pipe(map(this.extractData));
  }

  getCamiao(matricula: string): Observable<any> {
    return this.httpClient.get(this.url + '/:matricula' + matricula).pipe(
      map(this.extractData));
  }




  verificarAtributos(matricula: string, caracteristica: string, autonomia:number, capacidadeTransporte:number, capacidadeBateria:number,
    tara: number, tempoCarregamento:string): void {
      const MATRICULA_REGEX = new RegExp(/[A-Z]{2}-[0-9]{2}-[A-Z]{2}/);
      //verificar se os valores do camião estão corretos.
      if (autonomia < 90) {
        alert("Automia do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 90).");
      }
  
      if (capacidadeBateria < 55) {
        alert("Capacidade de Bateria do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 55).");
      }
  
      if (capacidadeTransporte < 800) {
        alert("Capacidade de Transporte do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 800).");
      }
  
      if (caracteristica == " ") {
        alert("Necessário inserir uma Característica do Camião Elétrico!");
      }
  
      if (tara < 1000) {
        alert("Capacidade de Transporte do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 800).");
      }
  
      if (!MATRICULA_REGEX.test(matricula)) {
        alert("Matrícula do Camião Elétrico não se apresenta no formato estipulado(formato exemplo = AA-00-ZZ).");
      }
  

  }



  public extractData(res: any) {
    return res || {};
  }

}
