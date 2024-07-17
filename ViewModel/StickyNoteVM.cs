using System.Windows.Input;
using VNotes.Commands;
using VNotes.Enums;
using VNotes.Model;

namespace VNotes.ViewModel
{
    public class StickyNoteVM
    {
        public StickyNote NoteData { get; set; }
        public StickyNotesHandler _stickyNotesHandler;
        public SoundManager SoundManager { get; set; }
        public ICommand OnCrumbleNote { get; set; }
        public StickyNoteVM(StickyNote noteData, SoundManager soundManager, StickyNotesHandler stickyNotesHandler)
        {
            NoteData = noteData;
            SoundManager = soundManager;
            _stickyNotesHandler = stickyNotesHandler;

            OnCrumbleNote = new RelayCommand(CrumbleNote);
        }

        public void PlayPaperSound()
        {
            SoundManager.PlayRandomSound
            (
                [SoundNames.papercrumble1, SoundNames.papercrumble2,
                SoundNames.papercrumble3,SoundNames.papercrumble4 ]
            );
        }

        public void PlayPencilSound()
        {
            SoundManager.PlayRandomSound
            (
                [SoundNames.pencildrawing1, SoundNames.pencildrawing2,
                SoundNames.pencildrawing3]
            );
        }

        private void CrumbleNote(object ojb)
        {
            _stickyNotesHandler.DeleteStickyNote(NoteData);
        }
    }
}
