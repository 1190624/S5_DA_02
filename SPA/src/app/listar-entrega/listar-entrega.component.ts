import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Entrega } from '../model/entrega';
import { EntregaService } from '../services/entrega/entrega.service';

@Component({
  selector: 'app-listar-entrega',
  templateUrl: './listar-entrega.component.html',
  styleUrls: ['./listar-entrega.component.css']
})
export class ListarEntregaComponent implements OnInit { 
  entrega: Entrega;
  identificador: string;
  armazemID: string;
  dia:number;
  mes:number;
  ano:number;
  massa: number;
  tempoColocacao: number;
  tempoRetirada: number;

  constructor(private service : EntregaService, private route:ActivatedRoute, private router:Router) { }

  ngOnInit(): void {
    this.service.listaEntregas();
  }

}