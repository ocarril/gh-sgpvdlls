using System.Collections.Generic;

namespace CROM.BusinessEntities.Temporales.request
{
    public class BEDocumRegTMPCargoDescuentoBuscaRequest : BEBuscadorBaseRequest
    {
        public BEDocumRegTMPCargoDescuentoBuscaRequest()
        {
            keyTokenUser = string.Empty;
            LstcodDocumReg = new List<EntidadId>();
        }

        public string keyTokenUser { get; set; }

        public string codPersonaEntidad { get; set; }

        public int? codDocumReg { get; set; }

        public int? codCargoDescuento { get; set; }

        public List<EntidadId> LstcodDocumReg { get; set; }

        public string keyDocumRegCargoDescuento { get; set; }

        public string keyDocumRegDetalle { get; set; }

        /// <summary>
        /// 0=NUEVO; 1=REFER; 2=SAVED; 3=SAVED y REFER
        /// </summary>
        public int indOrigen { get; set; }
    }
}
