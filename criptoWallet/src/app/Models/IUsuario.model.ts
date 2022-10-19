import { UsuarioRegistrado } from "./IUsuarioRegistrado.model";

export interface Usuario{
    nombre: string;
    apellido: string;
    email: string;
    password: string;
    address: string;
    city: string;
    terms: boolean;
    usuarioRegistrado: UsuarioRegistrado;
}