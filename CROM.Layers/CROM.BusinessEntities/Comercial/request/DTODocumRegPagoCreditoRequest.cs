namespace CROM.BusinessEntities.Comercial.request
{
    using System;
    using System.Collections.Generic;


	public class DTODocumRegCreditoRequest : BEBaseEntidadRequest
	{
		public DTODocumRegCreditoRequest()
		{
			LstDocumRegPagoCredito = new List<DTODocumRegPagoCreditoRequest>();

		}

		public int codDocumReg { get; set; }

		public decimal mtoNetoPendientePago { get; set; }

		public int codCondicionFormaPago { get; set; }

		public int numDiasGracia { get; set; }

		public string codRegTipoPlazo { get; set; }

		public string codPersonaBanco { get; set; }

		public string codPersonaAval { get; set; }

		public List<DTODocumRegPagoCreditoRequest> LstDocumRegPagoCredito { get; set; }

		public int numCuotas { get; set; }
	}

	public class DTODocumRegPagoCreditoRequest : BEBaseEntidadRequest
	{

		public DTODocumRegPagoCreditoRequest()
		{
			mtoCuotaPago = 0;
			mtoCuotaPagoME = 0;
			gloComentario = string.Empty;
			segMaquinaCrea = string.Empty;
			segUsuarioCrea = string.Empty;
			segUsuarioEdita = string.Empty;
		}

		public int codDocumRegPagoCredito { get; set; }

		public int codDocumReg { get; set; }

		public decimal mtoCuotaPago { get; set; }

		public decimal mtoCuotaPagoME { get; set; }

		public DateTime fecCuotaPago { get; set; }

		public string numLetraInterno { get; set; }

		public string gloComentario { get; set; }

		public int codDocumentoEstado { get; set; }

	}

	public class DTODocumRegPagoCreditoUpdateRequest : BEBaseEntidadItem
	{

		public DTODocumRegPagoCreditoUpdateRequest()
		{
			gloComentario = string.Empty;
			segUsuarioEdita = string.Empty;
		}

		public int codDocumRegPagoCredito { get; set; }

		public int codDocumReg { get; set; }

		public DateTime fecRecepcion { get; set; }

		public string gloComentario { get; set; }

		public int codDocumentoEstado { get; set; }

		public int? codCajaRegistro { get; set; }

	}

	public class DTODocumRegPagoCreditoUpdateDataRequest : BEBaseEntidadRequest
	{

		public DTODocumRegPagoCreditoUpdateDataRequest()
		{
			mtoCuotaPago = 0;
			mtoCuotaPagoME = 0;
			gloComentario = string.Empty;
			segMaquinaCrea = string.Empty;
			segUsuarioCrea = string.Empty;
			segUsuarioEdita = string.Empty;
		}

		public int codDocumRegPagoCredito { get; set; }

		public int codDocumReg { get; set; }

		public decimal mtoCuotaPago { get; set; }

		public decimal mtoCuotaPagoME { get; set; }

		public DateTime fecRecepcion { get; set; }

		public string numLetraExterno { get; set; }

		public string gloComentario { get; set; }

		public int codDocumentoEstado { get; set; }

	}

}
