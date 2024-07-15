using System.Configuration;
using System.Data;
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

            StickyNoteVM notevm = new(new StickyNote(Vector2.Zero, "Assets/Images/StickyNote2.png"), null!);
            StickyNoteView view = new(notevm);
            view.Show();

            StickyNoteVM notevm2 = new(new StickyNote(Vector2.Zero, "Assets/Images/StickyNote1.png"), null!);
            StickyNoteView view2 = new(notevm);
            view2.Show();

            StickyNoteVM notevm3 = new(new StickyNote(Vector2.Zero, "Assets/Images/StickyNote3.png"), null!);
            StickyNoteView view3 = new(notevm);
            view3.Show();

            Stickyblock.Show();
        }
    }
}
