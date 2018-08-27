using BandsInTownSharp.Exceptions;
using BandsInTownSharp.ValueObject.Bit;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BandsInTownSharp.Client
{
    public class BitClient
    {
        private const string restUrl = "https://rest.bandsintown.com";

        private RestClient restClient;
        private string apiKey;

        public BitClient(string apiKey)
        {
            this.apiKey = apiKey;

            restClient = new RestClient(restUrl);
            restClient.ClearHandlers();

            restClient.AddHandler("application/json", new JsonDeserializer());
        }

        public string GetApiKey()
        {
            return apiKey;
        }

        public List<EventVo> GetArtistEvents(string artistname)
        {
            return GetArtistEvents(artistname, null, null);
        }
        
        public List<EventVo> GetArtistEvents(string artistname, DateTime? startDate, DateTime? endDate)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("artists/{0}/events", artistname);

            request.AddParameter("app_id", apiKey);

            // add search date range
            if ((startDate.HasValue) && (endDate.HasValue))
            {
                StringBuilder temp = new StringBuilder();
                temp.Append(startDate.Value.ToString("yyyy-MM-dd"));
                temp.Append(",");
                temp.Append(endDate.Value.ToString("yyyy-MM-dd"));

                request.AddParameter("date", temp);
            }

            // make the reqeust and get response
            IRestResponse<List<EventVo>> response = restClient.Execute<List<EventVo>>(request);

            if (response.Data == null)
            {
                throw new BitException(response.ErrorMessage);
            }

            return response.Data;
        }

        public ArtistVo GetArtist(string artistname)
        {
            RestRequest request = new RestRequest();
            request.Resource = string.Format("artists/{0}", artistname);

            request.AddParameter("app_id", apiKey);

            // make the reqeust and get response
            IRestResponse<ArtistVo> response = restClient.Execute<ArtistVo>(request);

            if (response.Data == null)
            {
                throw new BitException(response.ErrorMessage);
            }

            return response.Data;
        }

    }
}
