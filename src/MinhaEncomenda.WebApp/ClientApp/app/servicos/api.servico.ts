import { Injectable } from "@angular/core";
import { Http, URLSearchParams, Response  } from '@angular/http';
import { Observable } from "rxjs/Observable";

@Injectable()
export class ApiServico {
    constructor(private http: Http) {
    }

    public get(url: string, parametros: URLSearchParams = new URLSearchParams()): Observable<Response> {
        return this.http.get(`${url}${parametros}`);
    }


    public post(url: string, objeto :any):Observable<Response> {
        return this.http.post(url, objeto);
    }
    
}