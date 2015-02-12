using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BMSDemo
{
    public class ApiCalls
    {
        private static DataContractJsonSerializer dataJsonSerialize;
        private static string NextPageToken;
        static int count;

        public delegate void GetDetailsDoneWithStatus(bool success, RootObject rootObj, string errorMsg);
        public static event GetDetailsDoneWithStatus GetPlaceDetails;


        public delegate void GetDetailsWithImagesDoneWithStatus(bool success, RootObjectforDetails rootObj, string errorMsg);
        public static event GetDetailsWithImagesDoneWithStatus GetPlaceDetailsWithImages;

        private static System.IO.Stream responseBodyAsStream;
        

        public async static void CallForDetailsRequest(string refrence )
        {
            try
            {
                count = 0;
                do
                {
                    HttpClient httpClient = new HttpClient();
                    string requestUrl = "https://maps.googleapis.com/maps/api/place/details/json?reference=" + refrence + "&sensor=true&key=" + Utility.ListOfKeys[count];
                    var response = await httpClient.GetAsync(requestUrl);                  
                    var responseBodyAsStreamdetails = await response.Content.ReadAsStreamAsync();
                    responseBodyAsString = await response.Content.ReadAsStringAsync();
                    dataJsonSerialize = null;
                    dataJsonSerialize = new DataContractJsonSerializer(typeof(RootObjectforDetails));
                    rootObjectforDetails = (RootObjectforDetails)dataJsonSerialize.ReadObject(responseBodyAsStreamdetails);
                    if (rootObject.status != "OK")
                        count++;
                } while (rootObject.status != "OK");


                if (GetPlaceDetailsWithImages != null)
                    GetPlaceDetailsWithImages(true, rootObjectforDetails, "");
                // requestUrl = "https://maps.googleapis.com/maps/api/place/details/json?reference=" + item.Refrence + "&sensor=true&key=" + Utility.ListOfKeys[count];
            }
            catch (Exception) 
            {
            }
        }

        public async static void CalltoGetData(double radius, string selected_menuString)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
               count = 0;
                do
                {
                    string requestUrl = "https://maps.googleapis.com/maps/api/place/search/json?location=" + Utility.CurrentLatitude + "," + Utility.CurrentLongitude + "&radius=" + radius + "&types=" + selected_menuString + "&sensor=true&pagetoken=" + "" + "&key=" + Utility.ListOfKeys[count];
                    var response = await httpClient.GetAsync(requestUrl);
                    responseBodyAsStream = await response.Content.ReadAsStreamAsync();
                    responseBodyAsString = await response.Content.ReadAsStringAsync();
                    dataJsonSerialize = new DataContractJsonSerializer(typeof(RootObject));
                    rootObject = (RootObject)dataJsonSerialize.ReadObject(responseBodyAsStream);
                    NextPageToken = rootObject.next_page_token;
                    if (rootObject.status != "OK")
                        count++;                   

                } while (rootObject.next_page_token == null);
                if(GetPlaceDetails != null)
                GetPlaceDetails(true, rootObject, "");
            }
            catch (Exception ex) 
            {

            }
        }

      


        public static string strResult { get; set; }
        public static RootObject rootObject { get; set; }

        public static string responseBodyAsString { get; set; }

        public static RootObjectforDetails rootObjectforDetails { get; set; }
    }
}
