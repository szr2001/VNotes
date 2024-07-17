using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VNotes.Enums;

namespace VNotes.Model
{
    public class SoundManager
    {
        private Dictionary<SoundNames, SoundPlayer> Sounds = new();

        private Random rnd = new();
        private int DelayInPlaySound;
        private bool IsPlayingSound = false;
        public SoundManager(int delayInPlaySound)
        {
            DelayInPlaySound = delayInPlaySound;
            string projectpath = AppDomain.CurrentDomain.BaseDirectory;
            foreach (SoundNames name in Enum.GetValues(typeof(SoundNames)))
            {
                string soundpath = $"{projectpath}/Assets/Sounds/{name}.wav";
                SoundPlayer player = new(soundpath);
                player.Load();
                Sounds.Add(name, player);
            }
        }

        public void PlaySound(SoundNames sound)
        {
            if (IsPlayingSound) return;
            if (!Sounds.ContainsKey(sound)) return;

            _ = Playing(sound);
        }

        private async Task Playing(SoundNames sound)
        {
            IsPlayingSound = true;

            Sounds[sound].Play();
            await Task.Delay(DelayInPlaySound);

            IsPlayingSound = false;
        }

        public void PlayRandomSound(SoundNames[] sounds)
        {
            int soundindex = rnd.Next(0,sounds.Length);

            PlaySound(sounds[soundindex]);
        }
    }
}
