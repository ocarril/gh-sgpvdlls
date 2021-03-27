namespace CROM.BusinessEntities.Caja.request
{
    using CROM.BusinessEntities.Cajas;
    using Newtonsoft.Json;

    public class DTOCajaRegistroConciliarRequest : BEBaseEntidadRequest
    {

        public DTOCajaRegistroConciliarRequest()
        {

        }

        public string codPuntoVenta { get; set; }

        public int codDocumReg { get; set; }

        public string codParteDiario { get; set; }

        public bool indConciliado { get; set; }

    }
}
