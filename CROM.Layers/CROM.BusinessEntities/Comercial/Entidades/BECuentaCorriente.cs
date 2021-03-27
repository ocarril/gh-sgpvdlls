namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.CuentasCorrientes.cs]
    /// </summary>
    public class BECuentaCorriente
    {
        public BECuentaCorriente()
        {
            CodigoPersonaEmpre = string.Empty;
            CodigoPersonaEntidad = string.Empty;
            CodigoPersonaEmpreNombre = string.Empty;
            CodigoPuntoVentaNombre = string.Empty;
            CodigoComprobanteNombre = string.Empty;
            CodigoArguTipoMovimiNombre = string.Empty;
            CodigoArguMonedaNombre = string.Empty;
            CodigoArguDestinoCompNombre = string.Empty;
            auxcodEmpleadoNombre = string.Empty;
            CodigoPersonaEntidadNombre = string.Empty;
        }

        public int codDocumReg { get; set; }
        public int codEmpresa { get; set; }
        public int NumeroOperacion { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public string CodigoArguTipoMovimi { get; set; }
        public string CodigoArguMoneda { get; set; }
        public string CodigoArguDestinoComp { get; set; }
        public int? codEmpleado { get; set; }

        public int? codCajaRegistro { get; set; }

        public string CodigoParte { get; set; }
        public Nullable<DateTime> FechaDeEmisionDeuda { get; set; }
        public Nullable<DateTime> FechaDeVencimiento { get; set; }

        public int NumeroDeCuota { get; set; }

        public string TipoDeIngreso { get; set; } //[D]Debe [H]Haber 

        public decimal DEBETotalCuotaNacion { get; set; }
        public decimal DEBETotalCuotaExtran { get; set; }
        public decimal DEBETipoCambioVTA { get; set; }
        public decimal DEBETipoCambioCMP { get; set; }

        public decimal HABERTotalPagoNacion { get; set; }
        public decimal HABERTotalPagoExtran { get; set; }
        public decimal HABERTipoCambioVTA { get; set; }
        public decimal HABERTipoCambioCMP { get; set; }

        public decimal DHDiferenciaMonto { get; set; }
        public string Observaciones { get; set; }
        public int Anio { get; set; }
        public Int16 Mes { get; set; }
        public int Dia { get; set; }

        public bool Estado { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoPersonaEntidad { get; set; }
        public string CodigoPersonaEmpreNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }
        public string CodigoComprobanteNombre { get; set; }
        public string CodigoArguTipoMovimiNombre { get; set; }
        public string CodigoArguMonedaNombre { get; set; }
        public string CodigoArguDestinoCompNombre { get; set; }
        public string auxcodEmpleadoNombre { get; set; }
        public string CodigoPersonaEntidadNombre { get; set; }

        public string OrigenDato { get; set; }
        public string ESTADO { get; set; }
    }
} 
