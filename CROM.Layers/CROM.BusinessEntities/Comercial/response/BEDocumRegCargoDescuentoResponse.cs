using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.Comercial.response
{
    public class BEDocumRegCargoDescuentoResponse: BEBasePagedResponse
    {
        public BEDocumRegCargoDescuentoResponse()
        {

        }

        public int codEmpresa { get; set; }

        public int codDocumRegCargoDescuento { get; set; }

        public int? codDocumRegDetalle { get; set; }

        #region CUANDO ES EN TABLA TEMPORAL

        public Guid? keyDocumRegCargoDescuento { get; set; }

        public Guid? keyDocumRegDetalle { get; set; }

        public string keyTokenUser { get; set; }

        #endregion

        public string codPersonaEntidad { get; set; }

        public int? codDocumReg { get; set; }

        public string numItem { get; set; }

        public bool indNivelOrigen{ get; set; }

        public bool indTipoVariable { get; set; }


        public int codCargoDescuento { get; set; }

        public decimal prcItem { get; set; }

        public string codRegMonedaMontoItem { get; set; }

        public decimal mtoItem { get; set; }

        public string codRegMonedaBaseImpon { get; set; }

        public decimal mtoBaseImponible{ get; set; }



    }
}
