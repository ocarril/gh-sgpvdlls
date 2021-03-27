namespace CROM.BusinessEntities.Comercial.DTO
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
    /// Archivo     : [GestionComercial.ComprobanteEmision.cs]
    /// </summary>
    public class vwComprobanteEmision
    {
        public vwComprobanteEmision()
        {

        }
        public int codDocumReg { get; set; }

        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }

        public string CodigoComprobante { get; set; }//
        public string NumeroComprobante { get; set; } //
        public string CodigoArguEstadoDocu { get; set; }//
        public string CodigoArguDestinoComp { get; set; }//
        public string CodigoPersonaEntidad { get; set; }//
        public string CodigoPersonaEmpleado { get; set; }//
        public DateTime FechaDeEmision { get; set; }//
        public Nullable<DateTime> FechaDeVencimiento { get; set; }//
        public Nullable<DateTime> FechaDeCancelacion { get; set; }//
        public Nullable<DateTime> FechaDeAnulacion { get; set; }//
        public Nullable<DateTime> FechaDeDeclaracion { get; set; }//

        public string CodigoArguMoneda { get; set; }//
        public decimal ValorIGV { get; set; } // MEMORIA

        public string CodigoParte { get; set; }//
        public decimal ValorTotalBruto { get; set; }//
        public decimal ValorTotalDescuento { get; set; }//
        public decimal ValorTotalVenta { get; set; }//
        public decimal ValorTotalImpuesto { get; set; }//
        public decimal ValorTotalPrecioVenta { get; set; }//
        public decimal ValorTotalPrecioExtran { get; set; }// MEMORIA

        public decimal ValorTotalVentaGravada { get; set; }//
        public decimal ValorTotalImpuestoGravada { get; set; }//
        public decimal ValorTotalHistorico { get; set; }//

        public string CodigoComprobanteDESTINO { get; set; }
        public string NumeroComprobanteDESTINO { get; set; }//
        public string CodigoComprobanteORIGEN { get; set; }
        public string NumeroComprobanteORIGEN { get; set; }//

        public Nullable<DateTime> FechaComprobanteORIGEN { get; set; }
        public decimal ValorTipoCambioORIGEN { get; set; }


        public string CodigoComprobanteNCR { get; set; }
        public string NumeroComprobanteNCR { get; set; }//
        public string CodigoComprobanteNDB { get; set; }
        public string NumeroComprobanteNDB { get; set; }//

        public string CodigoArguMotivoGuia { get; set; }

        public string CodigoPersonaTransporte { get; set; }
        public string codRegTipoDomicilioTransporte { get; set; }//
        public string codRegUbigeoTransporte { get; set; }
        public string desDireccionTransporte { get; set; }//

        public string DireccioDePartida { get; set; }
        public string TransporteMarca { get; set; }
        public string TransportePlaca { get; set; }
        public string TransporteConstancia { get; set; }
        public string TransporteLicencia { get; set; }

        public string DocOrdenDeCompra { get; set; }
        public string DocGuiaDeSalida { get; set; }
        public string DocPedidoAdquisicion { get; set; }
        public string DocLetrasCambio { get; set; }
        public string Observaciones { get; set; }
        public string CondicionVenta { get; set; }
        public string CondicionCompra { get; set; }

        public string EntidadRazonSocial { get; set; }//
        public string CodigoArguTipoDomicil { get; set; }//
        public string EntidadDireccion { get; set; }//
        public string EntidadNumeroRUC { get; set; }//

        public string CodigoComprobanteSecun { get; set; }
        public string NumeroComprobanteSecun { get; set; }
        public string CodigoPuntoVentaSecun { get; set; }

        public string CodigoPersonaVendedor { get; set; }
        public string CodigoComprobanteFact { get; set; }
        public string NumeroSerie { get; set; }
        public string NumeroMinuta { get; set; }
        public string CodigoArguDepositoDesti { get; set; }//
        public string CodigoArguDepositoOrigen { get; set; }//
        public string NumeroComprobanteExt { get; set; }//

        public bool DocEsGravado { get; set; }//MEMORIA
        public bool DocExigeDocAnexo { get; set; }//MEMORIA
        public bool DocEsFacturable { get; set; }//MEMORIA
        public decimal ValorTipoCambioVTA { get; set; }//
        public decimal ValorTipoCambioCMP { get; set; }//
        public bool LogicoFiltro { get; set; }//MEMORIA
        public bool CHECKED_DECLARA { get; set; }//MEMORIA
        public string CodigoArguAnulacion { get; set; }

        public string CodigoArguTipoDeOperacion { get; set; }
        public string Nota01 { get; set; }
        public string Nota02 { get; set; }
        public string Nota03 { get; set; }

        public Nullable<DateTime> FechaDeEntrega { get; set; }
        public Nullable<DateTime> FechaDeRecibido { get; set; }
        public string CodigoArguUbigeo { get; set; }
        public string EntidadDireccionUbigeo { get; set; }

        public bool Estado { get; set; }//MEMORIA

        public DateTime FechaDeProceso { get; set; }
        public string CodigoRegistroUnico { get; set; }
        public int SegAnio { get; set; }
        public Int16 SegMes { get; set; }
        public Int16 SegDia { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }
        public int? codGastoDeAduana { get; set; }

        public string CodigoPersonaEmpreNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }
        public string CodigoComprobanteNombre { get; set; }
        public string CodigoArguEstadoDocuNombre { get; set; }
        public string CodigoArguDestinoCompNombre { get; set; }
        public string CodigoPersonaEntidadNombre { get; set; }
        public string CodigoPersonaEmpleadoNombre { get; set; }
        public string CodigoArguMonedaNombre { get; set; }
        public string CodigoArguMotivoGuiaNombre { get; set; }

        public string CodigoPersonaTransporteNombre { get; set; }
        public string CodigoPersonaTransporteRUC { get; set; }

        public string CodigoArguAnulacionNombre { get; set; }
        public string CodigoArguTipoDomicilNombre { get; set; }
        public string CondicionVentaNombre { get; set; }
        public string CondicionCompraNombre { get; set; }
        public string CodigoPuntoVentaSecunNombre { get; set; }
        public string CodigoPersonaVendedorNombre { get; set; }
        public string CodigoArguTipoDeOperacionNombre { get; set; }

        public string CodigoPersonaEntidadContacto { get; set; }//
        public string CodigoPersonaEntidadContactoNombre { get; set; }//

        public string REF_CodigoPersonaEntidadContactoTelefono { get; set; }//
        public string REF_CodigoPersonaEntidadContactoEmail { get; set; }//
        public string REF_CodigoPersonaVendedorArea { get; set; }
        public string REF_CodigoPersonaVendedorEmail { get; set; }
        public string REF_CodigoPersonaVendedorTelefono { get; set; }
        public string REF_CodigoArguMonedaSimbolo { get; set; }//
        public string REF_ValorTotalPrecioVentaLetras { get; set; }//
        public string REF_TextoDeLeyenda { get; set; }//

        public string CodigoComprobanteDESTINONombre { get; set; }
        public string CodigoComprobanteORIGENNombre { get; set; }
        public string CodigoArguDepositoDestiNombre { get; set; }
        public string CodigoArguDepositoOrigenNombre { get; set; }

        public int REF_TotalItems { get; set; }
        public int REF_TotalLetras { get; set; }

        public bool indInternacional { get; set; }
        public string perTributario { get; set; }//
        public string desTotalCaja { get; set; }
        public string desTotalPeso { get; set; }

        public string auxcodRegTipoDomicilioTransporteNombre { get; set; }//
        public string auxcodRegUbigeoTransporteNombre { get; set; }

        public string auxcodRegTipoEntidad { get; set; }
        public string auxcodRegTipoEntidadNombre { get; set; }
        public string auxEntidadNumeroDNI { get; set; }// 

        public string auxDescripcionDetalle { get; set; }// 
    }
} 
