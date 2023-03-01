import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { HttpBaseService } from "src/app/core/http-base.service";
import { ranking } from "src/app/share/models/ranking";

@Injectable()
export class RankingService extends HttpBaseService {
    constructor(protected http: HttpClient) {
        super(http);
    }

    public listar(): Observable<ranking[]> {
        return this.get(`/Jogadores/JogadoresRanking`);
    }
}