namespace CROM.BusinessEntities.Cajas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Comercial;
    
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/11/2010-6:34:45
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [CajaBancos.ComprobanteEmitidos.cs]
    /// </summary>
    public class BECajaRegistro
    {
        public BECajaRegistro()
        {

        }
        public int codDocumReg { get; set; }

        public int numItem { get; set; }
        public int codEmpresa { get; set; }
        public string codEmpresaRUC { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public int? codEmpleado { get; set; }
        public string codParteDiario { get; set; }
        public int codFormaDePago { get; set; }
        public DateTime fecIngreso { get; set; }
        public string codRegistroMoneda { get; set; }
        public decimal monImporteRecibido { get; set; }
        public decimal monImportePagado { get; set; }
        public decimal monImportePagadoEx { get; set; }
        public decimal monImporteVuelto { get; set; }
        public decimal monTCambioVTA { get; set; }
        public decimal monTCambioCMP { get; set; }
        public string gloObservacion { get; set; }
        public bool indConciliado { get; set; }

        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }
    }

    public class CajaRegistroAux : BECajaRegistro
    {
        public CajaRegistroAux()
        {
            listaCuentaCorriente = new List<BECuentaCorriente>();
        }
        public string auxcodEmpleadoNombre { get; set; }
        public string auxcodFormaDePagoNombre { get; set; }
        public string auxcodRegistroMonedaNombre { get; set; }
        public string auxcodPersonaEmpreNombre { get; set; }
        public string auxcodPuntoDeVentaNombre { get; set; }
        public string auxcodDocumentoNombre { get; set; }
        public decimal auxMontoPagado_MonNac { get; set; }
        public decimal auxMontoPagado_MonInt { get; set; }
        public List<BECuentaCorriente> listaCuentaCorriente { get; set; }

        public string auxnumLetraExterno { get; set; }
        public DateTime? fecCuotaPago { get; set; } //fecVencimientoLetra
    }
} 
