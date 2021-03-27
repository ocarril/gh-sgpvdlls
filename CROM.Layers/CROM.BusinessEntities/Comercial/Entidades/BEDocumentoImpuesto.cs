namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/09/2010-6:51:18
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ComprobantesImpuestos.cs]
    /// </summary>
    public class BEDocumentoImpuesto : BEBase
    {
        public BEDocumentoImpuesto()
        {
            objImpuesto = new BEImpuesto();
            objDocumento = new BEDocumento();
        }

        public int codDocumentoImpuesto { get; set; }
        public string CodigoComprobante { get; set; }
        public string CodigoImpuesto { get; set; }
        public bool VeoImporte { get; set; }
        public int Orden { get; set; }
                
        public BEImpuesto objImpuesto { get; set; }
        public BEDocumento objDocumento { get; set; }

        ////[NotMapped]
        public string CodigoComprobanteNombre { get; set; }
        ////[NotMapped]
        public string CodigoImpuestoNombre { get; set; }

    }
}
