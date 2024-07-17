using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows;
using VNotes.Model;
using VNotes.View;
using VNotes.ViewModel;

namespace VNotes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        protected override void OnStartup(StartupEventArgs e)
        {
            AllocConsole();
            base.OnStartup(e);
            SoundManager soundManager = new(delayInPlaySound: 80);
            BinaryFormatterSaveLoad SaveLoad = new(@$"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\VNotes");
            StickyNotesHandler NotesHandler = new(SaveLoad, soundManager);
            
            StickyNotesBlockVM StickyBlockVM = new(NotesHandler, soundManager);
            StickyNotesBlockView Stickyblock = new(StickyBlockVM);

            Stickyblock.Show();
        }
    }
}
