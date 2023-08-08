﻿using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace BMICalculator.Droid
{
    [Activity(Label = "BMI Calculator", Icon = "@drawable/ic_launcher", MainLauncher = true)]
    public class SplashActivity : Activity
    {

        public SplashActivity()
        {
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}

