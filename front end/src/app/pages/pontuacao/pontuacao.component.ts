import { Component, OnInit } from '@angular/core';
import { pontuacao,jogadores } from '../../share/models/pontuacao';
import { jogadoresService } from '../../share/services/http/jogadores.service';
import { PontuacaoService } from '../../share/services/http/pontuacao.service';

@Component({
  selector: 'app-pontuacao',
  templateUrl: './pontuacao.component.html',
  styleUrls: ['./pontuacao.component.scss']
})
export class PontuacaoComponent implements OnInit {

  constructor(
    private jogadoresService: jogadoresService, private pontuacaoService: PontuacaoService
  ) { }
 
  pontuacao = new pontuacao();
  jogadores : jogadores[]=[];

  // selectedJogador: any = "";
  // selectedStatus: any = "";

  ngOnInit(): void {
    this.ListaJogadores();
  }

  // onChange(changedDropdown: string) {
  //   alert(changedDropdown);
  //   if (changedDropdown === 'jogador') {
  //     this.selectedStatus = "";
  //   } else {
  //     this.selectedJogador = "";
  //   }
  // }

  ListaJogadores() {
      this.jogadoresService.listar().subscribe({
      next: resultado => {
        this.jogadores = resultado ;
      },
      error: () => {
        alert('Erro ao carregar dados');
      }
    }); 
  }

  salvar() {
    this.pontuacaoService.inserir(this.pontuacao).subscribe({
      next: retorno => {
        alert('Registro salvo com Sucesso');
        this.pontuacao = new pontuacao();
      },
      error: err => {
         alert('Erro ao salvar ' + err);
      }
    });
  }

}
