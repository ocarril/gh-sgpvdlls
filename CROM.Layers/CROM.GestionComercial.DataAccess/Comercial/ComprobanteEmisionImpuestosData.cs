namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/09/2010-6:51:19
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ComprobanteEmisionImpuestosData.cs]
    /// </summary>
    public class ComprobanteEmisionImpuestosData
    {
        private string conexion = string.Empty;
        public ComprobanteEmisionImpuestosData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de INSERT RECORD */

        public int? Insert(List<BEComprobanteEmisionImpuesto> lstComprobanteEmisionImpuestos)
        {
            int? codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    foreach (BEComprobanteEmisionImpuesto comprobanteEmisionImpuesto in lstComprobanteEmisionImpuestos)
                    {
                        SQLDC.omgc_I_DocumRegImpuesto(
                           ref codigoRetorno,
                           comprobanteEmisionImpuesto.codDocumReg,
                           comprobanteEmisionImpuesto.CodigoImpuesto,
                           comprobanteEmisionImpuesto.ValorDeImpuesto,
                           comprobanteEmisionImpuesto.ValorTotalImpuesto,
                           comprobanteEmisionImpuesto.SegUsuarioCrea,
                           comprobanteEmisionImpuesto.SegMaquina);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobanteEmisionImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmisionImpuestos]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(int prm_codDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_DocumRegImpuesto(prm_codDocumReg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobanteEmisionImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmisionImpuestos]
        /// <summary>
        /// <returns>List</returns>
        public List<BEComprobanteEmisionImpuesto> List(int codEmpresa, int prm_codDocumReg)
        {
            List<BEComprobanteEmisionImpuesto> miLista = new List<BEComprobanteEmisionImpuesto>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoMovImpuesto(codEmpresa, prm_codDocumReg);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BEComprobanteEmisionImpuesto()
                        {
                            codDocumReg = item.codDocumReg,
                            codDocumRegImpuesto = item.codDocumRegImpuesto,
                            codEmpresa = item.codEmpresa,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoComprobante = item.CodigoComprobante,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoImpuesto = item.CodigoImpuesto,
                            ValorDeImpuesto = item.ValorDeImpuesto,
                            ValorDeImpuesto100 = item.ValorDeImpuesto * 100,
                            ValorTotalImpuesto = item.ValorTotalImpuesto,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            CodigoImpuestoNombre = item.codigoImpuestoNombre,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

    }
} 
