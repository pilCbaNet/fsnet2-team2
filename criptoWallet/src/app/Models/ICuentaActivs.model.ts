import { Movimientos } from "./IMovimientos";

export interface CuentaActiva{
    idCuenta: number;
    idCliente:number;
    numeroDeCuenta: number;
    monto: number;
    alias:string;
    cbu:number;
    estado:boolean;
    transacciones:Movimientos[];
}