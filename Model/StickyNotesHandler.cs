using System.Numerics;
using System.Runtime.CompilerServices;
using VNotes.Interfaces;
using VNotes.View;
using VNotes.ViewModel;

namespace VNotes.Model
{
    public class StickyNotesHandler
    {
        public StickyAppData Data = new();
        public Dictionary<StickyNote, StickyNoteView> Notes = new();

        public Action<int,int>? OnStickyNotesChanged = null;
        public readonly int MaxStickyNotes = 10;
       
        private Random rnd = new();
        private ISave saveLoad;
        public StickyNotesHandler(ISave saveload) 
        {
            saveLoad = saveload;
            LoadData();
        }

        private void LoadData()
        {
            Data = saveLoad.Load();
            GenerateStickyNotes();
        } 

        public void CreateStickyNote()
        {
            if (Notes.Count >= MaxStickyNotes) return;
            int testrnd = rnd.Next(0, 3);
            StickyNote NoteData = new StickyNote(Vector2.Zero, "/Assets/Images/StickyNote1.png");
            StickyNoteVM NewStickyNoteVM = new(NoteData, this);
            switch (testrnd)
            {
                case 0:
                    NewStickyNoteVM.NoteData.StickyImagePath = "/Assets/Images/StickyNote1.png";
                    break;
                
                case 1:
                    NewStickyNoteVM.NoteData.StickyImagePath = "/Assets/Images/StickyNote2.png";
                    break;
                
                case 2:
                    NewStickyNoteVM.NoteData.StickyImagePath = "/Assets/Images/StickyNote3.png";
                    break;
            }
            StickyNoteView NewStickyNoteView = new(NewStickyNoteVM);
            Notes.Add(NewStickyNoteVM.NoteData,NewStickyNoteView);
            Data.NotesData.Add(NoteData);
            NewStickyNoteView.Show();
            OnStickyNotesChanged?.Invoke(Notes.Count,MaxStickyNotes);
            saveLoad.Save(Data);
        }

        public void DeleteStickyNote(StickyNote note)
        {
            if (!Notes.ContainsKey(note)) return;

            Notes[note].Hide();
            Notes.Remove(note);
            Data.NotesData.Remove(note);
            OnStickyNotesChanged?.Invoke(Notes.Count, MaxStickyNotes);
            saveLoad.Save(Data);
        }

        private void GenerateStickyNotes()
        {
            if(Data.NotesData.Count == 0) return;

            foreach(StickyNote noteData in Data.NotesData)
            {
                StickyNoteVM NewStickyNoteVM = new(noteData, this);
                StickyNoteView NewStickyNoteView = new(NewStickyNoteVM);
                Notes.Add(NewStickyNoteVM.NoteData, NewStickyNoteView);
                NewStickyNoteView.Show();
            }
            OnStickyNotesChanged?.Invoke(Notes.Count, MaxStickyNotes);
        }
    }
}
