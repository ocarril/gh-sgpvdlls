using System.Collections.Generic;

namespace CROM.BusinessEntities.SUNAT.WSGuiaRemision
{


    public class BEGuiaDeRemisionJSON
    {
        public BESFSGuiaDeRemisionCabeceraJSON cabecera { get; set; }

        public List<BESFSGuiaDeRemisionDetalle> detalle { get; set; }

        public List<BESFSGuiaDeRemisionRelacionados> relacionados { get; set; }
    }

    public class BESFSGuiaDeRemisionCabeceraJSON
    {

        public string fecEmision { get; set; }
        public string horEmision { get; set; }
        public string tipDocGuia { get; set; }
        public string serNumDocGuia { get; set; }
        public string numDocDestinatario { get; set; }
        public string tipDocDestinatario { get; set; }
        public string rznSocialDestinatario { get; set; }
        public string motTrasladoDatosEnvio { get; set; }
        public string desMotivoTrasladoDatosEnvio { get; set; }
        public string indTransbordoProgDatosEnvio { get; set; }
        public string psoBrutoTotalBienesDatosEnvio { get; set; }
        public string uniMedidaPesoBrutoDatosEnvio { get; set; }
        public string numBultosDatosEnvio { get; set; }
        public string modTrasladoDatosEnvio { get; set; }
        public string fecInicioTrasladoDatosEnvio { get; set; }
        public string numDocTransportista { get; set; }
        public string tipDocTransportista { get; set; }
        public string nomTransportista { get; set; }
        public string numPlacaTransPrivado { get; set; }
        public string numDocIdeConductorTransPrivado { get; set; }
        public string tipDocIdeConductorTransPrivado { get; set; }
        public string nomConductorTransPrivado { get; set; }
        public string ubiLlegada { get; set; }
        public string dirLlegada { get; set; }
        public string ubiPartida { get; set; }
        public string dirPartida { get; set; }
        public string ublVersionId { get; set; }
        public string customizationId { get; set; }


    }



    public class BESFSGuiaDeRemisionDetalle
    {

        public string uniMedidaItem { get; set; }
        public string canItem { get; set; }
        public string desItem { get; set; }
        public string codItem { get; set; }
        public string pesoItem { get; set; }
        public string bultoItem { get; set; }

    }


    public class BESFSGuiaDeRemisionRelacionados
    {
        public string numDocRel { get; set; }
        public string codTipDocRel { get; set; }

    }

}
