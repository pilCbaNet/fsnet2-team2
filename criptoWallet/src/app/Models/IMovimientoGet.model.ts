export interface MovimientosGet{
    fechaHoraTransaccion:Date;
    monto:number;
    cuentaDestino:string;
    cuentaOrigen:string;
    idCuenta:number;
    idTipoMovimientos:number;
}