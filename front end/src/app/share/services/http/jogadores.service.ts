import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { HttpBaseService } from "src/app/core/http-base.service";
import { jogadores } from "src/app/share/models/pontuacao";

@Injectable()
export class jogadoresService extends HttpBaseService {
    constructor(protected http: HttpClient) {
        super(http);
    }

    public listar(): Observable<jogadores[]> {
        return this.get(`/Jogadores`);
    }
}