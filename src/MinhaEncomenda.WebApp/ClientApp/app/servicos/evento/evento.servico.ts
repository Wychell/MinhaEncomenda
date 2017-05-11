import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class EventoServico {
    emissor = new EventEmitter();

};