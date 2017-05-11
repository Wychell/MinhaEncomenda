import { Component, ViewChild } from '@angular/core';
import { EventoServico } from '../../servicos/evento/evento.servico';
import { DirectionsRenderer } from 'ng2-map';


@Component({
    selector: 'app',
    template: require('./app.component.html'),
    styles: [require('./app.component.css')]
})
export class AppComponent {
    @ViewChild(DirectionsRenderer) directionsRendererDirective: DirectionsRenderer;
    private rastreamento: Rastreamento[];
    private cidades: string[];
    private cidadeOrigem: string = "";
    private cidadeDestino: string = "";
    private destino = <any>{ origin: this.cidadeOrigem, destination: this.cidadeDestino, travelMode: "DRIVING" };
    private waypoints: any;

    constructor(private evento: EventoServico) {
        evento.emissor.subscribe(
            rastro => {
                this.cidades = this.filtrarCidades(rastro);
                this.cidadeDestino = "";
                this.cidadeOrigem = "";
                this.waypoints = [];
                if (rastro[0].statusEvento.toLowerCase().search("entregue") == 7) {
                    this.destino = this.preparaDestino(this.cidades);
                } else {
                    this.cidadeOrigem = this.cidades[0];
                    this.cidadeDestino = this.cidadeOrigem;
                    this.destino = {
                        origin: this.cidadeOrigem, destination: this.cidadeDestino, travelMode: "DRIVING"
                    }
                }
                this.directionsRendererDirective.showDirections(this.destino);
            }
        );
    }

    private filtrarCidades(data) {
        this.rastreamento = data.filter(x => x.cidade !== "" && x.cidade.toLowerCase().search("bra") != 0 && x.cidade.toLowerCase().search("fis") != 0)
        return this.rastreamento.map(x => x.cidade).filter((v, i, self) => self.indexOf(v) === i);
    }

    private preparaDestino(cidades: string[]) {
        this.cidadeOrigem = cidades[this.cidades.length - 1];
        this.cidadeDestino = cidades[0];
        cidades.splice(cidades.indexOf(this.cidadeOrigem), 1);
        cidades.splice(cidades.indexOf(this.cidadeDestino), 1);
        this.waypoints = this.preparaCaminho(cidades);
        return { origin: this.cidadeOrigem, destination: this.cidadeDestino, travelMode: "DRIVING", waypoints: this.waypoints };
    }

    private preparaCaminho(cidades: string[]) {
        var way = [];
        for (var i = cidades.length - 1; i >= 0; i--) {
            way.push({
                location: cidades[i],
                stopover: false
            })
        }
        return way;
    }
}
