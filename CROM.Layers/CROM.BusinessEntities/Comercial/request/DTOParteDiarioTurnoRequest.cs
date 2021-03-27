namespace CROM.BusinessEntities.Comercial.request
{
    using System;


    public class DTOParteDiarioTurnoRequest : BEBaseEntidadRequest
    {
        public DTOParteDiarioTurnoRequest()
        {
            desNombre = string.Empty;
        }

        public string codParteDiarioTurno { get; set; }
        public string codPersonaEmpre { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codRegTipoTurno { get; set; }
        public string codRegDiaSemana { get; set; }
        public string desNombre { get; set; }
        public TimeSpan horInicio { get; set; }
        public TimeSpan horFinal { get; set; }
        public bool indActivo { get; set; }

    }
}
