using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace BMSDemo
{
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
        public List<object> weekday_text { get; set; }
    }
    public class Aspect
    {
        public int rating { get; set; }
        public string type { get; set; }
    }
    public class Review
    {
        public List<Aspect> aspects { get; set; }
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public int rating { get; set; }
        public string text { get; set; }
        public int time { get; set; }
    }
    public class Photo
    {
        public int height { get; set; }
        public List<object> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }
    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }


    public class Result
    {
        //public Geometry geometry { get; set; }
        //public string icon { get; set; }
        //public string id { get; set; }
        //public string name { get; set; }
        //public OpeningHours opening_hours { get; set; }
        //public List<Photo> photos { get; set; }
        //public string place_id { get; set; }
        //public int price_level { get; set; }
        //public double rating { get; set; }
        //public string reference { get; set; }
        //public string scope { get; set; }
        //public List<string> types { get; set; }
        //public string vicinity { get; set; }
        public List<AddressComponent> address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public List<Review> reviews { get; set; }
        public string scope { get; set; }
        public List<string> types { get; set; }
        public string url { get; set; }
        public int user_ratings_total { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
    }

    public class RootObject
    {
        public List<object> html_attributions { get; set; }
        public string next_page_token { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

    public class RootObjectforDetails
    {
        public List<object> html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }
    //public class Result
    //{
    //    public Geometry geometry { get; set; }
    //    public string icon { get; set; }
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public List<Photo> photos { get; set; }
    //    public double rating { get; set; }
    //    public string reference { get; set; }
    //    public List<string> types { get; set; }
    //    public string vicinity { get; set; }
    //    public OpeningHours opening_hours { get; set; }
    //}

    //public class RootObject
    //{
    //    public List<Result> results { get; set; }
    //    public string next_page_token { get; set; }
    //    public string status { get; set; }
    //}
    //public class OpeningHours
    //{
    //    public bool open_now { get; set; }
    //}
    //public class Photo
    //{
    //    public int height { get; set; }
    //    public List<object> html_attributions { get; set; }
    //    public string photo_reference { get; set; }
    //    public int width { get; set; }
    //}

    
}
