namespace CROM.BusinessEntities.RecursosHumanos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2013-05:49:44 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [BaseFiltroRH.cs]
    /// </summary>
    public class BaseFiltroRH: BEBuscadorBase
    {
        public string codPerEmpresa { get; set; }
        public bool? indActivo { get; set; }
        
    }

    public class BaseFiltroEmpleado : BEBuscadorBase
    {
        public BaseFiltroEmpleado()
        {
            codPersonaNatural = string.Empty;
            codPlanilla = string.Empty;
        }

        public string codPersonaNatural { get; set; }
        public string codPlanilla { get; set; }
        public int? codEmpleado { get; set; }
        public bool? indActivo { get; set; }

    }

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2013-05:49:44 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [BaseFiltroRH.cs]
    /// </summary>
    public class BEBuscaEmpleadoRequest : BEBuscadorBaseRequest
    {
        public BEBuscaEmpleadoRequest()
        {
            codPlanilla = string.Empty;
            codRegEstadoCivil = string.Empty;
            codRegAreaEmpleado = string.Empty;
            codRegCategoria = string.Empty;
            desNombre = string.Empty;
            indSexo = string.Empty;
            indActivo = true;
        }

        public string codPlanilla { get; set; }
        public string codRegEstadoCivil { get; set; }
        public string codRegAreaEmpleado { get; set; }
        public string codRegCategoria { get; set; }
        public string desNombre { get; set; }
        public string indSexo { get; set; }
        public bool? indActivo { get; set; }

    }

}
