namespace CROM.Tools.Comun.Web
{
    using CROM.Tools.Comun.entities;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.UI.WebControls;

    public static class HelperWeb
    {

        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            string HttpContext = "MS_HttpContext";
            string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    string numIP = ctx.Request.UserHostAddress == ctx.Request.UserHostName ?
                                   ctx.Request.UserHostAddress :
                                   string.Concat(ctx.Request.UserHostAddress, "-", ctx.Request.UserHostName);
                    return numIP;
                }
            }

            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            return null;
        }

        public static string GetClientIpAddressHttpContext(this System.Web.HttpRequestBase context)
        {
            //System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.ServerVariables["REMOTE_ADDR"];
        }

        public static string ProcessRequest(string url, string method, string postData, string contentType,
                                            ref bool hasErrors)
        {
            hasErrors = false;
            byte[] byteData = (!string.IsNullOrWhiteSpace(postData) ? Encoding.UTF8.GetBytes(postData) : null);

            return ProcessRequest(url, method, byteData, contentType, null, null, null,-1, ref hasErrors);
        }

        public static string ProcessRequest(string url, string method, byte[] byteData, string contentType,
                                            ref bool hasErrors)
        {
            hasErrors = false;

            return ProcessRequest(url, method, byteData, contentType, null, null, null,-1, ref hasErrors);
        }

        public static string ProcessRequest(string url, string method, string postData, string contentType,
                                            Dictionary<string, string> requestHeaders, 
                                            string credentialUserName, 
                                            string credentialPassword, 
                                            int requestTimeout,
                                            ref bool hasErrors)
        {
            hasErrors = false;
            byte[] byteData = (!string.IsNullOrWhiteSpace(postData) ? Encoding.UTF8.GetBytes(postData) : null);

            return ProcessRequest(url, method, byteData, contentType, requestHeaders, credentialUserName,
                                  credentialPassword, requestTimeout,
                                  ref hasErrors);
        }

        public static string ProcessRequest(string url, string method, byte[] byteData, string contentType,
                                            Dictionary<string, string> requestHeaders, 
                                            string credentialUserName, 
                                            string credentialPassword,
                                             int requestTimeout,
                                            ref bool hasErrors)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            hasErrors = false;
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            if (requestTimeout >= 0)
            {
                myHttpWebRequest.Timeout = requestTimeout;
                myHttpWebRequest.ContinueTimeout = requestTimeout;
                myHttpWebRequest.ReadWriteTimeout = requestTimeout;
            }
            else
                myHttpWebRequest.Timeout = System.Threading.Timeout.Infinite;

            myHttpWebRequest.Method = method;

            if (!string.IsNullOrWhiteSpace(credentialUserName) && !string.IsNullOrWhiteSpace(credentialPassword))
            {
                myHttpWebRequest.Credentials = new NetworkCredential(credentialUserName, credentialPassword);
            }
            if (!string.IsNullOrWhiteSpace(contentType))
            {
                myHttpWebRequest.ContentType = contentType;
            }
            if (requestHeaders != null)
            {
                foreach (KeyValuePair<string, string> requestHeader in requestHeaders)
                {
                    myHttpWebRequest.Headers.Add(requestHeader.Key, requestHeader.Value);
                }
            }

            if ((method.ToLower() == WebConstants.METHOD_POST.ToLower() ||
                method.ToLower() == WebConstants.METHOD_PUT.ToLower()) &&
                byteData != null)
            {

                myHttpWebRequest.ContentLength = byteData.Length;

                using (Stream requestStream = myHttpWebRequest.GetRequestStream())
                {
                    requestStream.Write(byteData, 0, byteData.Length);
                }
            }

            try
            {
                if (requestHeaders != null)
                {
                    foreach (KeyValuePair<string, string> requestHeader in requestHeaders)
                    {
                        string[] valorExist = myHttpWebRequest.Headers.GetValues(requestHeader.Key);
                        if (valorExist != null)
                            if (valorExist.Length > 0)
                                continue;

                        myHttpWebRequest.Headers.Add(requestHeader.Key, requestHeader.Value);
                    }
                }

                using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
                {
                    using (Stream responseStream = myHttpWebResponse.GetResponseStream())
                    {
                        if (responseStream == null)
                        {
                            return null;
                        }
                        using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            return myStreamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {

                HttpWebResponse resp = ex.Response as HttpWebResponse;
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                string respStr = reader.ReadToEnd();
                reader.Close();
                if (string.IsNullOrEmpty(respStr))
                    respStr = ex.Message;

                HelpLogging.Write(TraceLevel.Error,string.Concat( "HelpWebUtils.", MethodBase.GetCurrentMethod().Name), ex);
                hasErrors = true;
                return respStr;
            }
            catch (OutOfMemoryException ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("HelpWebUtils.", MethodBase.GetCurrentMethod().Name), ex);
                hasErrors = true;
                return null;
            }
            catch (IOException ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("HelpWebUtils.", MethodBase.GetCurrentMethod().Name), ex);
                hasErrors = true;
                return null;
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("HelpWebUtils.", MethodBase.GetCurrentMethod().Name), ex);
                throw;
            }
        }

        public static async Task<OperationResult>  ProcessHttpClientRequest(object pContent, string pMetodo, string pMediaType, Uri pURLWS)
        {
            OperationResult rptaResponse = new OperationResult();
            try
            {
                using (var client = new HttpClient())
                {

                    HttpContent content = new StringContent(JsonConvert.SerializeObject(pContent), 
                                                            Encoding.UTF8,
                                                            pMediaType);
                    var metodo = HttpMethod.Get;
                    switch (pMetodo.ToUpper())
                    {
                        case WebConstants.METHOD_POST:
                            metodo = HttpMethod.Post;
                            break;
                        case WebConstants.METHOD_PUT:
                            metodo = HttpMethod.Put;
                            break;
                        case WebConstants.METHOD_DELETE:
                            metodo = HttpMethod.Delete;
                            break;
                    }

                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = metodo,
                        RequestUri = pURLWS,
                        Content = content,
                    };

                    HttpResponseMessage result = await client.SendAsync(request);
                    var responseBody = await result.Content.ReadAsStringAsync();
                    
                    rptaResponse.isValid = result.IsSuccessStatusCode;
                    rptaResponse.data = responseBody;

                    if (!result.IsSuccessStatusCode)
                    {
                        ResponseHttpClient jsonResul = JsonConvert.DeserializeObject<ResponseHttpClient>(responseBody);
                        rptaResponse.brokenRulesCollection.Add(new BrokenRule
                        {
                             description= jsonResul.Message,
                              severity= RuleSeverity.Error,
                               
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("ProcessHttpClientRequest.", MethodBase.GetCurrentMethod().Name), ex);
                rptaResponse.brokenRulesCollection.Add(new BrokenRule
                {
                    description = ex.Message,
                    severity = RuleSeverity.Error,

                });
            }
            return rptaResponse;
        }

    }

}
