namespace CROM.BusinessEntities.RecursosHumanos.DTO
{
    using System;

    public class BEEmpleadoResponse : BEBasePagedResponse
    {
        public BEEmpleadoResponse()
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

        public string indSexo { get; set; }

        public bool indVendedor { get; set; }

        public bool indActivo { get; set; }

        public string codPlanilla { get; set; }
        public string desCorreoElectronico { get; set; }


        public string desArea { get; set; }
        public string desCategoria { get; set; }
        public string desEstadoCivil { get; set; }
        public string desGrupoSanguineo { get; set; }
        public string desApellidos { get; set; }
        public string desNombres { get; set; }

    }

}
