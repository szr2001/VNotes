using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VNotes.View;
using VNotes.ViewModel;

namespace VNotes.Model
{
    public class StickyNotesHandler
    {
        public Dictionary<StickyNote, StickyNoteView> Notes = new();
        public Action<int,int>? OnStickyNotesChanged = null;
        public readonly int MaxStickyNotes = 10;
       
        private Random rnd = new();
        public StickyNotesHandler() 
        {
            GenerateStickyNotes();
        }

        public void CreateStickyNote()
        {
            if (Notes.Count >= MaxStickyNotes) return;
            int testrnd = rnd.Next(0, 3);
            StickyNoteVM NewStickyNoteVM = new(new StickyNote(Vector2.Zero, "/Assets/Images/StickyNote1.png"), this);
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
            NewStickyNoteView.Show();
            OnStickyNotesChanged?.Invoke(Notes.Count,MaxStickyNotes);
        }

        public void DeleteStickyNote(StickyNote note)
        {
            if (!Notes.ContainsKey(note)) return;

            Notes[note].Hide();
            Notes.Remove(note);
            OnStickyNotesChanged?.Invoke(Notes.Count, MaxStickyNotes);
        }
    
        private void GenerateStickyNotes()
        {

        }
    }
}
