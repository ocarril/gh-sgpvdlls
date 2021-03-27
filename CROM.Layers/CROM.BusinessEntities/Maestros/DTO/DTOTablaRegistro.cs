namespace CROM.BusinessEntities.Maestros.DTO
{
    using System;
    
    public class DTOTablaRegistro :BEBaseEntidadItem
    {

        public DTOTablaRegistro()
        {
            codValorSUNAT =string.Empty;
            desNombre = string.Empty;
            gloDescripcion = string.Empty;
            desValorCadena = string.Empty;
            desValorLogico = false;
            desValorDecimal = 0;
            desValorEntero = 0;
            codigoTMP = string.Empty;
        }

        public string codRegistro { get; set; }
        public string codTabla { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public int numNivel { get; set; }
        public int numLongitudNivel { get; set; }
        public decimal? desValorDecimal { get; set; }
        public string desValorCadena { get; set; }
        public bool? desValorLogico { get; set; }
        public int? desValorEntero { get; set; }

        public Nullable<DateTime> desValorFecha { get; set; }

        public string codValorSUNAT { get; set; }

        public string codigoTMP { get; set; }

    }
}
