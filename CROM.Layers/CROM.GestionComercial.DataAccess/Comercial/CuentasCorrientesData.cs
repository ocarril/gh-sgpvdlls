namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;
    using CROM.Tools.Comun;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.CuentasCorrientesData.cs]
    /// </summary>
    public class CuentasCorrientesData
    {
        private string conexion = string.Empty;

        public CuentasCorrientesData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <param name = >itemCuentasCorrientes</param>
        public string Insert(List<BECuentaCorriente> plstCuentasCorriente)
        {
            string codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    foreach (BECuentaCorriente cuentasCorriente in plstCuentasCorriente)
                    {

                       var resultInsert = SQLDC.usp_sgcfe_C_CuentaCorriente(
                            cuentasCorriente.codEmpresa,
                            cuentasCorriente.codDocumReg,
                            cuentasCorriente.CodigoArguMoneda,
                            cuentasCorriente.codEmpleado,
                            cuentasCorriente.CodigoParte,
                            cuentasCorriente.FechaDeEmisionDeuda,
                            cuentasCorriente.FechaDeVencimiento,
                            cuentasCorriente.NumeroDeCuota,
                            cuentasCorriente.TipoDeIngreso,
                            cuentasCorriente.DEBETotalCuotaNacion,
                            cuentasCorriente.DEBETotalCuotaExtran,
                            cuentasCorriente.DEBETipoCambioVTA,
                            cuentasCorriente.DEBETipoCambioCMP,
                            cuentasCorriente.DHDiferenciaMonto,
                            cuentasCorriente.Observaciones,
                            cuentasCorriente.Estado,
                            cuentasCorriente.SegUsuarioCrea,
                            cuentasCorriente.codCajaRegistro);

                        foreach (var result in resultInsert)
                        {
                            cuentasCorriente.NumeroOperacion = result.ErrorCode.HasValue ? result.ErrorCode.Value : 0;
                            codigoRetorno = cuentasCorriente.NumeroOperacion > 0 ? cuentasCorriente.NumeroOperacion.ToString() : null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        public string Insert(BECuentaCorriente pcuentaCorriente)
        {
            string codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resultInsert = SQLDC.usp_sgcfe_C_CuentaCorriente(
                        pcuentaCorriente.codEmpresa,
                        pcuentaCorriente.codDocumReg,
                        pcuentaCorriente.CodigoArguMoneda,
                        pcuentaCorriente.codEmpleado,
                        pcuentaCorriente.CodigoParte,
                        pcuentaCorriente.FechaDeEmisionDeuda,
                        pcuentaCorriente.FechaDeVencimiento,
                        pcuentaCorriente.NumeroDeCuota,
                        pcuentaCorriente.TipoDeIngreso,
                        pcuentaCorriente.DEBETotalCuotaNacion,
                        pcuentaCorriente.DEBETotalCuotaExtran,
                        pcuentaCorriente.DEBETipoCambioVTA,
                        pcuentaCorriente.DEBETipoCambioCMP,
                        pcuentaCorriente.DHDiferenciaMonto,
                        pcuentaCorriente.Observaciones,
                        pcuentaCorriente.Estado,
                        pcuentaCorriente.SegUsuarioCrea,
                        pcuentaCorriente.codCajaRegistro);

                    foreach (var result in resultInsert)
                    {
                        pcuentaCorriente.NumeroOperacion = result.ErrorCode.HasValue ? result.ErrorCode.Value : 0;
                        codigoRetorno = pcuentaCorriente.NumeroOperacion > 0 ? pcuentaCorriente.NumeroOperacion.ToString() : null;
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

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <param name = >itemCuentasCorrientes</param>
        //public bool Update(BECuentaCorriente cuentasCorriente)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            var resultUpdate = SQLDC.usp_sgcfe_U_CuentaCorriente(
        //                cuentasCorriente.NumeroOperacion,
        //                cuentasCorriente.Estado,
        //                cuentasCorriente.SegUsuarioEdita
        //                );

        //            foreach(var result in resultUpdate)
        //            {
        //                codigoRetorno = result.ErrorCode.HasValue ? result.ErrorCode.Value : 0;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>bool</returns>
        public bool DeleteCodDocumReg(int pcodEmpresa, int prm_codDocumReg, string prm_CodigoParte, string prmUserDelete)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resultDelete = SQLDC.usp_sgcfe_D_CuentaCorriente_codDocumReg(pcodEmpresa, 
                                                                                     prm_codDocumReg, 
                                                                                     prm_CodigoParte, 
                                                                                     prmUserDelete);

                    foreach (var item in resultDelete)
                    {
                        if (item.ErrorCode.HasValue)
                            if (item.ErrorCode.Value >= 0)
                                codigoRetorno = item.ErrorCode.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>List</returns>
        public List<BECuentaCorriente> List(int prm_codEmpresa,string prm_FechaDeInicio, string prm_FechaDeFinal,  
                                            string prm_CodigoPuntoVenta, string prm_CodigoPersonaEntidad, 
                                            string prm_CodigoComprobante, string prm_NumeroComprobante, 
                                            string prm_CodigoArguDestinoComp, bool? prm_Estado)
        {
            List<BECuentaCorriente> listaCuentaCorriente = new List<BECuentaCorriente>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_CuentaCorriente(prm_codEmpresa, prm_FechaDeInicio, prm_FechaDeFinal,  
                                                             prm_CodigoPuntoVenta, prm_CodigoPersonaEntidad, 
                                                             prm_CodigoComprobante, prm_NumeroComprobante, 
                                                             prm_CodigoArguDestinoComp, prm_Estado);
                    foreach (var item in resul)
                    {
                        listaCuentaCorriente.Add(new BECuentaCorriente()
                        {
                            codDocumReg = item.codDocumReg,
                            NumeroOperacion = item.NumeroOperacion,
                            codEmpresa = item.codEmpresa,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoComprobante = item.CodigoComprobante,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoArguTipoMovimi = item.CodigoArguTipoMovimi,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            CodigoParte = item.CodigoParte,
                            FechaDeEmisionDeuda = item.FechaDeEmisionDeuda,
                            FechaDeVencimiento = item.FechaDeVencimiento,

                            NumeroDeCuota = item.NumeroDeCuota,
                            TipoDeIngreso = item.TipoDeIngreso.ToString(),

                            DEBETotalCuotaNacion = item.TipoDeIngreso == 'D' ? item.DHTotalCuotaNacion : 0,
                            DEBETotalCuotaExtran = item.TipoDeIngreso == 'D' ? item.DHTotalCuotaExtran : 0,
                            DEBETipoCambioVTA = item.TipoDeIngreso == 'D' ? item.DHTipoCambioVTA : 0,
                            DEBETipoCambioCMP = item.TipoDeIngreso == 'D' ? item.DHTipoCambioCMP : 0,
                            HABERTotalPagoNacion = item.TipoDeIngreso == 'H' ? item.DHTotalCuotaNacion : 0,
                            HABERTotalPagoExtran = item.TipoDeIngreso == 'H' ? item.DHTotalCuotaExtran : 0,
                            HABERTipoCambioVTA = item.TipoDeIngreso == 'H' ? item.DHTipoCambioVTA : 0,
                            HABERTipoCambioCMP = item.TipoDeIngreso == 'H' ? item.DHTipoCambioCMP : 0,
                            DHDiferenciaMonto = item.TipoDeIngreso == 'H' ? item.DHDiferenciaMonto : 0,

                            Observaciones = item.Observaciones,
                           
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoArguTipoMovimiNombre = item.CodigoArguTipoMovimiNombre,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            auxcodEmpleadoNombre = item.auxcodEmpleadoNombre,
                            CodigoPersonaEmpreNombre = item.codEmpresaNombre,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            codEmpleado = item.codEmpleado
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaCuentaCorriente;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>List</returns>
        public List<BECuentaCorriente> ListConCuadre(int prm_codEmpresa, string prm_CodigoPersonaEntidad, 
                                                     string prm_FechaDeInicio, 
                                                     string prm_FechaDeFinal, 
                                                     string prm_CodigoPuntoVenta, 
                                                     string prm_CodigoComprobante, 
                                                     string prm_NumeroComprobante, string prm_CodigoArguDestinoComp, 
                                                     bool? prm_Estado)
        {
            List<BECuentaCorriente> listaCuentaCorriente = new List<BECuentaCorriente>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_CuentaCorrienteCuadre(prm_codEmpresa, prm_FechaDeInicio, prm_FechaDeFinal,  
                                                                   prm_CodigoPuntoVenta, prm_CodigoPersonaEntidad, 
                                                                   prm_CodigoComprobante, prm_NumeroComprobante, 
                                                                   prm_CodigoArguDestinoComp, prm_Estado);
                    foreach (var item in resul)
                    {
                        listaCuentaCorriente.Add(new BECuentaCorriente()
                        {
                            codDocumReg = item.codDocumReg,
                            NumeroOperacion = item.NumeroOperacion.HasValue? item.NumeroOperacion.Value:0,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoComprobante = item.CodigoComprobante,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoParte = item.CodigoParte,
                            FechaDeEmisionDeuda = item.FechaDeEmisionDeuda,
                            FechaDeVencimiento = item.FechaDeVencimiento,

                            NumeroDeCuota = item.NumeroDeCuota,
                            TipoDeIngreso = item.TipoDeIngreso.ToString(),

                            DEBETotalCuotaNacion = item.TipoDeIngreso == "D" ? item.DHTotalCuotaNacion : 0,
                            DEBETotalCuotaExtran = item.TipoDeIngreso == "D" ? item.DHTotalCuotaExtran.Value : 0,
                            DEBETipoCambioVTA = item.TipoDeIngreso == "D" ? item.DHTipoCambioVTA : 0,
                            DEBETipoCambioCMP = item.TipoDeIngreso == "D" ? item.DHTipoCambioCMP : 0,

                            HABERTotalPagoNacion = item.TipoDeIngreso != "D" ? item.DHTotalCuotaNacion : 0,
                            HABERTotalPagoExtran = item.TipoDeIngreso != "D" ? item.DHTotalCuotaExtran.Value : 0,
                            HABERTipoCambioVTA = item.TipoDeIngreso != "D" ? item.DHTipoCambioVTA : 0,
                            HABERTipoCambioCMP = item.TipoDeIngreso != "D" ? item.DHTipoCambioCMP : 0,

                            DHDiferenciaMonto = item.TipoDeIngreso != "D" ? item.DHDiferenciaMonto : 0,

                            Observaciones = item.Observaciones,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            auxcodEmpleadoNombre = item.auxcodEmpleadoNombre,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            codEmpleado = item.codEmpleado,
                            ESTADO = item.ESTADO,
                            OrigenDato = item.OrigenDato
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaCuentaCorriente;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECuentaCorriente Find(int pcodEmpresa, string prm_NumeroOperacion)
        {
            BECuentaCorriente cuentaCorriente = new BECuentaCorriente();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_CuentaCorriente_Id(pcodEmpresa, prm_NumeroOperacion);
                    foreach (var item in resul)
                    {
                        cuentaCorriente = new BECuentaCorriente()
                        {
                            codDocumReg = item.codDocumReg,
                            NumeroOperacion = item.NumeroOperacion,
                            codEmpresa = item.codEmpresa,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoComprobante = item.CodigoComprobante,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoArguTipoMovimi = item.CodigoArguTipoMovimi,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            codEmpleado = item.codEmpleado,
                            auxcodEmpleadoNombre = item.codEmpleadoNombre,
                            CodigoParte = item.CodigoParte,
                            TipoDeIngreso = Convert.ToString(item.TipoDeIngreso),
                            FechaDeEmisionDeuda = item.FechaDeEmisionDeuda,
                            FechaDeVencimiento = item.FechaDeVencimiento,

                            NumeroDeCuota = item.NumeroDeCuota,
                            DEBETotalCuotaNacion = item.TipoDeIngreso == 'D' ? item.DHTotalCuotaNacion : 0,
                            DEBETotalCuotaExtran = item.TipoDeIngreso == 'D' ? item.DHTotalCuotaExtran : 0,
                            DEBETipoCambioVTA = item.TipoDeIngreso == 'D' ? item.DHTipoCambioVTA : 0,
                            DEBETipoCambioCMP = item.TipoDeIngreso == 'D' ? item.DHTipoCambioCMP : 0,
                            HABERTotalPagoNacion = item.TipoDeIngreso == 'H' ? item.DHTotalCuotaNacion : 0,
                            HABERTotalPagoExtran = item.TipoDeIngreso == 'H' ? item.DHTotalCuotaExtran : 0,
                            HABERTipoCambioVTA = item.TipoDeIngreso == 'H' ? item.DHTipoCambioVTA : 0,
                            HABERTipoCambioCMP = item.TipoDeIngreso == 'H' ? item.DHTipoCambioCMP : 0,
                            DHDiferenciaMonto = item.DHDiferenciaMonto == 'H' ? item.DHDiferenciaMonto : 0,

                            Observaciones = item.Observaciones,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoArguTipoMovimiNombre = item.CodigoArguTipoMovimiNombre,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            CodigoPersonaEmpreNombre = item.codEmpresaNombre,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cuentaCorriente;
        }

        #endregion

    }
} 
