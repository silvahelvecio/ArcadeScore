import { NgModule,LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { PontuacaoComponent } from './pages/pontuacao/pontuacao.component';
import { RankingComponent } from './pages/ranking/ranking.component';
import { jogadoresService } from './share/services/http/jogadores.service';
import { PontuacaoService } from './share/services/http/pontuacao.service';
import { RankingService } from './share/services/http/ranking.service';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule,NgbDateNativeAdapter,NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EstatisticaComponent } from './pages/ranking/estatistica/estatistica.component';

registerLocaleData(localePt);
@NgModule({
  declarations: [
    AppComponent,
    PontuacaoComponent,
    RankingComponent,
    EstatisticaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,   
  ],
  providers: [jogadoresService,PontuacaoService,RankingService],
  bootstrap: [AppComponent]
})
export class AppModule { }



