using System.ComponentModel;
using System.Numerics;
using System.Windows;
using System.Windows.Input;
using VNotes.Commands;
using VNotes.Enums;
using VNotes.Model;
using VNotes.View;

namespace VNotes.ViewModel
{
    public class StickyNotesBlockVM: INotifyPropertyChanged
    {
        public ICommand OnSpawnStickyNote { get; set; }
        public ICommand OnCloseApp { get; set; }
        public SoundManager SoundManager { get; set; }

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
        private Random rnd = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PlayPaperSound()
        {
            SoundManager.PlayRandomSound
            (
                [SoundNames.papercrumble1, SoundNames.papercrumble2,
                SoundNames.papercrumble3,SoundNames.papercrumble4 ]
            );
        }

        public StickyNotesBlockVM(StickyNotesHandler stickyNotesHandler, SoundManager soundManager)
        {
            SoundManager = soundManager;
            OnSpawnStickyNote = new RelayCommand(SpawnStickyNote);
            OnCloseApp = new RelayCommand(CloseApp);
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

        private void CloseApp(object obj)
        {
            _ = CloseLogic();
        }

        private async Task CloseLogic()
        {
            await _stickyNotesHandler.SaveCurentData();
            App.Current.Shutdown();
        }

        private void SpawnStickyNote(object obj)
        {
            _stickyNotesHandler.CreateStickyNote();
        }
    }
}
