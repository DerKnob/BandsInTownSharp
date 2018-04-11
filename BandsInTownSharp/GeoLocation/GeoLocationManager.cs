using BandsInTownSharp.ValueObject;
using System;
using System.IO;
using System.Net;
using System.Xml;

namespace BandsInTownSharp.GeoLocation
{
    public class GeoLocationManager
    {
        static private Object thisLock = new Object();
        static private GeoLocationManager INSTANCE = null;

        private GeoLocationVo geoLocation = null;

        public GeoLocationManager GetInstance()
        {
            lock (thisLock)
            {
                if (INSTANCE == null)
                {
                    INSTANCE = new GeoLocationManager();
                }
                return INSTANCE;
            }
        }

        private GeoLocationManager()
        {
            InitGeoLocation();
        }

        private void InitGeoLocation()
        {
            geoLocation = new GeoLocationVo();

            try
            {
                //create a request to geoiptool.com
                var request = WebRequest.Create(new Uri("http://freegeoip.net/xml/")) as HttpWebRequest;

                if (request != null)
                {
                    //set the request user agent
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727)";

                    //get the response
                    using (var webResponse = (request.GetResponse() as HttpWebResponse))
                    {
                        if (webResponse != null)
                        {
                            using (var reader = new StreamReader(webResponse.GetResponseStream()))
                            {

                                //get the XML document
                                var doc = new XmlDocument();
                                doc.Load(reader);

                                //now we parse the XML document
                                {
                                    var nodes = doc.GetElementsByTagName("City");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.City = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("CountryName");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.CountryName = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("CountryCode");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.CountryCode = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("ZipCode");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.ZipCode = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("IP");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.IP = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("RegionCode");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.RegionCode = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("RegionName");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.RegionName = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("TimeZone");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.TimeZone = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("Latitude");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.Latitude = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("Longitude");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.Longitude = marker.InnerText;
                                }

                                {
                                    var nodes = doc.GetElementsByTagName("MetroCode");
                                    var marker = nodes[0] as XmlElement;

                                    geoLocation.MetroCode = marker.InnerText;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public string GetGeoLocationForBit()
        {
            string geoForRequest = "";

            if ((geoLocation.City != null) && (geoLocation.CountryName != null))
            {
                geoForRequest = geoLocation.City + ", " + geoLocation.CountryName;
            }

            return geoForRequest;
        }
    }
}
