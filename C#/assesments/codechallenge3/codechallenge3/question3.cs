using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechallenge3
{
    class mobilephone
    {
        public delegate void ringeventhandler();
        public event ringeventhandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            OnRing?.Invoke();
        }
    }
    class ringtone_player
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }
    class Screendisplay
    {
        public void Showcallinfo()
        {
            Console.WriteLine("Displaying call info...");
        }
    }
    class vibrationmotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Vibrating...");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            mobilephone phone = new mobilephone();
            ringtone_player player = new ringtone_player();
            Screendisplay display = new Screendisplay();
            vibrationmotor motor = new vibrationmotor();
            phone.OnRing += player.PlayRingtone;
            phone.OnRing += display.Showcallinfo;
            phone.OnRing += motor.Vibrate;
            phone.ReceiveCall();
        }   
    }
}
