import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ranking } from '../../share/models/ranking';
import {  ViewChild, ElementRef  } from '@angular/core';
import { RankingService } from '../../share/services/http/ranking.service';
import { PontuacaoService } from '../../share/services/http/pontuacao.service';
import { pontuacao,estatistica } from '../../share/models/pontuacao';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { EstatisticaComponent } from './estatistica/estatistica.component';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.scss']
})
export class RankingComponent implements OnInit {

  constructor(
    private rankingService: RankingService,
    private pontuacaoService: PontuacaoService,
    private modalService: NgbModal
  ) { }

  estatistica = new estatistica();
  ranking : ranking[]=[];
  nomejogador: any;

  onClick(event: any)
  {
    var jogador = event.target.id.split("--");
    const activeModal = this.modalService.open(EstatisticaComponent, { size: 'lg' });
    activeModal.componentInstance.modalHeader = 'Estatistica';
    activeModal.componentInstance.jogadorId = jogador[0];
    activeModal.componentInstance.nomejogador = jogador[1];
  }
  
  ngOnInit(): void {
    this.ListaRanking()
  }

  ListaRanking() {
    this.rankingService.listar().subscribe({
    next: resultado => {
      this.ranking = resultado ;
    },
    error: () => {
      alert('Erro ao carregar dados');
    }
  }); 
  }

}
