using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace AutoSanitize
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
      Title = "Auto-Sanitize";
    }

    #region Private Functions
    private void SanitizerOn(string changeValue = "on")
    {
      changeValue = "on";
      APICall(changeValue);
      ResultLabelUpdate(1);
    }

    // Bool return type needed for Device.StartTimer
    private bool SanitizerOff(string changeValue = "off")
    {
      changeValue = "off";
      APICall(changeValue);
      ResultLabelUpdate(0);
      // Returning
      return false;
    }

    void APICall(string changeValue)
    {
      string accessToken = "ab3316276923bf8378da95f69c3fff91ba572200"; //This is your Particle Cloud Access Token
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

    private void ResultLabelUpdate(int status = -1)
    {
      if (status == 1)
      {
        ResultLabel.TextColor = Color.DarkRed;
        ResultLabel.Text = "Dispensing...";
        BackgroundColor = Color.SkyBlue;
      }
      else
      {
        ResultLabel.TextColor = Color.Blue;
        ResultLabel.Text = "Have a great day!";
        BackgroundColor = Color.White;
      }
    }

    void Sanitize_Clicked(System.Object sender, System.EventArgs e)
    {
      SanitizerOn();
      Device.StartTimer(TimeSpan.FromSeconds(0.33), () => SanitizerOff());
    }
    #endregion
  }

  public class CoreInfo
  {
    public DateTime last_heard { get; set; }
    public bool connected { get; set; }
    public DateTime last_handshake_at { get; set; }
    public string deviceID { get; set; }
    public int product_id { get; set; }
  }

  public class ParticleResponse
  {
    public string cmd { get; set; }
    public string name { get; set; }
    public string result { get; set; }
    public CoreInfo coreInfo { get; set; }
  }
}
