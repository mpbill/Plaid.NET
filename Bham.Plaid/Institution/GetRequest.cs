using System.Threading;
using Newtonsoft.Json;

namespace Bham.Plaid.Institution
{
    /// <summary>
    /// Represents a request for plaid's '/institutions/search' endpoints. The '/institutions/search' endpoint to retrieve a complete list of supported institutions that match the query.
    /// </summary>
    /// <seealso cref="SerializableContent" />
    public class GetRequest : SerializableContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRequest"/> class.
        /// </summary>
        public GetRequest()
        {
            NullValueHandling = NullValueHandling.Include;
        }

        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("secret")]
        public string Secret { get; set; }

    }
}