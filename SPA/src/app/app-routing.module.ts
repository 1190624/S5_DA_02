import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CriarCamiaoComponent } from './criar-camiao/criar-camiao.component';
import { CriarArmazemComponent } from './criar-armazem/criar-armazem.component';
import { AppComponent } from './app.component';
import { CriarEntregaComponent } from './criar-entrega/criar-entrega.component';
import { MenuHeaderComponent } from './menu-header/menu-header.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: 'appRoot', component: AppComponent},
  {path: 'adicionarCamiao', component: CriarCamiaoComponent},
  {path: 'adicionarArmazem', component: CriarArmazemComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'adicionarEntrega', component: CriarEntregaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
