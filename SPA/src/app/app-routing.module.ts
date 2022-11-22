import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CriarCamiaoComponent } from './criar-camiao/criar-camiao.component';
import { MenuNavegacaoComponent } from './menu-navegacao/menu-navegacao.component';
import { AppComponent } from './app.component';
const routes: Routes = [
  {path: 'appRoot', component: AppComponent},
  {path: 'adicionarCamiao', component: CriarCamiaoComponent},
  {path: 'menuNav', component: MenuNavegacaoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
