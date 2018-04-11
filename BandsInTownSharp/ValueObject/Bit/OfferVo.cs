using RestSharp.Deserializers;

namespace BandsInTownSharp.ValueObject.Bit
{
    [DeserializeAs(Name = "offer")]
    public class OfferVo
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
    }
}
