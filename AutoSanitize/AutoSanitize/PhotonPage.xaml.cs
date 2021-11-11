using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace AutoSanitize
{
    public partial class PhotonPage : ContentPage
    {
        public PhotonPage()
        {
            var ChangeLedCommandOn = new Command<string>(ledOn);
            var ChangeLedCommandOff = new Command<string>(ledOff);
            var onButton = new Button { Text = "ON", Command = ChangeLedCommandOn };
            var offButton = new Button { Text = "OFF", Command = ChangeLedCommandOff };

            Title = "ParticlePhotonLED";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to being able to control Particle Photon using Xamarin Forms!"
                    },
                    onButton,
                    offButton
                }
            };
        }
        public void ledOn(string changeValue = "on")
        {
            changeValue = "on";
            string accessToken = "511338a1e729bec778042cb80457233b9642d217"; //This is your Particle Cloud Access Token
            string deviceId = "7ab70dd38a4b1fdf9be5496a"; //This is your Particle Device Id
            string partilceFunc = "led"; //This is the name of your Particle Function

            HttpClient client = new HttpClient
            {
                BaseAddress =
                new Uri("https://api.particle.io/")
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("access_token", accessToken),
                new KeyValuePair<string, string>("args", changeValue )
            });

            var result = client.PostAsync("v1/devices/" + deviceId + "/" + partilceFunc, content);
        }
        public void ledOff(string changeValue = "off")
        {
            changeValue = "off";
            string accessToken = "511338a1e729bec778042cb80457233b9642d217"; //This is your Particle Cloud Access Token
            string deviceId = "7ab70dd38a4b1fdf9be5496a"; //This is your Particle Device Id
            string partilceFunc = "led"; //This is the name of your Particle Function

            HttpClient client = new HttpClient
            {
                BaseAddress =
                new Uri("https://api.particle.io/")
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("access_token", accessToken),
                new KeyValuePair<string, string>("args", changeValue )
            });

            var result = client.PostAsync("v1/devices/" + deviceId + "/" + partilceFunc, content);
        }
    }
}
