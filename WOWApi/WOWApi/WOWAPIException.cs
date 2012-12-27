using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WOWApi
{
    public class WOWAPIError
    {
        [JsonIgnore]
        public int Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        public override string ToString()
        {

            return Code.ToString() + ": " + Reason;
        }
    }

    class WOWAPIException : Exception
    {
        public WOWAPIError Error { get; private set; }
        public string RawResult { get; private set; }
        public override string Message
        {
            get { return Error.Code.ToString() + ": " + Error.Reason; }
        }

        public WOWAPIException() : base() { }
        public WOWAPIException(string message)
            : base(message)
        {
            if (message.Contains("\"status\":\"nok\""))
            {
                Error = ParseResult(0, message);
            }
        }

        public WOWAPIException(int code, string result, Exception inner)
            : base(result, inner)
        {
            RawResult = result;
            Error = ParseResult(code, result);
        }

        public WOWAPIException(int code, string result)
        {
            RawResult = result;
            Error = ParseResult(code, result);
        }

        private static WOWAPIError ParseResult(int code, string result)
        {
            WOWAPIError error = JsonConvert.DeserializeObject<WOWAPIError>(result);
            error.Code = code;
            return error;
        }

    }
}
