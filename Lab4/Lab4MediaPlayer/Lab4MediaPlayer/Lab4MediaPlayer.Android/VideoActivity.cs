using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab4MediaPlayer.Droid
{
    [Activity(Label = "VideoActivity")]
    public class VideoActivity : Activity
    {
        private VideoView videoPlayer;
        private Button playButton;
        private Button pauseButton;
        private Button stopButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.VideoActivity);

            playButton = FindViewById<Button>(Resource.Id.playVideoButton);
            pauseButton = FindViewById<Button>(Resource.Id.pauseVideoButton);
            stopButton = FindViewById<Button>(Resource.Id.  stopVideoButton);

            playButton.Click += (sender, e) =>
            {
                playButton.Enabled = false;
                pauseButton.Enabled = true;
                stopButton.Enabled = true;

                videoPlayer.Start();
            };

            pauseButton.Click += (sender, e) =>
              {
                  playButton.Enabled = true;
                  pauseButton.Enabled = false;
                  stopButton.Enabled = true;

                  videoPlayer.Pause();
              };
            stopButton.Click += (sender, e) =>
            {
                playButton.Enabled = true;
                pauseButton.Enabled = false;
                stopButton.Enabled = false;

                videoPlayer.StopPlayback();
                videoPlayer.Resume();
            };

            pauseButton.Enabled = false;
            stopButton.Enabled = false;

            videoPlayer = FindViewById<VideoView>(Resource.Id.videoView);
            var packageName = Application.Context.PackageName;
            Android.Net.Uri myVideoUri = Android.Net.Uri.Parse("android.resource://" + packageName + "/" + Resource.Raw.video);
            videoPlayer.SetVideoURI(myVideoUri);
            MediaController mediaController = new MediaController(this);
            videoPlayer.SetMediaController(mediaController);
            mediaController.SetMediaPlayer(videoPlayer);
        }
    }
}