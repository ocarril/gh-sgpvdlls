namespace CROM.BusinessEntities.Maestros
{
    using System;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 29/11/2019-11:45:02
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Maestros.Ubigeo.cs]
    /// </summary>
    public class BEUbigeo : BEBaseEntidad
    {
        public BEUbigeo()
        {
            codUbigeoDist = string.Empty;
            codUbigeoProv = string.Empty;
            nomDistrito = string.Empty;
            nomDepartamento = string.Empty;
            nomProvincia = string.Empty;
            codUbigeoDpto = string.Empty;
            numX = 0;
            numY = 0;
            nomRegion = string.Empty;
        }

        public int codUbigeo { get; set; }
        public string codUbigeoDist { get; set; }
        public string nomDistrito { get; set; }
        public string codUbigeoProv { get; set; }
        public string nomProvincia { get; set; }
        public string codUbigeoDpto { get; set; }
        public string nomDepartamento { get; set; }
        public float numX { get; set; }
        public float numY { get; set; }
        public string nomRegion { get; set; }

    }
}
