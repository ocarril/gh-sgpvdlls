namespace CROM.BusinessEntities.Comercial
{
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/05/2020-21:11:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumReg.cs]
    /// </summary>
    public class DTODocumRegForReferencia
    {

        public DTODocumRegForReferencia()
        {
            numDocumento = string.Empty;
            desMoneda = string.Empty;
            monPrecioTotal = 0;
        }


        public int codDocumReg { get; set; }

        public string numDocumento { get; set; }

        public DateTime fecEmision { get; set; }

        public string desMoneda { get; set; }

        public decimal monPrecioTotal { get; set; }
    }

} 
