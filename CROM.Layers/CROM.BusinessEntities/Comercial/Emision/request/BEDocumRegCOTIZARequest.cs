namespace CROM.BusinessEntities.Comercial.emision.request
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/08/2020-19:30:47 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumRegCOTIZARequest.cs]
    /// Documento   : COTIZACIONES
    /// </summary>
    public class BEDocumRegCOTIZARequest : BEDocumRegBaseRequest
    {

        public BEDocumRegCOTIZARequest()
        {

            numDocumento = string.Empty;
            numDocUsuario = string.Empty;
            numLetrasCambio = string.Empty;
            numDiasCredito = 0;
            numSerieDatoRefer = string.Empty;
            numSerieDatoRefer = string.Empty;

        }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public int? codEmpleadoVendedor { get; set; }
        
        public Nullable<DateTime> fecEntrega{ get; set; }
                          
        public string numLetrasCambio { get; set; }

        public string numSerieDatoRefer { get; set; }

        public bool indImprimeFirma { get; set; }

        public bool indImprimeSinIGV { get; set; }

        public string nomAtencionEmpresa { get; set; }

        public int numDiasCredito { get; set; }

        public Nullable<DateTime> fecVencimientoCOT { get; set; }

    }
}
