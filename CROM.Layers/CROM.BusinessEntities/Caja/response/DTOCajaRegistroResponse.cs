namespace CROM.BusinessEntities.Caja.response
{
    using CROM.BusinessEntities.Comercial;

    using System;
    using System.Collections.Generic;


    public class DTOCajaRegistroResponse : BEBasePagedResponse
    {
        public DTOCajaRegistroResponse()
        {
            listaCuentaCorriente = new List<BECuentaCorriente>();
        }

        public int codCajaRegistro { get; set; }

        public int codDocumReg { get; set; }

        public bool indIncidenciaEnCaja { get; set; }

        public int numItem { get; set; }

        public int codEmpresa { get; set; }

        public string codPuntoDeVenta { get; set; }

        public string codPuntoDeVentaNombre { get; set; }

        public string codDocumento { get; set; }

        public string codDocumentoNombre { get; set; }

        public string numDocumento { get; set; }

        public int? codEmpleado { get; set; }

        public string codEmpleadoNombre { get; set; }

        public int codFormaDePago { get; set; }

        public string codFormaDePagoNombre { get; set; }

        public string codRegMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }



        public decimal monImporteRecibido { get; set; }

        public decimal monImportePagado { get; set; }

        public decimal monImportePagadoEx { get; set; }

        public decimal monImporteVuelto { get; set; }

        public decimal monTCambioVTA { get; set; }

        public decimal monTCambioCMP { get; set; }


        public string gloObservacion { get; set; }

        public bool indConciliado { get; set; }

        public string codParteDiario { get; set; }

        public string codEmpresaRUC { get; set; }

        public DateTime fecIngreso { get; set; }

        public int numDiasPagado { get; set; }

        //public decimal MontoPagado_MonNac { get; set; }
        //public decimal MontoPagado_MonInt { get; set; }

        public List<BECuentaCorriente> listaCuentaCorriente { get; set; }

    }
}
