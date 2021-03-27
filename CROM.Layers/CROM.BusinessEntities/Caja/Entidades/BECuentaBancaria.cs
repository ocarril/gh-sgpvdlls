namespace CROM.BusinessEntities.Cajas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 21/04/2014-04:51:32 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [CajaBancos.CuentaBancaria.cs]
    /// </summary>
    public class BECuentaBancaria : BEBase
    {
        public int codCuentaBancaria { get; set; }
        public string codPersonaEmpresa { get; set; }
        public string codPersonaBanco { get; set; }
        public string codRegMoneda { get; set; }
        public string codRegTipoCuenta { get; set; }
        public string desNumeroCuenta { get; set; }
        public DateTime fecApertura { get; set; }
        public Nullable<DateTime> fecCierre { get; set; }
        public string gloObservacion { get; set; }
        public bool indActivo { get; set; }
        public bool indEliminado { get; set; }

        public string auxcodPersonaEmpresa { get; set; }
        public string auxcodPersonaBanco { get; set; }
        public string auxcodRegMoneda { get; set; }
        public string auxcodRegTipoCuenta { get; set; }
    }
}
