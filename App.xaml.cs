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
            StickyNotesHandler NotesHandler = new();
            
            StickyNotesBlockVM StickyBlockVM = new(NotesHandler);
            StickyNotesBlockView Stickyblock = new(StickyBlockVM);

            Stickyblock.Show();
        }
    }
}
