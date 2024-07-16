using System.ComponentModel;
using System.Numerics;
using System.Windows;
using System.Windows.Input;
using VNotes.Commands;
using VNotes.Model;
using VNotes.View;

namespace VNotes.ViewModel
{
    public class StickyNotesBlockVM: INotifyPropertyChanged
    {
        public ICommand OnSpawnStickyNote { get; set; }

        private Visibility _stickyNoteVisibility = Visibility.Visible;
        public Visibility AreThereStickyNotesLeft 
        {
            get 
            {
                return _stickyNoteVisibility; 
            } 
            set 
            { 
                _stickyNoteVisibility = value;
                OnPropertyChanged(nameof(AreThereStickyNotesLeft));
            } 
        }

        private StickyNotesHandler _stickyNotesHandler;
        Random rnd = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public StickyNotesBlockVM(StickyNotesHandler stickyNotesHandler)
        {
            OnSpawnStickyNote = new RelayCommand(SpawnStickyNote);
            _stickyNotesHandler = stickyNotesHandler;

            _stickyNotesHandler.OnStickyNotesChanged += SetStickyNotesStackVisibility;
        }

        private void SetStickyNotesStackVisibility(int count, int maxcount)
        {
            if (count >= maxcount)
            {
                AreThereStickyNotesLeft = Visibility.Hidden;
            }
            else
            {
                AreThereStickyNotesLeft = Visibility.Visible;
            }
        }

        private void SpawnStickyNote(object obj)
        {
            _stickyNotesHandler.CreateStickyNote();
        }
    }
}
