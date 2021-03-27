namespace CROM.BusinessEntities.Comercial.response
{
    using System;


    public class DTOParteDiarioTurnoResponse : BEBasePagedResponse
    {
        public DTOParteDiarioTurnoResponse()
        {
            desNombre = string.Empty;
            codRegTipoTurnoNombre = string.Empty;
            codPuntoDeVentaNombre = string.Empty;
            codRegDiaSemanaNombre = string.Empty;
        }

        public string codParteDiarioTurno { get; set; }
        public string codPersonaEmpre { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codRegTipoTurno { get; set; }
        public string codRegDiaSemana { get; set; }
        public string desNombre { get; set; }
        public TimeSpan horInicio { get; set; }
        public TimeSpan horFinal { get; set; }
        public string codRegTipoTurnoNombre { get; set; }
        public string codRegDiaSemanaNombre { get; set; }
        public string codPuntoDeVentaNombre { get; set; }

    }
}
