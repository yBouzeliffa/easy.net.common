using System.Text.Json.Serialization;

namespace Easy.Net.Common
{
    public class OpeError
    {
        [JsonIgnore]
        public Exception Exception { get; set; } = null!;

        public string FriendlyMessage { get; set; } = null!;

        public OpeError(Exception exception, string message)
        {
            Exception = exception;
            FriendlyMessage = message;
        }

        [JsonIgnore]
        public Dictionary<string, string> Metadatas { get; set; } = [];
    }
}
