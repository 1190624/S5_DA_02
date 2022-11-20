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
  camiao!: Camiao;
  matricula: string = ''; 
  caracteristica: string = '';
  autonomia:number = 0;
  capacidadeTransporte:number = 0;
  capacidadeBateria:number = 0;
  tara: number = 0;
  tempoCarregamento:string = '';
  
  
  
  constructor(private formBuilder: FormBuilder, private service : CamiaoService, private route: ActivatedRoute, private router:Router) { }

  ngOnInit(): void {
  }

/*   public criarCamiao():void{
    this.service.criarCamiao(matricula: string, caracteristica: string, autonomia:number, capacidadeTransporte:number, capacidadeBateria:number,
      tara: number, tempoCarregamento:string)
      this.camiao = data}) */
    
      Submit(): void {
        //Get inputs from the boxes
        var matricula = document.getElementById('matricula') as HTMLInputElement; 
        var caracteristica = document.getElementById('caracteristica')as HTMLInputElement;
        var autonomia = document.getElementById('autonomia') as HTMLInputElement;
        var capacidadeTransporte= document.getElementById('autonomia') as HTMLInputElement;
        var capacidadeBateria= document.getElementById('capacidadeTransporte') as HTMLInputElement;
        var tara= document.getElementById('tara') as HTMLInputElement;
        var tempoCarregamento= document.getElementById('tempoCarregamento') as HTMLInputElement;



        var title = document.getElementById('title') as HTMLInputElement;
        var description = document.getElementById('description') as HTMLInputElement;
        var tags = document.getElementById('tags') as HTMLInputElement;
    
/*         //Check if the posts inputs are valid.
        if (title.value.length < 1 || description.value.length < 1) {
          alert("The post format is incorrect. Try again.");
        } else {
          //Getting the author of the post and the date
          var author = this.playerName;
          var date = new Date(); */
  
           //Publish the post
          this.camiao = new Camiao(matricula.value, caracteristica.value, autonomia.valueAsNumber, capacidadeTransporte.valueAsNumber, 
            capacidadeBateria.valueAsNumber, tara.valueAsNumber, tempoCarregamento.value);
          this.service.criarCamiao(this.camiao).subscribe(data => { alert("O camião foi criado.") });
          
           
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

          matricula.value='';
          caracteristica.value='';
          autonomia.valueAsNumber=0;
          capacidadeTransporte.valueAsNumber=0; 
          capacidadeBateria.valueAsNumber=0;
          tara.valueAsNumber=0;
          tempoCarregamento.value='';
          
        }
      


      Return(): void{
        this.router.navigate(['/menuNav']);
      }
  }


