namespace CROM.BusinessEntities.Almacen
{
    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : Orlando Carril
    /// Fecha       : 17/11/2016-5:43:48 a. m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [ServicioTecnico.Modelo.cs]
    /// </summary>
    public class BEModelo : BEBaseEntidad
    {
        public BEModelo()
        {
            objMarca = new BEMarca();
            codModeloKEY = string.Empty;
            gloDescripcion = string.Empty;
            desNombre = string.Empty;
        }

        public int codModelo { get; set; }

        public int codMarca { get; set; }

        public string desNombre { get; set; }

        public string gloDescripcion { get; set; }

        public string codModeloKEY { get; set; }

        public BEMarca objMarca { get; set; }
    }
}
