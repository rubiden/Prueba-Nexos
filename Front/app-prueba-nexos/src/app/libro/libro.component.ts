import { Component, OnInit } from '@angular/core';
import { ApilibroService } from '../service/apilibro.service';
import { Libro } from '../models/libro';
import { Filtro } from '../models/filtro';

@Component({
  selector: 'app-libro',
  templateUrl: './libro.component.html',
  styleUrls: ['./libro.component.css']
})
export class LibroComponent implements OnInit {

public libro: Libro[] = [];

public error: string = '';

public filtro: Filtro ={
  autor: '',
  titulo: '',
  anio: ''
}

  constructor(
    private _libroService: ApilibroService,
  ) { 
  }

  ngOnInit(): void {
  }

  getLibrosXFiltro(){
    this._libroService.getLibrosXFiltro(this.filtro).subscribe( response => {      
      this.libro = response;
    }, err => {
      if(err.status === 404){
        this.error = "No se encontraron libros";
      }
      if(err.status === 500){
        this.error = "Error en el servidor";
      }
  })
    this.filtro = {
      autor: '',
      titulo: '',
      anio: ''
    }
  }

}
