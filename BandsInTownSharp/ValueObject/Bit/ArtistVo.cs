using RestSharp.Deserializers;

namespace BandsInTownSharp.ValueObject.Bit
{
    [DeserializeAs(Name = "artist")]
    public class ArtistVo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Image_url { get; set; }
        public string Thumb_url { get; set; }
        public string Facebook_page_url { get; set; }
        public string Mbid { get; set; }
        public int Tracker_count { get; set; }
        public int Upcoming_event_count { get; set; }
    }
}
