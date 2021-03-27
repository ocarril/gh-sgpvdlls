namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;
    
    using CROM.BusinessEntities.Maestros;
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.Comprobantes.cs]
    /// </summary>
    public class DTODocumento : BEBasePagedResponse
    {
        public DTODocumento()
        {
            
        }

        public int codEmpresa { get; set; }

        public string codEmpresaRUC { get; set; }

        public string codDocumento { get; set; }

        public string codRegDocumentoNombre { get; set; }

        public string desNombre { get; set; }

        public string desAbreviatura { get; set; }

        public string codDocumentoAsociado { get; set; }

        public string codDocumentoAsosNombre { get; set; }

        public string codRegDestinoDocumentoNombre { get; set; }

        public string codRegTipoDeOperacionDefaultNombre { get; set; }
        
        public int numLineasDocumento { get; set; }
        
        public int IncidenciaEnStocks { get; set; }

        public int IncidenciaEnCtaCte { get; set; }

        public int IncidenciaEnCaja { get; set; }

        public bool EsComprobanteFiscal { get; set; }

        public bool EsComprobanteLocal { get; set; }

        public bool EsNumerAutomatica { get; set; }

        public bool EsGravado { get; set; }
  
    }
} 
