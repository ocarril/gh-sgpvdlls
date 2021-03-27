namespace CROM.BusinessEntities.Comercial.request
{
    using System;
    using System.Collections.Generic;


    public class DTODocumRegUpdateCancelPayRequest : BEBaseEntidadItem
    {
        public DTODocumRegUpdateCancelPayRequest()
        {

            gloObservaciones = string.Empty;
        }

        public int codDocumReg { get; set; }

        public string codDocumento { get; set; }

        public string codRegDocumento { get; set; }

        public string codRegEstadoDocu { get; set; }

        public DateTime? FechaCancelacion { get; set; }

        public string codParteDiario { get; set; }

        public string gloObservaciones { get; set; }
    }

}
