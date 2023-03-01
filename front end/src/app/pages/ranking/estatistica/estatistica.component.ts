import { Component, Input, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { estatistica } from 'src/app/share/models/pontuacao';
import { PontuacaoService } from '../../../share/services/http/pontuacao.service';

@Component({
  selector: 'app-estatistica',
  templateUrl: './estatistica.component.html',
  styleUrls: ['./estatistica.component.scss']
})
export class EstatisticaComponent implements OnInit {

  tipo_template=0;
  closeResult = '';
  @Input() public jogadorId:any;
  @Input() public nomejogador:any;
  estatistica: estatistica[]=[];

  constructor(
    public activeModal: NgbActiveModal,
    private pontuacaoService: PontuacaoService,
  ) { }

  ngOnInit(): void {
      this.tipo_template=1
      this.pontuacaoService.listarEstatisticaJogar(this.jogadorId).subscribe({
        next: resultado => {
          this.estatistica = resultado ;
        },
        error: () => {
          alert('Erro ao carregar dados');
        }
      }); 
  }
}
