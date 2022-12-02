import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CriarCamiaoComponent } from './criar-camiao/criar-camiao.component';
import { CriarArmazemComponent } from './criar-armazem/criar-armazem.component';
import { AppComponent } from './app.component';
import { CriarEntregaComponent } from './criar-entrega/criar-entrega.component';
import { MenuHeaderComponent } from './menu-header/menu-header.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ListarCamiaoComponent } from './listar-camiao/listar-camiao.component';
import { ListarEntregaComponent } from './listar-entrega/listar-entrega.component';

const routes: Routes = [
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: 'appRoot', component: AppComponent},
  {path: 'adicionarCamiao', component: CriarCamiaoComponent},
  {path: 'adicionarArmazem', component: CriarArmazemComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'adicionarEntrega', component: CriarEntregaComponent},
  {path: 'listarCamiao' , component: ListarCamiaoComponent},
  {path: 'listarEntrega', component: ListarEntregaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
