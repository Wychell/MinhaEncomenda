import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { ApiServico } from "../servicos/api.servico"
import { URLSearchParams, Response } from '@angular/http';


@Injectable()
export class RastreamentoServico {
    constructor(private apiServico: ApiServico) { }

    public obterRestreamento(codigo: string): Observable<Rastreamento[]> {
        return this.apiServico.get("/api/Rastreamento/", new URLSearchParams(codigo))
            .map(x => <Rastreamento[]>x.json())
            .catch(resposta => { return Observable.throw(resposta.json()); });
    }

}