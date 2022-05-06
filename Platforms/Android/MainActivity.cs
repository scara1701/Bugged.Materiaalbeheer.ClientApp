﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Ingenium.Materiaalbeheer.ClientApp.Services;
using Microsoft.Identity.Client;

namespace Ingenium.Materiaalbeheer.ClientApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", Exported = true, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AuthenticationService.ParentWindow = this;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }

    }
}