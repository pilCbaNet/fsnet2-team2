import { Transacciones } from "./Transacciones.model";

export interface CuentaActiva{
    idCuenta: number;
    idCliente:number;
    numero_de_cuenta: number;
    monto: number;
    alias:string;
    cbu:number;
    estado:boolean;
    transacciones:Transacciones[];
}