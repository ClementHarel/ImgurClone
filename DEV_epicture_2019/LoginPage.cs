/*
** EPITECH PROJECT, 2019
** DEV_Epicture_2019
** File description:
** Manage the login page
*/

using Android.Support.V7.App;
using Android.Widget;


namespace DEV_epicture_2019

{

    public partial class MainActivity : AppCompatActivity
    {
        protected void ManageButtonLogin()
        {
            Button login = FindViewById<Button>(Resource.Id.login);
            login.Click += delegate
            // When login clicked set view to WebView
            {
                SetContentView(Resource.Layout.WebView);
                ManageButtonWebView();
            };
            Button back = FindViewById<Button>(Resource.Id.back);
            back.Click += delegate
            // When back clicked set view to FrontPage
            {
                SetContentView(Resource.Layout.activity_frontpage);
                ManageButtonFrontpage();
            };
        }
    }
}