import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-navegacao',
  templateUrl: './menu-navegacao.component.html',
  styleUrls: ['./menu-navegacao.component.css']
})
export class MenuNavegacaoComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

}
