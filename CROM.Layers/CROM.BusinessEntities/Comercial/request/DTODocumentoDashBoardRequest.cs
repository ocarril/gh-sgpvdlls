namespace CROM.BusinessEntities.Comercial.request
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;


    public class DTODocumentoDashBoardRequest : BEBuscadorBase
    {
        public DTODocumentoDashBoardRequest()
        {
            ListcodDocumentoSerie = new List<EntidadId>();
        }

        public string codRegDestino { get; set; }

        public string codPersonaEntidad { get; set; }

        public string codPuntoVenta { get; set; }

        public Nullable<DateTime > fecInicio { get; set; }

        public Nullable<DateTime> fecFinal { get; set; }

        public List<EntidadId> ListcodDocumentoSerie { get; set; }

        [JsonIgnore]
        public string fecInicioStr { get; set; }

        [JsonIgnore]
        public string fecFinalStr { get; set; }

    }
}
