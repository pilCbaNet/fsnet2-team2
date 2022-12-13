import { Movimientos } from "./IMovimientos";

export interface Transacciones{
    idCuenta: number;
    idCliente:number;
    numeroDeCuenta: number;
    monto: number;
    alias:string;
    cbu:number;
    estado:boolean;
    transaccion:Movimientos;
}