export interface Movimientos{
    fechaHoraTransaccion: Date;
    monto:number;
    cuentaDestino:number;
    cuentaOrigen:number;
    idCuenta:number;
    idTipoMovimientos:number;
}