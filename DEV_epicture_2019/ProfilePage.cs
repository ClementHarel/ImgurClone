/*
** EPITECH PROJECT, 2019
** DEV_Epicture_2019
** File description:
** Manage the profile page
*/

using Android.Support.V7.App;
using Android.Widget;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Threading.Tasks;

namespace DEV_epicture_2019

{

    public partial class MainActivity : AppCompatActivity
    {
        bool isUpload = true;
        String tmp;
        protected void ManageButtonProfile()
        {
            tmp = bearer;
            isUpload = true;
            APICall apiCall = new APICall();            
            bearer = tmp;
            listView = FindViewById<ListView>(Resource.Id.listview);
            ImageView ImageView = FindViewById<ImageView>(Resource.Id.background);
            Button back = FindViewById<Button>(Resource.Id.back);
            back.Click += delegate
            // When back clicked set view to FrontPage
            {
                SetContentView(Resource.Layout.activity_main);
                ManageButtonLogin();
            };
            Button upload = FindViewById<Button>(Resource.Id.upload);
            upload.Click += async delegate
            {
                FileData filedata = await CrossFilePicker.Current.PickFile();

                if (filedata != null)
                {
                    Byte[] file = filedata.DataArray;
                    Console.WriteLine(filedata.FileName);
                    APICall api = new APICall();
                    api.UploadPicture(Convert.ToBase64String(file), filedata.FileName, "Xamarin c'est pas tiptop", tmp);
                    listView.Adapter = new HomeScreenAdapter(this, apiCall.GetPictureUploaded(tmp));
                }
            };
            Button switchPage = FindViewById<Button>(Resource.Id.switchPage);
            switchPage.Click += delegate
            {
                if (isUpload)
                {
                    isUpload = false;
                    ImageView.SetBackgroundResource(Resource.Drawable.Profile2);
                    listView.Adapter = new HomeScreenAdapter(this, apiCall.GetPictureFavorited(tmp));
                }
                else
                {
                    isUpload = true;
                    ImageView.SetBackgroundResource(Resource.Drawable.Profile);
                    listView.Adapter = new HomeScreenAdapter(this, apiCall.GetPictureUploaded(tmp));
                }
            };
            if (isUpload)
                listView.Adapter = new HomeScreenAdapter(this, apiCall.GetPictureUploaded(tmp));
            else
                listView.Adapter = new HomeScreenAdapter(this, apiCall.GetPictureFavorited(tmp));

        }
    }
}