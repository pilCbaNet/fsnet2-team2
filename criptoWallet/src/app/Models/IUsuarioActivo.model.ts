import { CuentaActiva } from "./ICuentaActivs.model";

export interface UsuarioActivo{
    idCliente:number
    nombre: string;
    apellido: string;
    email: string;
    password: string;
    domicilio: string;
    idLocalidad: number;
    estado: boolean;
    cuentasBancaria:CuentaActiva[];
}