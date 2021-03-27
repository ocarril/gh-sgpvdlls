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
    /// Archivo     : Feriados.cs
    /// </summary>
    public class BEFeriado : BEBaseMaestro
    {
        public BEFeriado()
        {
            Descripcion = string.Empty;
            Feriado = string.Empty;
        }

        #region Entidadest

        public string CodigoRegistro { get; set; }
        public string Feriado { get; set; }

        public bool Fijo { get; set; }
        public string Descripcion { get; set; }

        public Nullable<DateTime> FechaIndicada { get; set; }


        #endregion

    }
}
