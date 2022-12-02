import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Armazem } from '../model/armazem';
import { ArmazemService } from '../services/armazem/armazem.service';

@Component({
  selector: 'app-listar-armazem',
  templateUrl: './listar-armazem.component.html',
  styleUrls: ['./listar-armazem.component.css']
})
export class ListarArmazemComponent implements OnInit {
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

  constructor(private service: ArmazemService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.service.listaArmazens();
  }

}