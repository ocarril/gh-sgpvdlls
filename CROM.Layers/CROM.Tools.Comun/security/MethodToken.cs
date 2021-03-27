namespace CROM.Tools.Comun.security.Extensiones
{
    using CROM.Tools.Comun.Web;

    using System.Net.Http;

    public static class MethodToken
    {
        
        public static string GetAccessToken(HttpRequestMessage request, bool indConPrefijo)
        {
            string accessToken = string.Empty;
            if (!request.Headers.Contains("Authorization")) return accessToken;
            var TOKEN = request.Headers.GetValues("Authorization");
            //var TOKEN = request.Headers.GetValues("Authorization");
            //if (request.Headers.Count != 0)
            if (TOKEN != null)
            {
                //if (!string.IsNullOrWhiteSpace(request.Headers.Authorization.Scheme) &&
                //    request.Headers.Authorization.Scheme.ToLower() == WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower() &&
                //    !string.IsNullOrWhiteSpace(request.Headers.Authorization.Parameter))
                //{
                foreach (string strToken in TOKEN)
                {
                    accessToken = (indConPrefijo ? WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower() + " " : "") +
                                  strToken;
                    //  request.Headers.Authorization.Parameter;
                    //}
                }
            }
            return accessToken;
        }
    }
}
