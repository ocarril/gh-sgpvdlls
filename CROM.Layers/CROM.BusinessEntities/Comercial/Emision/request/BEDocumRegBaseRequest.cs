namespace CROM.BusinessEntities.Comercial.emision.request
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
    public class BEDocumRegBaseRequest : BEBaseEntidadItem
    {

        public BEDocumRegBaseRequest()
        {
            numDocUsuario = string.Empty;
            numDocumento = string.Empty;
            gloObservaciones = string.Empty;
            desNota01 = string.Empty;
            desNota02 = string.Empty;
            rznSocialUsuario = string.Empty;
            desDomicilioUsuario = string.Empty;
            codUbigeoNombre = string.Empty;

            lstDetalle = new List<BEDocumRegDetalleRequest>();
            lstImpuestos = new List<BEDocumRegImpuestoRequest>();
            lstCargoDescuentos = new List<BEDocumRegCargoDescuentoRequest>();
        }

        public int codDocumReg { get; set; }

        public string numDocumento { get; set; }

        public string codTipoComprobante { get; set; }

        public string codPuntoVenta { get; set; }

        public int codDocumentoSerie { get; set; }

        public string codDocumento { get; set; }

        public string codRegTipoDeOperacion { get; set; }

        public DateTime fecEmision { get; set; }

        public int codEmpleado { get; set; }


        #region DATOS DEL CLIENTE-USUARIO

        public string codPersonaEntidad { get; set; }

        public string codPersonaContacto { get; set; }

        public string codRegTipoDocumentoEntidad { get; set; }

        public string numDocUsuario { get; set; }

        public string rznSocialUsuario { get; set; }

        public int? codPersonaDomicilio { get; set; }

        public string desDomicilioUsuario { get; set; }

        public string codUbigeo { get; set; }

        public string codUbigeoNombre { get; set; }

        public string codRegTipoDomicilio { get; set; }

        #endregion


        public int? codCondicionVenta { get; set; }

        public int? codCondicionCompra { get; set; }

        public string codRegMoneda { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }

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


        /**
         * ATRIBUTOS ADICIONALES
         **/

        public string codEmpleadoPlanilla { get; set; }

        public string codRegDestinoDocum { get; set; }


        public string codRegEstado { get; set; }

        public int? codDocumentoEstado { get; set; }



        public bool indDocExigeDocAnexo { get; set; }

        public string codPuntoVentaSecun { get; set; }

        public string codDocumentoSecun { get; set; }

        public string numDocumentoSecun { get; set; }       
        


        public string gloObservaciones { get; set; }

        public string desNota01 { get; set; }

        public string desNota02 { get; set; }


        public List<BEDocumRegDetalleRequest> lstDetalle { get; set; }

        public List<BEDocumRegImpuestoRequest> lstImpuestos { get; set; }

        public List<BEDocumRegCargoDescuentoRequest> lstCargoDescuentos { get; set; }

    }

} 
