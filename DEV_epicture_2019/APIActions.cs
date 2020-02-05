/*
** EPITECH PROJECT, 2019
** DEV_Epicture_2019
** File description:
** Class containing all the Imgur API actions of the users.
*/

using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace DEV_epicture_2019
{

    // TODO : Create objects returned by the API

    public class tagData
    {
        public data data { get; set; }
    }
    public class imgurData
    {
        public List<data> data { get; set; }
    }
    public class data
    {
        public string cover { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public List<items> items { get; set; }
    }
    public class items
    {
        public string link { get; set; }
    }


    public class APICall : MainActivity
    {

        /* This method return a list of string containing each link of the pictures displayed in
         * the frontpage. (Title and description can also be retrieved)
        */
        internal List<String> GetFrontpage(String section, String sort, int page, String window, String bearer)
        {
           List<string> pictList = new List<string>();
            while (page < 6)
            {
                String url = "https://api.imgur.com/3/gallery/" +
                    section + "/" + sort + "/" + window + "/" + page + "? Authorization = Bearer " + bearer;
                using (var wb = new WebClient())
                {
                    wb.Headers.Add("Authorization", "Bearer " + bearer);
                    var response = wb.DownloadString(url);
                    imgurData data = JsonConvert.DeserializeObject<imgurData>(response);

                    for (int i = 0; i < data.data.Count; i++)
                    {
                        if (data.data[i].link.Contains(".jpg") || data.data[i].link.Contains(".png")) // Remove when able to display gif and mp4
                            pictList.Add(data.data[i].link);
                    }
                    page++;
                }
            }
                return pictList;
        }

        internal List<String> GetFrontpage(String section, String sort, int page, String window, String tag, String bearer)
        {
            List<string> pictList = new List<string>();
            String url = "https://api.imgur.com/3/gallery/t/" +
     tag + "/" + sort + "/" + window + "/" + page + "? Authorization = Bearer " + bearer;

            using (var wb = new WebClient())
            {
                wb.Headers.Add("Authorization", "Bearer " + bearer);
                var response = wb.DownloadString(url);
                tagData data = JsonConvert.DeserializeObject<tagData>(response);
                for (int i = 0; i < data.data.items.Count; i++)
                    if (data.data.items[i].link.Contains(".jpg") || data.data.items[i].link.Contains(".png"))  // Remove when able to display gif and mp4
                        pictList.Add(data.data.items[i].link);
            }
            return pictList;
        }

        /* This Method return a list of String containing each image hash favorited by the user.
 */
        internal List<String> GetPictureFavorited(String bearer)
        {
            List<string> pictList = new List<string>();
            String url = "https://api.imgur.com/3/account/me/favorites?Authorization=Bearer " + bearer;
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Authorization", "Bearer " + bearer);
                var response = wb.DownloadString(url);
                imgurData data = JsonConvert.DeserializeObject<imgurData>(response);
                for (int i = 0; i < data.data.Count; i++)
                    pictList.Add("https://imgur.com/" + data.data[i].cover + "." + data.data[i].type.Substring(6));
                return pictList;
            }
        }

        /* This Method return a list of String containing each image hash uploaded by the user.
         */
        internal List<String> GetPictureUploaded(String bearer)
        {
            List<string> pictList = new List<string>();
            String url = "https://api.imgur.com/3/account/me/images?Authorization=Bearer " + bearer;
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Authorization", "Bearer " + bearer);
                var response = wb.DownloadString(url);
                imgurData data = JsonConvert.DeserializeObject<imgurData>(response);
                for (int i = 0; i < data.data.Count; i++)
                    pictList.Add(data.data[i].link);
                return pictList;
            }
        }
        internal bool UploadPicture(String picturePath, String imageTitle, String imageDescription, String bearer)
        {
            //To remove maybe because picturePath is already in base64


            /*            AssetManager assets = Android.App.Application.Context.Assets;
                        Stream asset = Android.App.Application.Context.Assets.Open(picturePath);
                        byte[] byteArray = streamToByteArray(asset);
            */
            String url = "https://api.imgur.com/3/upload?Authorization=Bearer " + bearer;
            using (var wb = new WebClient())
            {

                wb.Headers.Add("Authorization", "Bearer " + bearer);
                var data = new NameValueCollection();
                data["image"] = picturePath;
                data["video"] = "";
                data["disable_audio"] = "";
                data["type"] = "base64";
                data["title"] = imageTitle;
                data["description"] = imageDescription;
                var response = wb.UploadValues(url, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
                if (responseInString.Contains("true"))
                    return true;
                else
                {
                    return false;
                }
            }
        }

        internal bool FavoriteAlbum(String albumHash, String bearer)
        {
            String url = "https://api.imgur.com/3/album/" + albumHash + "/favorite?Authorization=Bearer " + bearer;
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Authorization", "Bearer " + bearer);
                var data = new NameValueCollection();
                var response = wb.UploadValues(url, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
                if (responseInString.Contains("true"))
                    return true;
                else
                    return false;
            }
        }
        internal bool FavoritePicture(String imageHash, String bearer)
        {
            String url = "https://api.imgur.com/3/image/" + imageHash + "/favorite?Authorization=Bearer " + bearer;
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Authorization", "Bearer " + bearer);
                var data = new NameValueCollection();

                var response = wb.UploadValues(url, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
                if (responseInString.Contains("true"))
                    return true;
                else
                    return false;
            }
        }
    }

}