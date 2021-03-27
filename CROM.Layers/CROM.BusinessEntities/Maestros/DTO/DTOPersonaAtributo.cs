namespace CROM.BusinessEntities.Maestros.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonasAtributos
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : PersonasAtributos.cs
    /// </summary>
    public class DTOPersonaAtributo : BEBaseEntidadItem
    {
        public DTOPersonaAtributo()
        {
            codPersona = string.Empty;
            codRegAtributo = string.Empty;
            codRegTipoAtributo = string.Empty;
            codRegTipoAtributoNombre = string.Empty;
            codRegTipoAtributoValor = string.Empty;
            codRegAtributoNombre = string.Empty;
        }
        public string codPersona { get; set; }

        public string codRegAtributo { get; set; }

        public string codRegTipoAtributo { get; set; }

        public string codRegTipoAtributoValor { get; set; }

        public string codRegAtributoNombre { get; set; }

        public string codRegTipoAtributoNombre { get; set; }

        public long ROWNUM { get; set; }

        public int TOTALROWS { get; set; }
    }
}
