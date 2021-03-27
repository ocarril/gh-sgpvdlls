namespace CROM.BusinessEntities.Importaciones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 11/09/2014-06:09:07 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Importaciones.PlantillaCosto.cs]
    /// </summary>
    public class BEPlantillaCosto : BEBase
    {
        public int codPlantillaCosto { get; set; }
        public string codRegNacionalizac { get; set; }
        public string codRegIncoterm { get; set; }
        public string codRegResumenCosto { get; set; }
        public int? numOrden { get; set; }
        public bool indActivo { get; set; }

        public string auxcodRegIncotermo { get; set; }
        public string auxcodRegResumenCosto { get; set; }
        public string auxcodRegNacionalizac { get; set; }

    }
} 
