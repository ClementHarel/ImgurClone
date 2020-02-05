/*
** EPITECH PROJECT, 2019
** DEV_Epicture_2019
** File description:
** Manage the webView (Imgur authorization page)
*/

using System;
using Android.Support.V7.App;
using Android.Webkit;


namespace DEV_epicture_2019
{

    public partial class MainActivity : AppCompatActivity
    {
        protected void ManageButtonWebView()
        {
            String clientID = "aeca92da5f55f5b"; // Temporary
            String url = "https://api.imgur.com/oauth2/authorize?client_id=" + clientID + "&response_type=token&state=APPLICATION_STATE";
            HelloWebViewClient client = new HelloWebViewClient(this);

            WebView web_view = FindViewById<WebView>(Resource.Id.webView);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(client);
            web_view.LoadUrl(url);
//bearer = client.bearer;
        }   
        protected void GetBearer()
        {
            // TODO : URL response contains the bearer
        }
    }
}