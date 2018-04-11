using RestSharp.Deserializers;

namespace BandsInTownSharp.ValueObject.Bit
{
    [DeserializeAs(Name = "venue")]
    public class VenueVo
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }

}
