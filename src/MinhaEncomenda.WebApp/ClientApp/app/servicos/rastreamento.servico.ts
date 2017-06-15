import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { ApiServico } from "../servicos/api.servico"
import { URLSearchParams, Response } from '@angular/http';


@Injectable()
export class RastreamentoServico {
    constructor(private apiServico: ApiServico) { }

    public obterRestreamento(codigo: string): Observable<Response> {
        return this.apiServico.get("/api/Rastreamento/", new URLSearchParams(codigo));
    }



}