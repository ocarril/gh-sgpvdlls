namespace CROM.BusinessEntities.Almacen.DTO
{
    public class DTOModelo: BEBasePagedResponse
    {
        public DTOModelo()
        {
            codModeloKEY = string.Empty;
            desNombre = string.Empty;
            codMarcaNombre = string.Empty;
        }

        public int codModelo { get; set; }

        public string codModeloKEY { get; set; }

        public string codMarcaNombre { get; set; }

        public string desNombre { get; set; }


    }
}
