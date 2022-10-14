import { usuarioRegistrado } from "./IUsuarioRegistrado.model";

export interface Usuario{
    //id: number;
    nombre: string;
    apellido: string;
    email: string;
    password: string;
    address: string;
    city: string;
    terms: boolean;
    usuarioRegistrado: usuarioRegistrado;
}