namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;
    
    public class ICuentasCorrientesLogic
    {

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>List</returns>
        public List<BECuentaCorriente> List(Nullable<DateTime> pFechaDeINICIO,
                                            Nullable<DateTime> pFechaDeFINAL,
                                            string pCodigoPersonaEmpre,
                                            string pCodigoPuntoVenta,
                                            string pCodigoPersonaEntidad,
                                            string pCodigoComprobante,
                                            string pNumeroComprobante,
                                            string pCodigoArguDestinoComp,
                                            bool? pEstado)
        {
            return new CuentasCorrientesLogic().List(pFechaDeINICIO,
                                                     pFechaDeFINAL,
                                                     pCodigoPersonaEmpre,
                                                     pCodigoPuntoVenta,
                                                     pCodigoPersonaEntidad,
                                                     pCodigoComprobante,
                                                     pNumeroComprobante,
                                                     pCodigoArguDestinoComp,
                                                     pEstado);
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECuentaCorriente Find(string pNumeroOperacion)
        {
            return new CuentasCorrientesLogic().Find(pNumeroOperacion);
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <param name = >itemCuentasCorrientes</param>
        public ReturnValor Insert(BECuentaCorriente pcuentaCorriente)
        {
            return new CuentasCorrientesLogic().Insert(pcuentaCorriente);
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <param name = >itemCuentasCorrientes</param>
        public ReturnValor Update(BECuentaCorriente pCuentasCorrientes)
        {
            return new CuentasCorrientesLogic().Update(pCuentasCorrientes);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int prm_codDocumReg, string prm_CodigoParte)
        {
            return new CuentasCorrientesLogic().Delete(prm_codDocumReg, prm_CodigoParte);
        }

        #endregion

    }
}
