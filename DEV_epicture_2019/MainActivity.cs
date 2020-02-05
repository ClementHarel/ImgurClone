/*
** EPITECH PROJECT, 2019
** DEV_Epicture_2019
** File description:
** Main CS file. Used to set up the Xamarin window 
*/


using Android.Graphics;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Android.Webkit;
using System;
using System.IO;

namespace DEV_epicture_2019

{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public partial class MainActivity : AppCompatActivity
    {
        //          protected String bearer;
        private String bearer;


        public void LoadProfile(String bearer)
        {

            SetContentView(Resource.Layout.activity_profile);
            this.bearer = bearer;
            Console.WriteLine(bearer);
            ManageButtonProfile();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Init Xamarin and set screen to Frontpage (Or login ?)
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_frontpage);
            ManageButtonFrontpage();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class HomeScreenAdapter : BaseAdapter<string>
    {
        List<string> frontPageImage;
        Activity context;
        public HomeScreenAdapter(Activity context, List<string> frontPageImage)
            : base()
        {
            this.context = context;
            this.frontPageImage = frontPageImage;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override string this[int position]
        {
            get { return frontPageImage.ElementAt(position); }
        }
        public override int Count
        {
            get { return frontPageImage.Count(); }
        }
        /*
         * Create the scrollable view of the frontpage
         */

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            string ImageURLOne = frontPageImage.ElementAt(position);
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.adaptator_frontpage, null);
            ImageView imageOne = (ImageView)view.FindViewById(Resource.Id.imageOne);
            var imageBOne = ImageBitmap(ImageURLOne);
            imageOne.SetImageBitmap(imageBOne);

            return view;
        }

        /* 
         * Get Bitmap from url link
         */

        private Bitmap ImageBitmap(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            }
            return imageBitmap;
        }
    }
    public class HelloWebViewClient : WebViewClient 
    {
        public String bearer;
        MainActivity act;
        public HelloWebViewClient(MainActivity activity)
        {
            this.act = activity;
        }
        // For API level 24 and later
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl(request.Url.ToString());

            String url = view.Url;
            if (url.Contains("callback?state=APPLICATION_STATE#access_token="))
            {
                bearer = url.Substring(80, url.Length - 80);
                String[] split = bearer.Split("&");
                bearer = split[0];
                act.LoadProfile(bearer);
                return true;
            }
            return false;

        }
    }
}