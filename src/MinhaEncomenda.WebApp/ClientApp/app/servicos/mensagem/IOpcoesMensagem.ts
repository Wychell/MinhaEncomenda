interface IOpcoesMensagem {
    title: string;
    msg?: string;
    showClose?: boolean;
    theme?: string;
    timeout?: number;
    onAdd?: Function;
    onRemove?: Function;
    codigo: string;
    tipoMensagem?: any;
}