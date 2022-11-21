import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { MenuNavegacaoComponent } from './menu-navegacao/menu-navegacao.component';
import { CriarCamiaoComponent } from './criar-camiao/criar-camiao.component';
import { HttpClientModule } from '@angular/common/http';
import { CriarArmazemComponent } from './criar-armazem/criar-armazem.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuNavegacaoComponent,
    CriarCamiaoComponent,
    CriarArmazemComponent
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
