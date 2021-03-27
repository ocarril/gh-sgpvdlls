namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/02/2012-03:37:17 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.GastoDeAduana.cs]
    /// </summary>
    public class BEGastoDeAduana
    {
        public int codDocumReg { get; set; }
        public int? codDocumRegDestino { get; set; }

        public int codGastoDeAduana { get; set; }
        public string codPersonaEmpre { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public string codRegistroGasto { get; set; }
        public decimal monValorDeGasto { get; set; }
        public Nullable<DateTime> fecDePago { get; set; }
        public string gloComentario { get; set; }
        public bool indCancelado { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }
        public string codRegistroMoneda { get; set; }
        public string codDocumentoDest { get; set; }
        public string numDocumentoDest { get; set; }
        public string codPersonaEmpreDest { get; set; }
        public string codPuntoDeVentaDest { get; set; }
    }

    public class GastoDeAduanaAux : BEGastoDeAduana
    {
        public string auxcodPersonaEmpreNombre { get; set; }
        public string auxcodPuntoDeVentaNombre { get; set; }
        public string auxcodRegistroGastoNombre { get; set; }

        public string auxcodRegistroMonedaNombre { get; set; }
        public Nullable<DateTime> auxFechaDeEmisionFactura { get; set; }
        public decimal? auxmonValorTipoCambioVTA { get; set; }//
        public decimal? auxmonValorTipoCambioCMP { get; set; }//
        public string auxnumNumeroComprobanteExt { get; set; }
        public string auxcodPersonaEntidad { get; set; }
        public string auxcodPersonaEntidadNombre { get; set; }

        public string auxcodDocumentoNombre { get; set; }
        public string auxcodDocumentoNombreDest { get; set; }

        public string auxcodRegistroMonedaNombreDest { get; set; }
        public Nullable<DateTime> auxFechaDeEmisionFacturaDest { get; set; }
        public decimal? auxmonValorTipoCambioVTADest { get; set; }
        public decimal? auxmonValorTipoCambioCMPDest { get; set; }
        public string auxnumNumeroComprobanteExtDest { get; set; }
        public string auxcodPersonaEntidadDest { get; set; }
        public string auxcodPersonaEntidadNombreDest { get; set; }

        public decimal? monSoles { get; set; }
        public decimal? monDolar { get; set; }

        public decimal? auxmonSolesTotalDocumento { get; set; }
        public decimal? auxmonDolarTotalDocumento { get; set; }

    }
}
 
