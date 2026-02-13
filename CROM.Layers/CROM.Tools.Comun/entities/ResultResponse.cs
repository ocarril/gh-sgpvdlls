using Newtonsoft.Json;

namespace CROM.Tools.Comun.entities
{
    public class ResultResponse<T>
    {
        public ResultResponse()
        {

        }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }


        public ResultResponse(T data, bool success, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }
    }
}
