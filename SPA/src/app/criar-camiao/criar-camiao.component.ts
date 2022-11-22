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
  autonomia:number;
  capacidadeTransporte:number;
  capacidadeBateria:number;
  tara: number;
  tempoCarregamento:string;
  
  
  
  constructor(private service : CamiaoService, private route: ActivatedRoute, private router:Router) { }

  ngOnInit(): void {
  }


    
      Submit(): void {

          this.camiao = new Camiao(this.matricula, this.caracteristica, this.autonomia, this.capacidadeTransporte, 
            this.capacidadeBateria, this.tara, this.tempoCarregamento);
          this.service.criarCamiao(this.matricula, this.caracteristica, this.autonomia, this.capacidadeTransporte, 
            this.capacidadeBateria, this.tara, this.tempoCarregamento).subscribe(data => { alert("O camião foi criado.") });
        /*
        //Get inputs from the boxes
        var matricula = document.getElementById('matricula') as HTMLInputElement; 
        var caracteristica = document.getElementById('caracteristica') as HTMLInputElement;
        var autonomia = document.getElementById('autonomia') as HTMLInputElement;
        var capacidadeTransporte= document.getElementById('autonomia') as HTMLInputElement;
        var capacidadeBateria= document.getElementById('capacidadeTransporte') as HTMLInputElement;
        var tara= document.getElementById('tara') as HTMLInputElement;
        var tempoCarregamento= document.getElementById('tempoCarregamento') as HTMLInputElement;

  
  /*
          this.camiao = new Camiao(matricula.value, caracteristica.value, autonomia.valueAsNumber, capacidadeTransporte.valueAsNumber, 
            capacidadeBateria.valueAsNumber, tara.valueAsNumber, tempoCarregamento.value);
          this.service.criarCamiao(this.camiao).subscribe(data => { alert("O camião foi criado.") });
          */
           
/*           this.service.criarCamiao(this.formBuilder.group({
            matricula:matricula.value, 
            caracteristica: caracteristica.value,
            autonomia:autonomia.value,
            capacidadeTransporte:capacidadeTransporte.value,
            capacidadeBateria: capacidadeBateria.value,
            tara:tara.value,
            tempoCarregamento: tempoCarregamento.value
          }).value).subscribe(data => { alert("O camião foi criado.") });
    
          //Cleaning input boxes after submission
          title.value = '';
          tags.value = '';
          description.value = ''; */
/*
          matricula.value='';
          caracteristica.value='';
          autonomia.valueAsNumber=0;
          capacidadeTransporte.valueAsNumber=0; 
          capacidadeBateria.valueAsNumber=0;
          tara.valueAsNumber=0;
          tempoCarregamento.value='';
         */ 
          
        }
      


      Return(): void{
        this.router.navigate(['/appRoot']);
      }
  }


