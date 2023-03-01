import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { HttpBaseService } from "src/app/core/http-base.service";
import { pontuacao,estatistica } from "src/app/share/models/pontuacao";

@Injectable()
export class PontuacaoService extends HttpBaseService {
    constructor(protected http: HttpClient) {
        super(http);
    }

    public inserir(pontos: pontuacao): Observable<pontuacao> {
        return this.post('/pontuacao', pontos);
    }

    public listarEstatisticaJogar(id:any): Observable<estatistica[]> {
        let parameters = "/EstatisticaJogador?id=" + id;
        return this.get(`/Pontuacao${parameters}`);
    }
}