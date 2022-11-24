import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Armazem } from '../model/armazem';
import { ArmazemService } from '../services/armazem/armazem.service';

@Component({
  selector: 'app-criar-armazem',
  templateUrl: './criar-armazem.component.html',
  styleUrls: ['./criar-armazem.component.css']
})
export class CriarArmazemComponent implements OnInit {
  armazem: Armazem;
  identificador: string;
  designacao: string;
  codigoPostal: string;
  numeroPorta: number;
  nomeRua: string;
  localidade: string;
  pais: string;
  municipio: string;
  latitude: number;
  longitude: number;

  constructor(private service : ArmazemService, private route: ActivatedRoute, private router:Router) { }


  ngOnInit(): void {
  }

  Submit(): void {

    const CODIGO_POSTAL_REGEX = new RegExp(/^[0-9]{4}-[0-9]{3}$/);

    if (this.identificador == null) {
      alert("Necessário inserir um Id do Armazém!");
    } else if (this.designacao == null) {
      alert("Necessário inserir uma Designação do Armazém!.");
    } else if (!CODIGO_POSTAL_REGEX.test(this.codigoPostal)) {
      alert("O Código Postal não se apresenta no formato correto!");
    } else if (this.numeroPorta < 0) {
      alert("O número da Porta não pode ser um número negativo!");
    } else if (this.nomeRua == null) {
      alert("Necessário inserir uma Rua!");
    } else if (this.localidade == null) {
      alert("Necessário inserir uma Localidade!");
    } else if (this.pais == null) {
      alert("Necessário inserir um País!");
    } else if (this.municipio == null) {
      alert("Necessário inserir um Município!");
    } else if (this.latitude < -90) {
      alert("A latitude deve ser um número entre -90 e 90!");
    } else if (this.latitude > 90) {
      alert("A latitude deve ser um número entre -90 e 90!");
    } else if (this.longitude < -180) {
      alert("A longitude deve ser um número entre -180 e 180!");
    } else if (this.longitude > 180) {
      alert("A longirude deve ser um número entre -180 e 180!");
    } else {

    this.armazem = new Armazem(this.identificador, this.designacao, this.codigoPostal, this.numeroPorta,
      this.nomeRua, this.localidade, this.pais, this.municipio, this.latitude, this.longitude);
    this.service.criarArmazem(this.identificador, this.designacao, this.codigoPostal, this.numeroPorta,
      this.nomeRua, this.localidade, this.pais, this.municipio, this.latitude, this.longitude).subscribe(data => {alert("O armazém foi criado.")});
    
  }
}

  Return(): void{
    this.router.navigate(['/menuNav']);
  }
}
