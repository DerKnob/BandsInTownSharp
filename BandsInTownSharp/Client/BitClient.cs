using RestSharp;
using RestSharp.Deserializers;

namespace BandsInTownSharp.Client
{
    public partial class BitClient
    {
        private const string baseUrl = "https://rest.bandsintown.com";

        private string apiKey;
        private RestClient restClient;

        public int RequestCount { get; set; }
        public long DataCount { get; set; }

        public BitClient(string apiKey)
        {
            this.apiKey = apiKey;
            restClient = new RestClient(baseUrl);
            restClient.ClearHandlers();
            restClient.AddHandler("application/json", new JsonDeserializer());
            //probly not needed...
            RequestCount = 0;
            DataCount = 0;
        }

    }
}
