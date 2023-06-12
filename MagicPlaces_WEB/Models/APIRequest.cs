using static MagicPlaces_Utility.SD;

namespace MagicPlaces_WEB.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public APIToken Token { get; set; }
        public APIParams Headers { get; set; }
        public class APIToken
        {
            public string Tipo { get; set; }
            public string Value { get; set; }
        }

        public class APIParams
        {
            public Dictionary<string, string> Params { get; set; }
        }
    }
}
