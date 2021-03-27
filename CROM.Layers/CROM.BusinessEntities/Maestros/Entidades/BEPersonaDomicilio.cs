using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.Maestros.Entidades
{

    /// <summary>
	/// Proyecto    : Modulo de Mantenimiento de : 
	/// Creacion    : LOG(OCR)
	/// Fecha       : 29/11/2019-11:45:02
	/// Descripcion : Capa de Entidades 
	/// Archivo     : [Maestros.PersonasDomicilio.cs]
	/// </summary>
	public class BEPersonasDomicilio: BEBaseEntidad
    {
        public BEPersonasDomicilio()
        {
            codPersona = string.Empty;
            gloDireccion = string.Empty;
            desNucleoUrb = string.Empty;
            desNumero = string.Empty;
            gloDireccion = string.Empty;
            gloDireccionConcat = string.Empty;
            gloDireccionGeoCod = string.Empty;
            gloDireccionSunat = string.Empty;
            gloReferencia = string.Empty;
            numLatitud = 0;
            numLongitud = 0;
        }

        public int codPersonaDomicilio { get; set; }
        public string codPersona { get; set; }
        public int codRegTipo { get; set; }
        public int codRegVia { get; set; }
        public string gloDireccion { get; set; }
        public string desNumero { get; set; }
        public int? codRegNucleoUrb { get; set; }
        public string desNucleoUrb { get; set; }
        public int codUbigeo { get; set; }
        public string gloReferencia { get; set; }
        public string gloDireccionConcat { get; set; }
        public string gloDireccionGeoCod { get; set; }
        public string gloDireccionSunat { get; set; }
        public decimal? numLatitud { get; set; }
        public decimal? numLongitud { get; set; }


        /*
         Propiedades adicionales
         */
        public string codRegNucleoUrbNombre { get; set; }

        public string codRegTipoNombre { get; set; }

        public string codRegViaNombre { get; set; }

        public string codUbigeoCode { get; set; }

        public string codUbigeoNombre { get; set; }

        public string codUbigeoProv { get; set; }

        public string codUbigeoDpto { get; set; }
    }

}
