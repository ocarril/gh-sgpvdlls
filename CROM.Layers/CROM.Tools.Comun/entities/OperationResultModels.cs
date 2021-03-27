namespace CROM.Tools.Comun.entities
{
    using CROM.Tools.Comun.Web;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class OperationResult
    {
        public OperationResult()
        {
            data = string.Empty;
            brokenRulesCollection = new List<BrokenRule>();
        }

        [DataMember]
        public List<BrokenRule> brokenRulesCollection { get; set; }

        [DataMember]
        public string data { get; set; }

        [DataMember]
        public bool isValid { get; set; }
    }

    [DataContract]
    public class BrokenRule
    {
        public BrokenRule()
        {
        }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string property { get; set; }

        [DataMember]
        public string ruleName { get; set; }

        [DataMember]
        public RuleSeverity severity { get; set; }
    }

    [DataContract]
    public enum RuleSeverity
    {
        Error = 0,
        Warning = 1,
        Information = 2,
        Success = 3
    }

    public class BaseLayer
    {
        
        protected OperationResult Error(string pClass, string pMethod, Exception ex, string pUser = "", int pIdEmpresa = 0)
        {
            string strOrigen = string.Concat(pClass, ".", pMethod);
            HelpLogging.Write(TraceLevel.Error, strOrigen, ex, pUser, pIdEmpresa.ToString());
            var operationResult = new OperationResult();
            operationResult.isValid = false;
            operationResult.brokenRulesCollection.Add(new BrokenRule
            {
                description = WebConstants.ErroresEjecucion.FirstOrDefault(x => x.Key == 1001).Value,
                severity = RuleSeverity.Error
            });
            return operationResult;
        }

        protected OperationResult Error(string pClass, string pMethod, Exception ex, string pUser = "", string pIdEmpresa = "0")
        {
            string strOrigen = string.Concat(pClass, ".", pMethod);
            HelpLogging.Write(TraceLevel.Error, strOrigen, ex, pUser, pIdEmpresa);
            var operationResult = new OperationResult();
            operationResult.isValid = false;
            operationResult.brokenRulesCollection.Add(new BrokenRule
            {
                description = WebConstants.ErroresEjecucion.FirstOrDefault(x => x.Key == 1001).Value,
                severity = RuleSeverity.Error
            });
            return operationResult;
        }

        protected OperationResult Warning(string pclass, string pmethod, string message, string pUser = "", int pIdEmpresa = 0)
        {
            string strOrigen = string.Concat(pclass, ".", pmethod);
            HelpLogging.Write(TraceLevel.Warning, strOrigen, message, pUser, pIdEmpresa.ToString());
            var operationResult = new OperationResult();
            operationResult.isValid = false;
            operationResult.brokenRulesCollection.Add(new BrokenRule
            {
                description = message,
                severity = RuleSeverity.Warning
            });
            return operationResult;
        }

        protected OperationResult Warning(string pclass, string pmethod, OperationResult message, string pUser = "", int pIdEmpresa = 0)
        {
            string strOrigen = string.Concat(pclass, ".", pmethod);
            HelpLogging.Write(TraceLevel.Warning, strOrigen, message.brokenRulesCollection[0].description, pUser,pIdEmpresa.ToString());
            var operationResult = message;
            operationResult.isValid = false;

            return operationResult;
        }

        protected OperationResult OK(object data, string pMensaje = "OK")
        {
            var operationResult = new OperationResult();
            operationResult.isValid = true;
            operationResult.data = JsonConvert.SerializeObject(data);
            operationResult.brokenRulesCollection.Add(new BrokenRule
            { severity = RuleSeverity.Success, description = pMensaje });
            return operationResult;
        }

    }
}