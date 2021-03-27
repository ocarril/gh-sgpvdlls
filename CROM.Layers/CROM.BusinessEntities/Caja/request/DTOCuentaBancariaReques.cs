namespace CROM.BusinessEntities.Cajas.request
{
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 14/11/2020-05:08:32 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [DTOCuentaBancariaRequest.cs]
    /// </summary>
    public class DTOCuentaBancariaRequest : BEBaseEntidadRequest
    {
        public DTOCuentaBancariaRequest()
        {
            desNumeroCuenta = string.Empty;
            gloObservacion = string.Empty;
            desNumeroCCI = string.Empty;
        }

        public int codCuentaBancaria { get; set; }
        public string codPersona { get; set; }
        public string codPersonaBanco { get; set; }
        public string codRegMoneda { get; set; }
        public string codRegTipoCuenta { get; set; }
        public string desNumeroCuenta { get; set; }
        public string desNumeroCCI { get; set; }
        public DateTime fecApertura { get; set; }
        public Nullable<DateTime> fecCierre { get; set; }
        public string gloObservacion { get; set; }
        public bool indActivo { get; set; }

    }
}
