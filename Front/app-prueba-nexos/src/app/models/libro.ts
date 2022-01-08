import { Autor } from "./Autor";
import { Editorial } from "./Editorial";

export interface Libro{
    id?: number;
    titulo:string;
    anio:string;
    numeroPaginas:number;
    idEditorial:number;
    idAutor:number,
    autor:Autor,
    editorial:Editorial
}