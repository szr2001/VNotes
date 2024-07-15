using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VNotes.Commands;
using VNotes.Model;
using VNotes.View;

namespace VNotes.ViewModel
{
    public class StickyNotesBlockVM
    {
        public ICommand OnSpawnStickyNote { get; set; }

        private StickyNotesHandler _stickyNotesHandler;
        Random rnd = new();
        public StickyNotesBlockVM(StickyNotesHandler stickyNotesHandler)
        {
            OnSpawnStickyNote = new RelayCommand(SpawnStickyNote);
            _stickyNotesHandler = stickyNotesHandler;
        }

        private void SpawnStickyNote(object obj)
        {
            _stickyNotesHandler.CreateStickyNote();

            int testrnd = rnd.Next(0, 2);
            switch (testrnd)
            {
                case 0:

                    StickyNoteVM notevm = new(new StickyNote(Vector2.Zero, "/Assets/Images/StickyNote1.png"), null!);
                    StickyNoteView view = new(notevm);
                    view.Show();
                    break;
                case 1:
                    StickyNoteVM notevm2 = new(new StickyNote(Vector2.Zero, "/Assets/Images/StickyNote2.png"), null!);
                    StickyNoteView view2 = new(notevm2);
                    view2.Show();
                    break;
                case 2:
                    StickyNoteVM notevm3 = new(new StickyNote(Vector2.Zero, "/Assets/Images/StickyNote3.png"), null!);
                    StickyNoteView view3 = new(notevm3);
                    view3.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
