using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace BMSDemo.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem
    {
        public SampleDataItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Content = content;
        }

        public string UniqueId { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Content { get; private set; }
        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup
    {
        public SampleDataGroup(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Items = new ObservableCollection<SampleDataItem>();
        }
        public string UniqueId { get; private set; }
        public string Title { get;  set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public ObservableCollection<SampleDataItem> Items { get; private set; }
        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource();

        private ObservableCollection<SampleDataGroup> _groups = new ObservableCollection<SampleDataGroup>();
private static string imageRefrence;
private static string imgUrl;

        public ObservableCollection<SampleDataGroup> Groups
        {
            get { return this._groups; }
        }

        public static async Task<IEnumerable<SampleDataGroup>> GetGroupsAsync()
        {
            await _sampleDataSource.GetSampleDataAsync();
            return _sampleDataSource.Groups;
        }

        public static async Task<SampleDataGroup> GetGroupAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task<SampleDataItem> GetItemAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetSampleDataAsync()
        {
            if (this._groups.Count != 0)
                return;

          //  Uri dataUri = new Uri("ms-appx:///DataModel/SampleData.json");
          //StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
          //  string jsonText = await FileIO.ReadTextAsync(file);
          //  JsonObject jsonObject = JsonObject.Parse(jsonText);
          //  JsonArray jsonArray = jsonObject["Groups"].GetArray();

            SampleDataGroup group = new SampleDataGroup("A","Ashay","","","");
            group.Items.Add(new SampleDataItem("restaurant", "­Food", "dwc", "dc", "dc", "vc"));
            group.Items.Add(new SampleDataItem("gym", "­Gym", "dwc", "dc", "dc", "vc"));
            group.Items.Add(new SampleDataItem("school", "­School", "dwc", "dc", "dc", "vc"));
            group.Items.Add(new SampleDataItem("hospital", "­Hospital", "dwc", "dc", "dc", "vc"));
            group.Items.Add(new SampleDataItem("spa", "­Spa", "dwc", "dc", "dc", "vc"));
            group.Items.Add(new SampleDataItem("hotel", "­Hotel", "dwc", "dc", "dc", "vc"));
            this.Groups.Add(group);
            //foreach (JsonValue groupValue in jsonArray)
            //{
            //    JsonObject groupObject = groupValue.GetObject();
            //    SampleDataGroup group = new SampleDataGroup(groupObject["UniqueId"].GetString(),
            //                                                groupObject["Title"].GetString(),
            //                                                groupObject["Subtitle"].GetString(),
            //                                                groupObject["ImagePath"].GetString(),
            //                                                groupObject["Description"].GetString());

            //    foreach (JsonValue itemValue in groupObject["Items"].GetArray())
            //    {
            //        JsonObject itemObject = itemValue.GetObject();
            //        group.Items.Add(new SampleDataItem(itemObject["UniqueId"].GetString(),
            //                                           itemObject["Title"].GetString(),
            //                                           itemObject["Subtitle"].GetString(),
            //                                           itemObject["ImagePath"].GetString(),
            //                                           itemObject["Description"].GetString(),
            //                                           itemObject["Content"].GetString()));
            //    }
            //    this.Groups.Add(group);
            //}
            //foreach (JsonValue groupValue in jsonArray)
            //{
            //    JsonObject groupObject = groupValue.GetObject();
            //    SampleDataGroup group = new SampleDataGroup(groupObject["UniqueId"].GetString(),
            //                                                groupObject["Title"].GetString(),
            //                                                groupObject["Subtitle"].GetString(),
            //                                                groupObject["ImagePath"].GetString(),
            //                                                groupObject["Description"].GetString());

            //    foreach (JsonValue itemValue in groupObject["Items"].GetArray())
            //    {
            //        JsonObject itemObject = itemValue.GetObject();
            //        group.Items.Add(new SampleDataItem(itemObject["UniqueId"].GetString(),
            //                                           itemObject["Title"].GetString(),
            //                                           itemObject["Subtitle"].GetString(),
            //                                           itemObject["ImagePath"].GetString(),
            //                                           itemObject["Description"].GetString(),
            //                                           itemObject["Content"].GetString()));
            //    }
            //    this.Groups.Add(group);
            //}
         
        }

        public static SampleDataGroup UpdateGroupItems(RootObject rootObjFordetails)
        {
            _sampleDataSource.Groups[0].Items.Clear();
            _sampleDataSource.Groups[0].Title = rootObjFordetails.results[0].types[0];
            foreach (var item in rootObjFordetails.results) 
            {
                _sampleDataSource.Groups[0].Items.Add(new SampleDataItem(item.id, item.name,item.rating.ToString(), item.icon, "", item.reference));
            }
            return _sampleDataSource.Groups[0];            
        }

        public static SampleDataGroup UpdateDtails(RootObjectforDetails rootObjFordetails)
        {
            _sampleDataSource.Groups.Clear();
            
            if (rootObjFordetails.result.photos != null)
            {
                imageRefrence = rootObjFordetails.result.photos[0].photo_reference;
                imgUrl = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=" + imageRefrence + "&sensor=true&key=" + Utility.ListOfKeys[0];
            }
            _sampleDataSource.Groups.Add(new SampleDataGroup(rootObjFordetails.result.id, rootObjFordetails.result.name, "", imgUrl, rootObjFordetails.result.formatted_address + "\n \n " + rootObjFordetails.result.formatted_phone_number));

            if (rootObjFordetails.result.photos != null && rootObjFordetails.result.photos.Count>0)
            foreach (var item in rootObjFordetails.result.photos)
            {
                imageRefrence = item.photo_reference;
                imgUrl = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=" + imageRefrence + "&sensor=true&key=" + Utility.ListOfKeys[0];
                _sampleDataSource.Groups[0].Items.Add(new SampleDataItem("", "", "", imgUrl, "", ""));
            }

            Utility.PLaceLatitude = rootObjFordetails.result.geometry.location.lat.ToString();
            Utility.PLaceLongitude = rootObjFordetails.result.geometry.location.lng.ToString();
            return _sampleDataSource.Groups[0];
        }

        public static void UpdateFilledGroupItems(RootObject rootObjFordetails) 
        { 

            

        }

        public static void DeleteAllGroups() 
        {
            _sampleDataSource.Groups.Clear();
        }
    }
}