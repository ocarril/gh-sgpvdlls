namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.GestionComercial.DataAccess;

    using System.Collections.Generic;

    public class ImportacionLogic
    {
        private ImportacionData oImportacionData = null;

        public ImportacionLogic()
        {
            oImportacionData = new ImportacionData();
        }
        //01 - case "ProductoSeriados":
        public List<BEProductoSeriado> ImportarProductoSeriadosBL(string p_ArchivoOrigen, int XLS_Version, string NombreRango, string p_codProducto)
        {
            return (oImportacionData.ImportarProductoSeriadosDAL(p_ArchivoOrigen, XLS_Version, NombreRango, p_codProducto));
        }
    }
}
