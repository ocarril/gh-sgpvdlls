namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;

    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;

    public class IParteDiarioTurnoLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEParteDiarioTurno> List(BaseFiltro pFiltro)
        {
            return new ParteDiarioTurnoLogic().List(pFiltro);
        }

        public List<BEParteDiarioTurno> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            return new ParteDiarioTurnoLogic().List(pFiltro, pTexto);
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEParteDiarioTurno> ListPaged(BaseFiltro pFiltro)
        {
            return new ParteDiarioTurnoLogic().List(pFiltro);
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="prm_CodigoTurno"></param>
        /// <returns></returns>
        public BEParteDiarioTurno Find(string prm_CodigoTurno)
        {
            return new ParteDiarioTurnoLogic().Find(prm_CodigoTurno);
        }

        public BEParteDiarioTurno Find(string pCodigoArguTipoTurno, string pCodigoArguDiaSemana)
        {
            return new ParteDiarioTurnoLogic().Find(pCodigoArguTipoTurno, pCodigoArguDiaSemana);
        }

        public BEParteDiarioTurno FindTurnoActual(string pCodigoPersonaEmpre, string pCodigoPuntoVenta)
        {
            return new ParteDiarioTurnoLogic().FindTurnoActual(pCodigoPersonaEmpre, pCodigoPuntoVenta);
        }

        #endregion

        #region /* Proceso de INSERT-UPDATE RECORD */

        public ReturnValor Save(BEParteDiarioTurno objParteDiarioTurno)
        {
            return new ParteDiarioTurnoLogic().Save(objParteDiarioTurno);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="prm_CodigoTurno"></param>
        /// <returns></returns>
        public ReturnValor Delete(string pCodigoTurno)
        {
            return new ParteDiarioTurnoLogic().Delete(pCodigoTurno);
        }

        #endregion
    }
}
