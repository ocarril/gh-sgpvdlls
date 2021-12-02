namespace CROM.BusinessEntities.Temporales.response
{
    using Newtonsoft.Json;
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 14/05/2020-22:20:45
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Temporales.DocumRegDetalle.cs]
    /// </summary>
    public class BEDocumRegTMPCargoDescuentoResponse : BEBasePagedResponse
    {
        public BEDocumRegTMPCargoDescuentoResponse()
        {

        }

        [JsonIgnore]
        public int codEmpresa { get; set; }

        public Guid? keyDocumRegCargoDescuento { get; set; }

        public Guid? keyDocumRegDetalle { get; set; }

        public string keyTokenUser { get; set; }

        public string codPersonaEntidad { get; set; }

        public int? codDocumReg { get; set; }



        public string numItem { get; set; }

        public string gloDocumRegDetalleItem { get; set; }



        public string indNivelOrigenNombre { get; set; }

        public string indTipoVariableNombre { get; set; }



        public int codCargoDescuento { get; set; }

        public string codCodigoKey { get; set; }

        public string codCargoDescuentoNombre { get; set; }

        public string codCargoDescuentoItem { get; set; }



        public decimal prcItem { get; set; }



        public string codRegMonedaMontoItem { get; set; }

        public string codRegMonedaMontoItemNombre { get; set; }

        public string codRegMonedaMontoItemSimbolo { get; set; }

        public decimal mtoItem { get; set; }



        public string codRegMonedaBaseImpon { get; set; }

        public string codRegMonedaBaseImponNombre { get; set; }

        public string codRegMonedaBaseImponSimbolo { get; set; }

        public decimal mtoBaseImponible { get; set; }



        public bool indEstado { get; set; }

    }
} 
