/*
** EPITECH PROJECT, 2019
** DEV_Epicture_2019
** File description:
** Manage the front page
*/


using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace DEV_epicture_2019

{

    public partial class MainActivity : AppCompatActivity
    {
        private EditText editTextTag;
        private Button tag;
        private List<string> frontpageStr;
        private ListView listView;
        private APICall frontpage;

        protected void tagClicked()
        {

            tag.Click += delegate
            {
                if (editTextTag.Visibility.Equals(Android.Views.ViewStates.Visible))
                {
                    editTextTag.Visibility = Android.Views.ViewStates.Gone;
                    if (editTextTag.Text != null)
                    {
                        frontpageStr = frontpage.GetFrontpage("user", "time", 1, "day", editTextTag.Text, tmp); // TODO remove this and ask users for the parameters they want
                        listView = FindViewById<ListView>(Resource.Id.listview);
                        listView.Adapter = new HomeScreenAdapter(this, frontpageStr);

                    }
                }
                else
                {
                    editTextTag.Visibility = Android.Views.ViewStates.Visible;
                    editTextTag.RequestFocus();
                }
            };
        }
        protected void Constructor(APICall frontpage)
        {
            APICall api = new APICall();
            if (tmp == null)
                tmp = "c15bf5ea4b40e6c6f2728a17c4173672d556823e";
            this.tag = FindViewById<Button>(Resource.Id.tag);
            this.editTextTag = FindViewById<EditText>(Resource.Id.editTextTag);
            this.frontpageStr = new List<string>();
            this.frontpageStr = frontpage.GetFrontpage("user", "time", 1, "day", tmp); // TODO remove this and ask users for the parameters they want
            tagClicked();
            listView = FindViewById<ListView>(Resource.Id.listview);
            listView.Adapter = new HomeScreenAdapter(this, frontpageStr);
            listView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            {
                string selectedFromList = listView.GetItemAtPosition(e.Position).ToString();
                Console.WriteLine(selectedFromList);
                selectedFromList = selectedFromList.Substring(20, selectedFromList.Length - 24);
                api.FavoritePicture(selectedFromList, tmp);
            };
        }
        protected void ManageButtonFrontpage()
        {
            this.frontpage = new APICall();
            Button login = FindViewById<Button>(Resource.Id.profile);

            login.Click += delegate
            {
                SetContentView(Resource.Layout.activity_main);
                ManageButtonLogin();
            };
            Constructor(frontpage);
        }
    }
}