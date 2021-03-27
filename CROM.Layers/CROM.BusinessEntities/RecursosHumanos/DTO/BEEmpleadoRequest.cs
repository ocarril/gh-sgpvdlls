namespace CROM.BusinessEntities.RecursosHumanos.DTO
{
    using System;

    public class BEEmpleadoRequest : BEBase
    {
        public BEEmpleadoRequest()
        {
            desCorreoElectronico = string.Empty;
            codPlanilla = string.Empty;
        }

        public int codEmpleado { get; set; }

        public string codPersonaEmpresa { get; set; }

        public string codPersonaNatural { get; set; }

        public string codRegAreaEmpleado { get; set; }

        public string codRegCategoria { get; set; }

        public string codRegEstadoCivil { get; set; }

        public string codRegGrupoSanguineo { get; set; }

        public Nullable<DateTime> fecNacimiento { get; set; }

        public Nullable<DateTime> fecAltaLaboral { get; set; }

        public Nullable<DateTime> fecBajaLaboral { get; set; }

        public decimal? monSueldoBasico { get; set; }

        public decimal? porComisionXVenta { get; set; }

        public bool indVendedor { get; set; }

        public string indSexo { get; set; }

        public bool indActivo { get; set; }

        public string codPlanilla { get; set; }
        public string desCorreoElectronico { get; set; }
    }


}
