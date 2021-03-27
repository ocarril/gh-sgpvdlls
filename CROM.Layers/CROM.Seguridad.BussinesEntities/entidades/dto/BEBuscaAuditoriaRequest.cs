
namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    using System;

    public class BEBuscaAuditoriaRequest : BEBuscadorBaseRequest
    {
        public BEBuscaAuditoriaRequest()
        {
            codRol = string.Empty;
            codSistema = string.Empty;
            codUsuario = string.Empty;
            fecInicioStr = string.Empty;
            fecFinalStr = string.Empty;
        }


        public string codSistema { get; set; }

        public string codRol { get; set; }

        public string codUsuario { get; set; }

        public DateTime? fecInicio { get; set; }

        public DateTime? fecFinal { get; set; }

        public string fecInicioStr { get; set; }

        public string fecFinalStr { get; set; }
    }
}
