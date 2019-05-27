using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using System.Runtime.Remoting.Contexts;

namespace Lab4MediaPlayer.Droid
{
    [Activity(Label = "Lab4", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        //AudioManager audioManager;
        MediaPlayer mediaPlayer;
        List<string> musicFiles;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainActivity);
            mediaPlayer = new MediaPlayer();
           
            //open audio player
            Button audioPlayButton = FindViewById<Button>(Resource.Id.playAudio);
            audioPlayButton.Click += (sender, er) =>
              {
                  StartActivity(new Android.Content.Intent(this, typeof(AudioActivity)));
              };

            //open video player
            Button videoPlayButton = FindViewById<Button>(Resource.Id.playVideo);
            videoPlayButton.Click += (sender, er) =>
            {
                StartActivity(new Android.Content.Intent(this, typeof(VideoActivity)));
            };
        }

        private void LoadFiles()
        {
            var musicDirectory = Android.OS.Environment.DirectoryMusic;
            musicFiles = Directory.EnumerateFiles(musicDirectory).ToList();
        }
    }
}