import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RankingComponent } from './pages/ranking/ranking.component';
import { PontuacaoComponent } from './pages/pontuacao/pontuacao.component';

const routes: Routes = [
  { path: '', component: RankingComponent },
  { path: 'pontuacao', component: PontuacaoComponent },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
