﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoSanitize
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

        MainPage = new PhotonPage();
        //MainPage = new MainPage();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
