export interface Movimientos{
     id: number,
    numeroDeCuenta:string,
    tipoDeTransaccion:string,
    cuentaReceptor:string,
    receptorNombre:string,
    monto: number,
    fecha: Date
}