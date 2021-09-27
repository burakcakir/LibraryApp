using System;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace KutuphaneTakip.Classes
{
    public class PopUpSettings
    {

        public static void GetVoice()
        {

            MediaPlayer mPlayer = new MediaPlayer();

            mPlayer.Open(new Uri("sounds/popupeffect.wav", UriKind.Relative));
            mPlayer.Play();

        }


        public static void PopUpShow(Popup popup)
        {

            GetVoice();

            popup.IsOpen = true;

            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(4)
            };

            timer.Tick += delegate (object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();

                if (popup.IsOpen == true)
                {
                    popup.IsOpen = false;
                }
            };

            timer.Start();

        }

    }
}
