namespace CROM.BusinessEntities.Temporales.request
{
    public class BEDocumRegTMPDetalleInsertRequest : BEBaseMaestro
    {
        public BEDocumRegTMPDetalleInsertRequest()
        {
            keyTokenUser = string.Empty;
        }

        public string keyTokenUser { get; set; }

        public int? codDocumReg { get; set; }

        public bool indGravadoIGV { get; set; }
    }
}
