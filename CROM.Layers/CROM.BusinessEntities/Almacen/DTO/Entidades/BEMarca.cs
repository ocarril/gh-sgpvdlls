namespace CROM.BusinessEntities.Almacen
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
    public class BEMarca : BEBaseEntidad
    {
        public BEMarca()
        {
            codPersona = string.Empty;
            codRegPais = string.Empty;
            lstModelo = new List<BEModelo>();
            nomContacto = string.Empty;
            gloDescripcion = string.Empty;
            codMarcaKEY = string.Empty;
            desNombre = string.Empty;
        }

        public int codMarca { get; set; }

        public string codPersona { get; set; }

        public string desNombre { get; set; }

        public string codRegPais { get; set; }

        public string nomContacto { get; set; }

        public string gloDescripcion { get; set; }

        public string codMarcaKEY { get; set; }

        public List<BEModelo> lstModelo { get; set; }


        public string codPersonaNombre { get; set; }

    }
}
