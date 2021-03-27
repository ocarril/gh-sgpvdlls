namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Almacen;
    using CROM.GestionComercial.BusinessLogic;

    public class IImportacionLogic
    {
        public List<BEProductoSeriado> ImportarProductoSeriadosBL(string pArchivoOrigen, int pXLS_Version, string pNombreRango, string pcodProducto)
        {
            return new ImportacionLogic().ImportarProductoSeriadosBL(pArchivoOrigen, pXLS_Version, pNombreRango, pcodProducto);
        }
    }
}
