namespace CROM.BusinessEntities.Comercial.emision.request
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 11/06/2020-10:02:47 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumRegNCRRequest.cs]
    /// Documento   : NOTA DE CRÉDITO
    /// </summary>
    public class BEDocumRegNCRNDBRequest : BEDocumRegBaseRequest
    {

        public BEDocumRegNCRNDBRequest()
        {

            numDocumentoOrigen = string.Empty;
            codDocumentoOrigen = string.Empty;
            gloMotivoSustento = string.Empty;
            perTributario = string.Empty;

        }

        public string codEmpresaRUC { get; set; }

        public Nullable<DateTime> fecVencimiento { get; set; }


        #region DATOS DE DOCUMENTO ORIGEN-REFERENCIA

        public string codDocumentoOrigen { get; set; }        

        public string numDocumentoOrigen { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        public int? codDocumRegOrigen { get; set; }

        public DateTime fecEmisionOrigen { get; set; }

        public decimal monTipoCambioVTAOrigen { get; set; }

        public int numCuotasOrigen { get; set; }

        #endregion


        public int? codMotivoNCR { get; set; }

        public int? codMotivoNDB { get; set; }

        public string gloMotivoSustento { get; set; }         

        public string perTributario { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }

        public bool indDocEsGravado { get; set; }

        public bool indDocEsFacturable { get; set; }
        
        public int numDiasCredito { get; set; }

    }
}
