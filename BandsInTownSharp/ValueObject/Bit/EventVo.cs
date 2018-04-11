using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace BandsInTownSharp.ValueObject.Bit
{
    [DeserializeAs(Name = "event")]
    public class EventVo
    {
        public string Id { get; set; }
        public string Artist_id { get; set; }
        public string Url { get; set; }
        public object On_sale_datetime { get; set; }
        public DateTime Datetime { get; set; }
        public string Description { get; set; }
        public VenueVo Venue { get; set; }
        public List<OfferVo> Offers { get; set; }
        public List<string> Lineup { get; set; }
    }
}
