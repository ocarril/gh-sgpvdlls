namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;



    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tablas Personas
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : Personas.cs
    /// </summary>
    public class BEPersonaFotoLogo: BEBaseMaestro
    {
        public BEPersonaFotoLogo()
        {
            FotoLogoNombre = string.Empty;
            SegUsuarioEdita = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string CodigoPersona { get; set; }
        public string FotoLogoNombre { get; set; }
        public byte[] FotoLogoBinary { get; set; }

    }
}
