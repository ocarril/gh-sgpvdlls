namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CROM.BusinessEntities.Almacen;
    using CROM.Tools.Comun;
    using CROM.GestionAlmacen.BusinessLogic;
    
    public class IGrupoLogic
    {

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <param name = >grupo</param>
        public ReturnValor Insert(GrupoAux pgrupo)
        {
            return new GrupoLogic().Insert(pgrupo);
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public ReturnValor Update(GrupoAux grupo)
        {
            return new GrupoLogic().Update(grupo);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int prm_codGrupo)
        {
            return new GrupoLogic().Delete(prm_codGrupo);
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<GrupoAux> List(BaseFiltroAlmacen filtro)
        {
            return new GrupoLogic().List(filtro);
        }

        public List<GrupoAux> List(BaseFiltroAlmacen filtro, Helper.ComboBoxText pTexto)
        {
            return new GrupoLogic().List(filtro, pTexto);
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Grupo
        /// En la BASE de DATO la Tabla : [Almacen.Grupo]
        /// <summary>
        /// <param name="prm_codGrupo"></param>
        /// <returns></returns>
        public GrupoAux Find(int pcodGrupo)
        {
            return new GrupoLogic().Find(pcodGrupo);
        }

        #endregion

    }
}
