using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Core.Utilities.Map.Google
{
    public class Geocoding
    {
        private const string _googleUri = "https://maps.googleapis.com/maps/api/geocode/json?";
        private string _googleKey; //  key 
        public string GoogleKey
        {
            get { return _googleKey; }
            set { _googleKey = value; }
        }
        private const string _outputType = "json"; // csv, xml, kml, json
        private string _url = "";

        private Location latlng;
        public Geocoding(Location latxlngx)
        {
            latlng = new Location();
            latlng.lat = latxlngx.lat;
            latlng.lng = latxlngx.lng;
        }
        private void GeocodingUrl()
        {
            _url = String.Format("{0}latlng={1},{2}&key={3}&sensor=false", _googleUri, latlng.lat, latlng.lng, _googleKey);
        }

        public RootObject geocodeRootObject()
        {
            WebRequest request = WebRequest.Create(_url);
            RootObject root = new RootObject();
            using (var twitpicResponse = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(twitpicResponse.GetResponseStream()))
                {
                    var objText = reader.ReadToEnd();
                    root = JsonConvert.DeserializeObject<RootObject>(objText);
                }

            }
            return root;
        }


        public ADDRESS adresBul()
        {
            ADDRESS yeniAdres = new ADDRESS();
            RootObject root = new RootObject();
            GeocodingUrl();
            root = geocodeRootObject();
            if (root.status == "OK")
            {
                //birden fazla adress donmus ise
                if (root.results.Count > 1)
                {
                    var results0 = root.results.ToArray();
                    for (int i = 0; i < results0.Length; i++)
                    {
                        var types0 = results0[i].types.ToArray();
                        var address_components0 = results0[i].address_components.ToArray();
                        var formatted_address0 = results0[0].formatted_address;
                        foreach (var itemType in types0)
                        {
                            if (itemType == "route")
                            {
                                yeniAdres.formatted_address = formatted_address0;


                                foreach (var adres0 in address_components0)
                                {
                                    var AddressTypes0 = adres0.types.ToArray();
                                    if (AddressTypes0[0] == "administrative_area_level_4")
                                    {
                                        yeniAdres.neighborhood = adres0.long_name;
                                    }
                                    if (AddressTypes0[0] == "administrative_area_level_2")
                                    {
                                        yeniAdres.district = adres0.long_name;
                                    }
                                    if (AddressTypes0[0] == "administrative_area_level_1")
                                    {
                                        yeniAdres.province = adres0.long_name;
                                    }
                                    if (AddressTypes0[0] == "route")
                                    {
                                        yeniAdres.street = adres0.long_name;
                                    }
                                    if (AddressTypes0[0] == "country")
                                    {
                                        if (adres0.long_name == "Turkey")
                                        {
                                            yeniAdres.country = "Türkiye";
                                        }
                                        else
                                        {
                                            yeniAdres.country = adres0.long_name;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (yeniAdres.neighborhood == null)
                    {
                        for (int i = 0; i < results0.Length; i++)
                        {
                            var types0 = results0[i].types.ToArray();
                            var address_components0 = results0[i].address_components.ToArray();
                            var formatted_address0 = results0[0].formatted_address;
                            foreach (var itemType in types0)
                            {
                                if (itemType == "street_address")
                                {
                                    yeniAdres.formatted_address = formatted_address0;

                                    foreach (var adres0 in address_components0)
                                    {
                                        var AddressTypes0 = adres0.types.ToArray();
                                        if (AddressTypes0[0] == "administrative_area_level_4")
                                        {
                                            yeniAdres.neighborhood = adres0.long_name;
                                        }
                                        if (AddressTypes0[0] == "administrative_area_level_2")
                                        {
                                            yeniAdres.district = adres0.long_name;
                                        }
                                        if (AddressTypes0[0] == "administrative_area_level_1")
                                        {
                                            yeniAdres.province = adres0.long_name;
                                        }
                                        if (AddressTypes0[0] == "route")
                                        {
                                            yeniAdres.street = adres0.long_name;
                                        }
                                        if (AddressTypes0[0] == "country")
                                        {
                                            if (adres0.long_name == "Turkey")
                                            {
                                                yeniAdres.country = "Türkiye";
                                            }
                                            else
                                            {
                                                yeniAdres.country = adres0.long_name;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return yeniAdres;
        }
    }

}
