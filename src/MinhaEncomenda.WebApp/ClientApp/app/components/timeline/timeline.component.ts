
import { Component, Input, OnChanges, Inject } from '@angular/core';
import { EventoServico } from '../../servicos/evento.servico';
import { Http } from '@angular/http';

import { RastreamentoServico } from '../../servicos/rastreamento.servico'


@Component({
    selector: 'timeline',
    template: require('./timeline.component.html'),
    styles: [require('./timeline.component.css')],
    providers: [RastreamentoServico]

})


export class TimelineComponent implements OnChanges {
    public rastreamentos: Rastreamento[]
    public numero = "";
    public http: Http;
    @Input() valor: string;
    public toastOptions: any;

    constructor(http: Http, private evento: EventoServico, @Inject('IMensagemServico') private mensagem: IMensagemServico, private rastreamentoServico: RastreamentoServico) {
        this.http = http;

        // Add see all possible types in one shot
    }

    ngOnChanges() {
        if (this.valor != undefined && this.valor != null && this.valor.length == 13) {
            if (this.numero.toLocaleLowerCase() == this.valor.toLocaleLowerCase())
                return;
            this.buscarDados();
        }
    }

    public buscarDados() {
        this.rastreamentoServico
            .obterRestreamento(this.valor).subscribe(data => {
                this.rastreamentos = data.json();
                this.numero = this.rastreamentos[0].numero;
                this.evento.emissor.emit(this.rastreamentos);
            },
            (retorno) => {
                this.mensagem.mostra(retorno.json().codigo);
                this.numero = ""
                this.rastreamentos = [];
                this.evento.emissor.emit(this.rastreamentos);
            });
    }
}



