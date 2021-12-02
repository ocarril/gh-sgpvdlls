namespace CROM.BusinessEntities.Temporales.response
{
    using System;


    public class BEDocumRegTMPPagoCreditoResponse : BEBasePagedResponse
	{

		public BEDocumRegTMPPagoCreditoResponse()
		{
			mtoCuotaPago = 0;
			mtoCuotaPagoME = 0;
			segUsuarioEdita = string.Empty;
		}

		public Guid? keyDocumRegPagoCredito { get; set; }

		public string keyTokenUser { get; set; }

		public string codPersonaEntidad { get; set; }

		public int codDocumRegRef { get; set; }



		public int codDocumReg { get; set; }

		public decimal mtoCuotaPago { get; set; }

		public decimal mtoCuotaPagoME { get; set; }

		public decimal mtoTipoCambioVTA { get; set; }

		public DateTime fecCuotaPago { get; set; }

		public string numLetraInterno { get; set; }

        public int codDocumentoEstado { get; set; }

        public string codDocumentoEstadoNombre { get; set; }

        public string codDocumentoEstadoColor { get; set; }

        public string desDocumento { get; set; }

        public string numDocumento { get; set; }

        public string nomEmpresaRUC { get; set; }

        public string nomRazonSocial { get; set; }

        public string codRegMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string gloComentario { get; set; }

        public string codRegDocumento { get; set; }

        public string codRegEstado { get; set; }
    }
}
