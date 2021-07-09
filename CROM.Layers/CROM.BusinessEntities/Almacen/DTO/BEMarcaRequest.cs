namespace CROM.BusinessEntities.Almacen.DTO
{
    using CROM.BusinessEntities;

    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : Orlando Carril
    /// Fecha       : 17/11/2016-5:43:48 a. m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [ServicioTecnico.Marca.cs]
    /// </summary>
    public class BEMarcaRequest : BEBaseEntidadRequest
    {
        public BEMarcaRequest()
        {
            codPersona = string.Empty;
            nomContacto = string.Empty;
            gloDescripcion = string.Empty;
            codMarcaKEY = string.Empty;
            desNombre = string.Empty;
        }

        public int codMarca { get; set; }

        public string codPersona { get; set; }

        public string desNombre { get; set; }

        public int codPais { get; set; }

        public string nomContacto { get; set; }

        public string gloDescripcion { get; set; }

        public string codMarcaKEY { get; set; }

        public bool indActivo { get; set; }

    }
}
