namespace CROM.BusinessEntities.Comercial.request
{
    public class DTOParteDiarioCloseRequest : BEBaseEntidadRequest
    {
        public DTOParteDiarioCloseRequest()
        {

        }


        public int codDocumReg { get; set; }

        public string codParteDiario { get; set; }

        public string codPuntoVenta { get; set; }

        public decimal TotalIngreso { get; set; }

        public decimal TotalEgreso { get; set; }

    }
}
