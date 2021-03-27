namespace CROM.BusinessEntities.Comercial.response
{
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/04/2018-06:24:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumReg.cs]
    /// </summary>
    public class DTOSunatDocumRegResponse : BEBase
    {
        public DTOSunatDocumRegResponse()
        {

        }

        public int codDocumReg { get; set; }

        public string codRegEstadoDocuNombre { get; set; }

        public string numDocumento { get; set; }

        public int numTotalItems { get; set; }

        public int numTotalLetras { get; set; }

        public string codCondicionVentaNombre { get; set; }

        public DateTime fecEmision { get; set; }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public Nullable<DateTime> fecProceso { get; set; }

        public Nullable<DateTime> fecCancelacion { get; set; }

        public Nullable<DateTime> fecAnulacion { get; set; }

        public string codRegAnulacionNombre { get; set; }

        public string numRUC { get; set; }

        public string nomRazonSocial { get; set; }

        public string codRegMonedaNombre { get; set; }


        public decimal prcIGV { get; set; }

        public decimal monTotalBruto { get; set; }

        public decimal monTotalDescuento { get; set; }

        public decimal monTotalVenta { get; set; }

        public decimal monTotalImpuesto { get; set; }

        public decimal monTotalPrecioVenta { get; set; }

        public decimal monTotalPrecioExtran { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }

        public string numDocumentoDESTINO { get; set; }

        public string numDocumentoORIGEN { get; set; }

        public string codDocumentoNombre { get; set; }

        public string codRegTipoDomicilNombre { get; set; }

        public string codRegTipoOperacionNombre { get; set; }

        public string codPuntoVentaNombre { get; set; }

        public string numDocumentoNCR { get; set; }

        public string codDocumentoNCR { get; set; }

        public string numDocumentoNDB { get; set; }


        public string codDocumentoNDB { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }

        public string numLetrasDeCambio { get; set; }

        public bool indDocEsGravado { get; set; }

        public Nullable<DateTime> fecDeEntrega { get; set; }

        public Nullable<DateTime> fecDeRecibido { get; set; }

        public Nullable<DateTime> fecDeDeclaracion { get; set; }

        public string perTributario { get; set; }
    }

}
