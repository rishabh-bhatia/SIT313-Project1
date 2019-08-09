﻿using System;
using Android.Widget;
using NoteApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Toast_Android))]
namespace NoteApp.Droid
{
    public class Toast_Android : Toast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}
