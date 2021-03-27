namespace CROM.BusinessEntities.Comercial.request
{
    using System;


    public class DTOCuentaCorrienteRequest : BEBaseEntidadRequest
    {
        public DTOCuentaCorrienteRequest()
        {
            gloObservacion = string.Empty;
        }

        public int codCuentaCorriente { get; set; }
        public int codDocumReg { get; set; }
        public string codRegMoneda { get; set; }
        public int codEmpleado { get; set; }
        public string codParteDiario { get; set; }

        public int? codCajaRegistro { get; set; }

        public Nullable<DateTime> fecEmisionDeuda { get; set; }
        public Nullable<DateTime> fecVencimiento { get; set; }
        public int numCuota { get; set; }
        public string indTipoIngreso { get; set; } //[D]Debe [H]Haber 

        public decimal monDHTotalCuotaNacion { get; set; }
        public decimal monDHTotalCuotaExtran { get; set; }
        public decimal monDHTipoCambioVTA { get; set; }
        public decimal monDHTipoCambioCMP { get; set; }

        public decimal monDHDiferenciaMonto { get; set; }

        public string gloObservacion { get; set; }

        public bool indActivo { get; set; }
    }
}
