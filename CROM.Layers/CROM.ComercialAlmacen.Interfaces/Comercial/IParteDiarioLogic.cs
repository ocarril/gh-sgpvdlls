namespace CROM.ComercialAlmacen.Interfaces
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class IParteDiarioLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>List</returns>
        public List<BEParteDiario> List(Nullable<DateTime> pFechaParteInicio, Nullable<DateTime> pFechaParteFinal, string pCodigoPersonaEmpre, string pCodigoPuntoVenta, int? pcodEmpleado, string pCodigoTurno, bool pEstado)
        {
            List<BEParteDiario> listaParteDiario = new ParteDiarioLogic().List(pFechaParteInicio, 
                                                                             pFechaParteFinal, 
                                                                             pCodigoPersonaEmpre, 
                                                                             pCodigoPuntoVenta, 
                                                                             pcodEmpleado, 
                                                                             pCodigoTurno, 
                                                                             pEstado);
            return listaParteDiario;
        }

        public List<BEParteDiario> List(Nullable<DateTime> pFechaParteInicio, Nullable<DateTime> pFechaParteFinal, string pCodigoPersonaEmpre,  string pCodigoPuntoVenta, int? pcodEmpleado, string pCodigoTurno, bool pEstado, Helper.ComboBoxText pTexto)
        {
            List<BEParteDiario> listaParteDiario = new ParteDiarioLogic().List(pFechaParteInicio, 
                                                                             pFechaParteFinal, 
                                                                             pCodigoPersonaEmpre, 
                                                                             pCodigoPuntoVenta, 
                                                                             pcodEmpleado, 
                                                                             pCodigoTurno, 
                                                                             pEstado,
                                                                             Helper.ComboBoxText.Todos);
            return listaParteDiario;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEParteDiario Find(string prm_CodigoPersonaEmpre, string pCodigoPuntoVenta, string pCodigoParte)
        {
            BEParteDiario objParteDiario = new ParteDiarioLogic().Find(prm_CodigoPersonaEmpre, pCodigoPuntoVenta, pCodigoParte);
            return objParteDiario;
        }

        public List<BEParteDiario> ListCajas(string pCodigoPersonaEmpre, string pCodigoPuntoVenta, string pCodigoParte, Nullable<DateTime> pFechaParte, string pCodigoTurno, int? pcodEmpleado, bool? pCajaActiva)
        {
            List<BEParteDiario> lstParteDiario = new ParteDiarioLogic().ListCajas(pCodigoPersonaEmpre, 
                                                                                pCodigoPuntoVenta, 
                                                                                pCodigoParte, 
                                                                                pFechaParte, 
                                                                                pCodigoTurno, 
                                                                                pcodEmpleado, 
                                                                                pCajaActiva);
            return lstParteDiario;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor Insert(BEParteDiario parteDiario)
        {
            ReturnValor objReturnValor = new ParteDiarioLogic().Insert(parteDiario);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor Update(BEParteDiario pParteDiario)
        {
            ReturnValor objReturnValor = new ParteDiarioLogic().Update(pParteDiario);
            return objReturnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor UpdateCajaActiva(BEParteDiario pParteDiario)
        {
            ReturnValor objReturnValor = new ParteDiarioLogic().UpdateCajaActiva(pParteDiario);
            return objReturnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor UpdateCajaCierre(BEParteDiario pParteDiario)
        {
            ReturnValor objReturnValor = new ParteDiarioLogic().UpdateCajaCierre(pParteDiario);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string pCodigoPersonaEmpre, string pCodigoPuntoVenta, string pCodigoParte)
        {
            ReturnValor objReturnValor = new ParteDiarioLogic().Delete(pCodigoPersonaEmpre, 
                                                                       pCodigoPuntoVenta, 
                                                                       pCodigoParte);
            return objReturnValor;
        }

        #endregion

    }
}
