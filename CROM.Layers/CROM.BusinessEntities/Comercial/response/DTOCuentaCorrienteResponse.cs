namespace CROM.BusinessEntities.Comercial.response
{
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 24/09/2020-19:26:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.CuentasCorrientes.cs]
    /// </summary>
    public class DTOCuentaCorrienteResponse : BEBasePagedResponse
    {
        public DTOCuentaCorrienteResponse()
        {
            codRegMonedaNombre = string.Empty;
            codEmpleadoNombre = string.Empty;

            codPersonaEntidad = string.Empty;
            codPuntoVentaNombre = string.Empty;
            codDocumentoNombre = string.Empty;
            codRegTipoOperacionNombre = string.Empty;
            codRegDestinoDocumNombre = string.Empty;
            codPersonaEntidadNombre = string.Empty;
            codDocumentoTipo = string.Empty;
            numDocumentoRefer = string.Empty;
        }

        public int codCuentaCorriente { get; set; }
        public int codDocumReg { get; set; }
        public int codEmpresa { get; set; }

        public int? codCajaRegistro { get; set; }
        public string codRegMoneda { get; set; }
        public int codEmpleado { get; set; }
        public string codParteDiario { get; set; }
        public Nullable<DateTime> fecEmisionDeuda { get; set; }
        public Nullable<DateTime> fecVencimiento { get; set; }
        public int numCuota { get; set; }
        public string indTipoIngreso { get; set; } //[D]Debe [H]Haber 

        public decimal monDEBETotalCuotaNacion { get; set; }
        public decimal monDEBETotalCuotaExtran { get; set; }
        public decimal monDEBETipoCambioVTA { get; set; }
        public decimal monDEBETipoCambioCMP { get; set; }

        public decimal monHABERTotalPagoNacion { get; set; }
        public decimal monHABERTotalPagoExtran { get; set; }
        public decimal monHABERTipoCambioVTA { get; set; }
        public decimal monHABERTipoCambioCMP { get; set; }

        public decimal monDHDiferenciaMonto { get; set; }
        public string gloObservacion { get; set; }




        public string numDocumento { get; set; }
        public string codPuntoVenta { get; set; }
        public string codDocumento { get; set; }
        public string codRegTipoOperacion { get; set; }
        public string codRegDestinoDocum { get; set; }
        public string codPersonaEntidad { get; set; }
        public string numPersonaEntidadRUC { get; set; }
        public string codPersonaEntidadNombre { get; set; }
        public string codRegDestinoDocumNombre { get; set; }
        public string codRegTipoOperacionNombre { get; set; }
        public string codDocumentoNombre { get; set; }
        public string codPuntoVentaNombre { get; set; }
        public string codRegMonedaNombre { get; set; }
        public string codEmpleadoNombre { get; set; }

        public string codDocumentoTipo     { get; set; }
        public string numDocumentoRefer { get; set; }
    }
}
