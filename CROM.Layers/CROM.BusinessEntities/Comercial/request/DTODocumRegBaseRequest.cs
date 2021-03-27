namespace CROM.BusinessEntities.Comercial.request
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/06/2020-06:24:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumReg.cs]
    /// </summary>
    public class DTODocumRegBaseRequest : BEBaseEntidadItem
    {

        public DTODocumRegBaseRequest()
        {
            numDocUsuario = string.Empty;
            numDocumento = string.Empty;
            gloObservaciones = string.Empty;
            desNota01 = string.Empty;
            desNota02 = string.Empty;
            rznSocialUsuario = string.Empty;
            desDomicilioUsuario = string.Empty;
            codUbigeoNombre = string.Empty;

            lstDetalle = new List<DTODocumRegDetalleResponse>();
        }

        public int codDocumReg { get; set; }

        public string codTipoComprobante { get; set; }

        public string codDocumento { get; set; }

        public string codRegTipoDeOperacion { get; set; }

        public DateTime fecEmision { get; set; }

        public string codRegTipoDocumentoEntidad { get; set; }

        public string numDocUsuario { get; set; }

        public string rznSocialUsuario { get; set; }

        public int? codPersonaDomicilio { get; set; }

        public string desDomicilioUsuario { get; set; }

        public string codUbigeo { get; set; }

        public string codUbigeoNombre { get; set; }

        public string codRegTipoDomicilio { get; set; }

        public string codRegMoneda { get; set; }

        public int codEmpleado { get; set; }

        public decimal sumTotBruto { get; set; }

        public decimal prcIGV { get; set; }

        public decimal sumDescTotal { get; set; }

        public decimal sumTotValVenta { get; set; }

        public decimal sumTotTributos { get; set; }

        public decimal sumPrecioVenta { get; set; }

        public decimal sumPrecioVentaExtran { get; set; }

        public decimal sumOtrosCargos { get; set; }

        public decimal sumTotalAnticipos { get; set; }

        public decimal sumImpVenta { get; set; }

        public decimal sumTotValVentaGravada { get; set; }

        public string codEmpleadoPlanilla { get; set; }

        /**
         * ATRIBUTOS ADICIONALES
         */

        public string codRegDestinoDocum { get; set; }

        public string codRegEstado { get; set; }

        public int? codDocumentoEstado { get; set; }

        public string numDocumento { get; set; }

        public string codPersonaEntidad { get; set; }

        public string codPersonaContacto { get; set; }

        public int codCondicionVenta { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }

        public string codPuntoVenta { get; set; }

        public int codDocumentoSerie { get; set; }

        public string gloObservaciones { get; set; }

        public string desNota01 { get; set; }

        public string desNota02 { get; set; }


        public List<DTODocumRegDetalleResponse> lstDetalle { get; set; }


        //public string numOrdenDeCompra { get; set; }
        //public string numGuiaDeSalida { get; set; }
        //public string numPedidoAdquisicion { get; set; }
        //public Nullable<DateTime> fecDeDeclaracion { get; set; }
        //public bool flagEnviadoSUNAT { get; set; }
        //public Nullable<DateTime> fecEnviadoSUNAT { get; set; }
        //public string codLocalEmisor { get; set; }
        //public string tipDocUsuario { get; set; }
        //public string tipMoneda { get; set; }      
        
        //public int numTotalItems { get; set; }
        //public int numTotalLetras { get; set; } 
        //public string codDocumentoNombre { get; set; }
        //public string codRegTipoDomicilNombre { get; set; }
        //public string codRegEstadoNombre { get; set; }
        //public string codCondicionVentaNombre { get; set; }
        //public string codPuntoVentaNombre { get; set; }
        //public string codRegMonedaNombre { get; set; }
        //public string codEmpleadoNombre { get; set; }
        //public string codRegTipoDeOperacionNombre { get; set; }
        //public string codRegDestinoDocumNombre { get; set; }
        //public string numDocumentoDESTINO { get; set; }

    }

} 
