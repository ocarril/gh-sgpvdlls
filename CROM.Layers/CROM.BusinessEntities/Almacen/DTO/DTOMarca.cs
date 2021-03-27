namespace CROM.BusinessEntities.Almacen.DTO
{
    public class DTOMarca : BEBasePagedResponse
    {
        public DTOMarca()
        {
            codMarcaKEY = string.Empty;
            nomContacto = string.Empty;
            desNombre = string.Empty;
            codRegPaisNombre = string.Empty;
        }

        public int codMarca { get; set; }

        public string codMarcaKEY { get; set; }

        public string codPersonaNombre { get; set; }

        public string desNombre { get; set; }

        public string codRegPaisNombre { get; set; }

        public string nomContacto { get; set; }
    }
}
