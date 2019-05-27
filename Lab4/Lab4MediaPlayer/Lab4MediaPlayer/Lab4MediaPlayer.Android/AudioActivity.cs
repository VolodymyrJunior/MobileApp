using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab4MediaPlayer.Droid
{
    [Activity(Label = "AudioActivity")]
    public class AudioActivity : Activity
    {
        private MediaPlayer mediaPlayer;
        private Button playButton;
        private Button pauseButton;
        private Button stopButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AudioActivity);

            mediaPlayer =  MediaPlayer.Create(this, Resource.Raw.music);
            mediaPlayer.Completion += Stop;

            playButton = FindViewById<Button>(Resource.Id.playAudio);
            pauseButton = FindViewById<Button>(Resource.Id.pauseAudio);
            stopButton = FindViewById<Button>(Resource.Id.stopAudio);

            
            playButton.Click += Play;
            pauseButton.Click += Pause;
            stopButton.Click += Stop;

            pauseButton.Enabled = false;
            stopButton.Enabled = false;
        }

        private void Stop(object sender, EventArgs e)
        {
            mediaPlayer.Stop();

            pauseButton.Enabled = false;
            stopButton.Enabled = false;

            try
            {
                mediaPlayer.Prepare();
                mediaPlayer.SeekTo(0);
                playButton.Enabled = true;
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }

        public void Play(object sender, EventArgs e)
        {
            mediaPlayer.Start();

            playButton.Enabled = false;
            pauseButton.Enabled = true;
            stopButton.Enabled = true;
        }

        public void Pause(object sender, EventArgs e)
        {
            mediaPlayer.Pause();

            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = true;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (mediaPlayer.IsPlaying)
            {
                Stop(null, null);
            }
        }
    }
}