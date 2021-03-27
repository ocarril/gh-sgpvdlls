namespace CROM.BusinessEntities.Caja
{
    public class BaseFiltroCuentaBancariaPage : BEBuscadorBaseRequest
    {
        public BaseFiltroCuentaBancariaPage()
        {
            codRegMoneda = string.Empty;
            codPersonaBanco = string.Empty;
            codPersona = string.Empty;
        }

        public string codPersonaBanco { get; set; }

        public string codRegMoneda { get; set; }

        public bool? indActivo { get; set; }

        public string codPersona { get; set; }
    }
}
