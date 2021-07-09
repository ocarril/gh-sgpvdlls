using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.Almacen.DTO
{
 
    public class DTOMarcaResponse : BEBaseEntidadItem
    {
        public DTOMarcaResponse()
        {
            codPersona = string.Empty;
            nomContacto = string.Empty;
            gloDescripcion = string.Empty;
            codMarcaKEY = string.Empty;
            desNombre = string.Empty;
        }

        public int codMarca { get; set; }

        public string codMarcaKEY { get; set; }

        public string codPersona { get; set; }

        public string desNombre { get; set; }

        public int codPais { get; set; }

        public string nomContacto { get; set; }

        public string gloDescripcion { get; set; }

        public string codPersonaNombre { get; set; }

    }

}
