import { Injectable } from '@angular/core';
import * as _ from 'underscore';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';


enum TipoMensagem {
    Sucesso,
    Erro,
    Info
}

@Injectable()
export class MensagemServico implements IMensagemServico {

    private mensagem: IOpcoesMensagem[];
    private tempo = 5000;
    private tema = 'material';
    private fecharJanela = true;

    constructor(private toastyService: ToastyService, private toastyConfig: ToastyConfig) {
        this.mensagem = [];
        this.adicionarMensagem()
    }


    public mostra(codigo: string) {
        let opcao = this.mensagem.find(x => x.codigo === codigo);
        if (opcao == null || opcao == undefined)
            opcao = this.mensagem[0];

        switch (opcao.tipoMensagem) {
            case TipoMensagem.Erro: this.toastyService.error(opcao); break
            case TipoMensagem.Sucesso: this.toastyService.success(opcao); break
            case TipoMensagem.Info: this.toastyService.info(opcao); break
        }
    }
    public adicionarMensagemPersonalizada(texto: string) { }
    private geramMensagem(codigo: string, texto: string, tipo: TipoMensagem) {
        this.mensagem.push({ codigo: codigo, title: codigo, msg: texto, theme: this.tema, showClose: this.fecharJanela, timeout: this.tempo, tipoMensagem: tipo });
    }
    private adicionarMensagem() {
        this.geramMensagem("00000000", "Mensagem não cadastrada", TipoMensagem.Info);
        this.geramMensagem("RAST0001", "Não foi possivel localizar informações", TipoMensagem.Erro);
        this.geramMensagem("RAST0002", "ERRO", TipoMensagem.Erro);
    }

};