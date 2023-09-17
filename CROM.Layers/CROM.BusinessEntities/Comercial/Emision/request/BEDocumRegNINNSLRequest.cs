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
    /// Documento   : NOTA DE INGRESO
    /// </summary>
    public class BEDocumRegNINNSLRequest : BEDocumRegBaseRequest
    {

        public BEDocumRegNINNSLRequest()
        {

            perTributario = string.Empty;
            codEmpresaRUC = string.Empty;
        }

        public string codEmpresaRUC { get; set; }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public string perTributario { get; set; }

        public int? codDepositoOrigen { get; set; }

        public int? codDepositoDestino { get; set; }
    }
}
