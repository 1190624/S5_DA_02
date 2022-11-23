import { Component, OnInit } from '@angular/core';
import { CamiaoService } from "src/app/services/camiao.service";
import { ActivatedRoute, Router } from '@angular/router';
import { Camiao } from '../model/camiao';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ReturnStatement } from '@angular/compiler';

@Component({
  selector: 'app-criar-camiao',
  templateUrl: './criar-camiao.component.html',
  styleUrls: ['./criar-camiao.component.css']
})
export class CriarCamiaoComponent implements OnInit {
  camiao: Camiao;
  matricula: string;
  caracteristica: string;
  autonomia: number;
  capacidadeTransporte: number;
  capacidadeBateria: number;
  tara: number;
  tempoCarregamento: string;



  constructor(private service: CamiaoService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }



  Submit(): void {


    const MATRICULA_REGEX = new RegExp(/^[A-Z]{2}-[0-9]{2}-[A-Z]{2}$/);
    //verificar se os valores do camião estão corretos.
    if (this.autonomia < 90) {
      alert("Automia do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 90).");
    } else if (this.capacidadeBateria < 55) {
      alert("Capacidade de Bateria do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 55).");
    } else if (this.capacidadeTransporte < 800) {
      alert("Capacidade de Transporte do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 800).");
    } else if (this.caracteristica == " ") {
      alert("Necessário inserir uma Característica do Camião Elétrico!");
    } else if (this.tara < 1000) {
      alert("Capacidade de Transporte do Camião Elétrico é inferior ao minímo estipulado(valor mínimo = 800).");
    } else if (!MATRICULA_REGEX.test(this.matricula)) {
      alert("Matrícula do Camião Elétrico não se apresenta no formato estipulado(formato exemplo = AA-00-ZZ).");
    } else {

      this.camiao = new Camiao(this.matricula, this.caracteristica, this.autonomia, this.capacidadeTransporte,
        this.capacidadeBateria, this.tara, this.tempoCarregamento);
      this.service.criarCamiao(this.matricula, this.caracteristica, this.autonomia, this.capacidadeTransporte,
        this.capacidadeBateria, this.tara, this.tempoCarregamento).subscribe(data => { alert("O camião foi criado.") });
    }



  }



  Return(): void {
    this.router.navigate(['/appRoot']);
  }
}




/*
//Get inputs from the boxes
var matricula = document.getElementById('matricula') as HTMLInputElement; 
var caracteristica = document.getElementById('caracteristica') as HTMLInputElement;
var autonomia = document.getElementById('autonomia') as HTMLInputElement;
var capacidadeTransporte= document.getElementById('autonomia') as HTMLInputElement;
var capacidadeBateria= document.getElementById('capacidadeTransporte') as HTMLInputElement;
var tara= document.getElementById('tara') as HTMLInputElement;
var tempoCarregamento= document.getElementById('tempoCarregamento') as HTMLInputElement;
 
/*           this.service.criarCamiao(this.formBuilder.group({
  matricula:matricula.value, 
  caracteristica: caracteristica.value,
  autonomia:autonomia.value,
  capacidadeTransporte:capacidadeTransporte.value,
  capacidadeBateria: capacidadeBateria.value,
  tara:tara.value,
  tempoCarregamento: tempoCarregamento.value
}).value).subscribe(data => { alert("O camião foi criado.") });
 
/*
matricula.value='';
caracteristica.value='';
autonomia.valueAsNumber=0;
capacidadeTransporte.valueAsNumber=0; 
capacidadeBateria.valueAsNumber=0;
tara.valueAsNumber=0;
tempoCarregamento.value='';
*/ 