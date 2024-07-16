using System.Windows.Input;
using VNotes.Commands;
using VNotes.Model;

namespace VNotes.ViewModel
{
    public class StickyNoteVM
    {
        public StickyNote NoteData { get; set; }
        public StickyNotesHandler _stickyNotesHandler;
        public ICommand OnCrumbleNote { get; set; }
        public StickyNoteVM(StickyNote noteData, StickyNotesHandler stickyNotesHandler)
        {
            NoteData = noteData;
            _stickyNotesHandler = stickyNotesHandler;

            OnCrumbleNote = new RelayCommand(CrumbleNote);
        }

        private void CrumbleNote(object ojb)
        {
            _stickyNotesHandler.DeleteStickyNote(NoteData);
        }
    }
}
