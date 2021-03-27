namespace CROM.BusinessEntities.Cajas.response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 14/11/2020-05:08:32 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [DTOCuentaBancariaResponse.cs]
    /// </summary>
    public class DTOCuentaBancariaResponse : BEBasePagedResponse
    {
        public DTOCuentaBancariaResponse()
        {
            desNumeroCuenta = string.Empty;
            gloObservacion = string.Empty;
            codPersonaBancoNombre = string.Empty;
            codRegMonedaNombre = string.Empty;
            codRegTipoCuentaNombre = string.Empty;
            codPersonaEmpresaNombre = string.Empty;
            desNumeroCCI = string.Empty;
        }

        public int codCuentaBancaria { get; set; }
        public string codPersonaEmpresa { get; set; }
        public string codPersonaBanco { get; set; }
        public string codRegMoneda { get; set; }
        public string codRegTipoCuenta { get; set; }
        public string desNumeroCuenta { get; set; }

        public string desNumeroCCI { get; set; }

        public DateTime fecApertura { get; set; }
        public Nullable<DateTime> fecCierre { get; set; }
        public string gloObservacion { get; set; }

        public string codPersonaBancoNombre { get; set; }
        public string codPersonaEmpresaNombre { get; set; }
        public string codRegMonedaNombre { get; set; }
        public string codRegTipoCuentaNombre { get; set; }
    }
}
