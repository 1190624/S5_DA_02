import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { CriarCamiaoComponent } from './criar-camiao/criar-camiao.component';
import { HttpClientModule } from '@angular/common/http';
import { CriarArmazemComponent } from './criar-armazem/criar-armazem.component';
import { CriarEntregaComponent } from './criar-entrega/criar-entrega.component';
import { MenuHeaderComponent } from './menu-header/menu-header.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ListarCamiaoComponent } from './listar-camiao/listar-camiao.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuHeaderComponent,
    CriarCamiaoComponent,
    CriarArmazemComponent,
    CriarEntregaComponent,
    DashboardComponent,
    ListarCamiaoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
