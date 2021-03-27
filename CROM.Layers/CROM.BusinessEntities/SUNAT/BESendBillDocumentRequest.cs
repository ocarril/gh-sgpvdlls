namespace CROM.BusinessEntities.SUNAT
{
    public class BESendBillDocumentRequest
    {
        public BESendBillDocumentRequest()
        {
            Username = string.Empty;
            Password = string.Empty;
            fileName = string.Empty;
            contentFile = string.Empty;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string fileName { get; set; }

        public string contentFile { get; set; }
    }
}
