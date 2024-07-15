using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VNotes.Commands;
using VNotes.Model;

namespace VNotes.ViewModel
{
    public class StickyNotesBlockVM
    {
        public ICommand OnSpawnStickyNote { get; set; }

        private StickyNotesHandler _stickyNotesHandler;
        public StickyNotesBlockVM(StickyNotesHandler stickyNotesHandler)
        {
            OnSpawnStickyNote = new RelayCommand(SpawnStickyNote);
            _stickyNotesHandler = stickyNotesHandler;
        }

        private void SpawnStickyNote(object obj)
        {
            _stickyNotesHandler.CreateStickyNote();
        }
    }
}
