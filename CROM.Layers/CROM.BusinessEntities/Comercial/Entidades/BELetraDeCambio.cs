namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 24/01/2012-03:48:42 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.LetraDeCambio.cs]
    /// </summary>
    public class BELetraDeCambio
    {
        public int codDocumReg { get; set; }
        public int codEmpresa { get; set; }

        public int? codDocumRegPagoCredito { get; set; }
        public string codPersonaEmpre { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public string numLetraInterna { get; set; }
        public string numLetraExterno { get; set; }
        public string codPersonaEmisor { get; set; }
        public DateTime fecEmision { get; set; }
        public Nullable<DateTime> fecRecepcion { get; set; }
        public DateTime fecVencimiento { get; set; }
        public string codRegistroMoneda { get; set; }
        public decimal? monValorDeLetra { get; set; }
        public string codPersonaAsignado { get; set; }
        public string codPersonaAvalista { get; set; }
        public string codPersonaBanco { get; set; }
        public string desClausula { get; set; }
        public string gloComentario { get; set; }
        public string codRegistroEstado { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }
    }

    public class LetraDeCambioAux : BELetraDeCambio
    {
        public string auxcodPersonaEmpreNombre { get; set; }
        public string auxcodPuntoDeVentaNombre { get; set; }
        public string auxcodDocumentoNombre { get; set; }
        public string auxcodPersonaEmisorNombre { get; set; }
        public string auxcodRegistroMonedaNombre { get; set; }
        public string auxcodPersonaAsignadoNombre { get; set; }
        public string auxcodPersonaAvalistaNombre { get; set; }
        public string auxcodPersonaBancoNombre { get; set; }
        public string auxcodRegistroEstadoNombre { get; set; }
        public string auxindDocumento { get; set; }
        public decimal? auxmonImportePagadoMonNac { get; set; }
        public decimal? auxmonImportePagadoMonInt { get; set; }
        public decimal? auxmonImporteSaldo { get; set; }
        public string auxdesLetraCambio { get; set; }
        public string numDocumentoExterno { get; set; }

        public string auxdesMovDetaProducto { get; set; }
        public string auxdesMovDetaCantidad { get; set; }
        public string auxdesMovDetaPrecio { get; set; }
        // Nuevos Datos
        public string auxcodPersonaAsignadoDireccion { get; set; }
        public string auxcodPersonaAsignadoLugar { get; set; }

        public string auxdesMontoEnLetras { get; set; }
        public string auxcodRegistroMonedaSimbolo { get; set; }

    }
} 
