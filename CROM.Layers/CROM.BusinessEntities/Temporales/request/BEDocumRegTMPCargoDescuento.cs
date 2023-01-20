namespace CROM.BusinessEntities.Temporales.request
{
    using Newtonsoft.Json;
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 27/11/2021-19:38:45
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Temporales.FWDocumRegCargoDescuento.cs]
    /// </summary>
    public class BEDocumRegTMPCargoDescuento : BEBaseEntidadItem
    {
        public BEDocumRegTMPCargoDescuento()
        {

        }
                
        public Guid? keyDocumRegCargoDescuento { get; set; }

        public Guid? keyDocumRegDetalle { get; set; }

        public string keyTokenUser { get; set; }

        public string codPersonaEntidad { get; set; }

        public int? codDocumReg { get; set; }



        public string numItemCargoDescuento { get; set; }

        public bool indNivelOrigenCargoDescuento { get; set; }

        public bool indTipoVariableCargoDescuento { get; set; }

        public string codItemDetalleCargoDescuento { get; set; }

        public int codCargoDescuentoVariable { get; set; }

        public decimal prcItemCargoDescuento { get; set; }

        public string codRegMonedaMontoItem { get; set; }

        public decimal mtoItemCargoDescuento { get; set; }

        public string codRegMonedaBaseImpon { get; set; }

        public decimal mtoBaseImponibleCargoDescuento { get; set; }




        public string codRegMonedaSelect { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }

        public string codRegDestinoDocum { get; set; }

    }
} 
