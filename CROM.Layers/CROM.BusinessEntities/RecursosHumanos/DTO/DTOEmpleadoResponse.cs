namespace CROM.BusinessEntities.RecursosHumanos.DTO
{
    using System;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonaEmpleado
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/06/2020
    /// Descripcion : Entidad de negocio
    /// Archivo     : Empleado.cs
    /// </summary>
    public class DTOEmpleadoResponse : BEBaseEntidadItem
    {
        public DTOEmpleadoResponse()
        {
            codPersonaNatural = string.Empty;
            desApellidos = string.Empty;
            desNombres = string.Empty;
            monSueldoBasico = 0;
            codPlanilla = string.Empty;
            desNombres = string.Empty;
            desArea = string.Empty;
            desCategoria = string.Empty;
            desCorreoElectronico = string.Empty;
            desEmpleado = string.Empty;
            desEstadoCivil = string.Empty;
            desGrupoSanguineo = string.Empty;
            Nombre1 = string.Empty;
            Nombre2 = string.Empty;
            ApellidoMaterno = string.Empty;
            ApellidoPaterno = string.Empty;
        }

        public int codEmpleado { get; set; }

        public string codPersonaEmpresa { get; set; }

        public string codPersonaNatural { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Nombre1 { get; set; }

        public string Nombre2 { get; set; }

        public string desApellidos { get; set; }

        public string desNombres { get; set; }

        public string ApellidosNombres { get; set; } 

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

        public string codPlanilla { get; set; }

        public string desCorreoElectronico { get; set; }

        public string desArea { get; set; }

        public string desCategoria { get; set; }

        public string desEstadoCivil { get; set; }

        public string desGrupoSanguineo { get; set; }

        public string desEmpleado { get; set; }
    }

}