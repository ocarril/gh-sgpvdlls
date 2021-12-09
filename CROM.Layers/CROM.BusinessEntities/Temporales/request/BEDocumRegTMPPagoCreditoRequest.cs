namespace CROM.BusinessEntities.Temporales.request
{
    using System;
    using System.Collections.Generic;


	public class BEDocumRegTMPCreditoRequest : BEBaseEntidadRequest
	{
		public BEDocumRegTMPCreditoRequest()
		{
			LstDocumRegPagoCredito = new List<BEDocumRegTMPPagoCreditoRequest>();

		}

		public string keyTokenUser { get; set; }

		public string codPersonaEntidad { get; set; }

		public int codDocumRegRef { get; set; }

		public int codDocumReg { get; set; }

		public decimal mtoNetoPendientePago { get; set; }

		public int codCondicionFormaPago { get; set; }

		public int numDiasGracia { get; set; }

		public string codRegTipoPlazo { get; set; }

		public string codPersonaBanco { get; set; }

		public string codPersonaAval { get; set; }

		public List<BEDocumRegTMPPagoCreditoRequest> LstDocumRegPagoCredito { get; set; }

		public int numCuotas { get; set; }

        public DateTime fecVencimiento { get; set; }

		public string codRegMoneda { get; set; }
		public bool indFromEmisionNCR { get; set; }

	}

	public class BEDocumRegTMPPagoCreditoRequest : BEBaseEntidadRequest
	{

		public BEDocumRegTMPPagoCreditoRequest()
		{
			mtoCuotaPago = 0;
			mtoCuotaPagoME = 0;
			gloComentario = string.Empty;
			segMaquinaCrea = string.Empty;
			segUsuarioCrea = string.Empty;
			segUsuarioEdita = string.Empty;
		}

		public Guid? keyDocumRegPagoCredito { get; set; }

		public string keyTokenUser { get; set; }

		public string codPersonaEntidad { get; set; }

		public int codDocumRegRef { get; set; }


		public int codDocumReg { get; set; }

		public decimal mtoCuotaPago { get; set; }

		public decimal mtoCuotaPagoME { get; set; }

		public DateTime fecCuotaPago { get; set; }

		public string numLetraInterno { get; set; }

		public string gloComentario { get; set; }

		public int codDocumentoEstado { get; set; }

	}

	public class BEDocumRegTMPPagoCreditoUpdateRequest : BEBaseEntidadItem
	{

		public BEDocumRegTMPPagoCreditoUpdateRequest()
		{
			gloComentario = string.Empty;
			segUsuarioEdita = string.Empty;
		}


		public string keyDocumRegPagoCredito { get; set; }

		public string keyTokenUser { get; set; }

		public string codPersonaEntidad { get; set; }

		public int codDocumRegRef { get; set; }


		public int codDocumReg { get; set; }

		public DateTime fecRecepcion { get; set; }

		public string gloComentario { get; set; }

		public int codDocumentoEstado { get; set; }


	}

	public class BEDocumRegTMPPagoCreditoUpdateDataRequest : BEBaseEntidadRequest
	{

		public BEDocumRegTMPPagoCreditoUpdateDataRequest()
		{
			mtoCuotaPago = 0;
			mtoCuotaPagoME = 0;
			gloComentario = string.Empty;
			segMaquinaCrea = string.Empty;
			segUsuarioCrea = string.Empty;
			segUsuarioEdita = string.Empty;
		}


		public Guid? keyDocumRegPagoCredito { get; set; }

		public string keyTokenUser { get; set; }

		public string codPersonaEntidad { get; set; }

		public int codDocumRegRef { get; set; }



		public int codDocumReg { get; set; }

		public decimal mtoCuotaPago { get; set; }

		public decimal mtoCuotaPagoME { get; set; }

		public DateTime fecRecepcion { get; set; }

		public string numLetraExterno { get; set; }

		public string gloComentario { get; set; }

		public int codDocumentoEstado { get; set; }

	}

}
