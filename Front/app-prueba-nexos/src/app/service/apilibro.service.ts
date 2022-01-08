import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, timeout } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Filtro } from '../models/filtro';

@Injectable({
  providedIn: 'root'
})
export class ApilibroService {

  

  constructor(
    private _http: HttpClient
  ) { }

  getLibrosXFiltro(filtro: Filtro):Observable<any>{
    let url = 'https://localhost:44322/api/Libro/GetLibrosXFiltro?';
    url = url +"autor="+ filtro.autor +"&titulo="+ filtro.titulo+"&anio="+ filtro.anio
    return this._http.get<any>(url)
    .pipe(
      map((response: any) => {
        return response;
      }),
      catchError(error => {
        throw error;       
      })
    )
  }
}
