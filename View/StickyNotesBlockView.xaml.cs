using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VNotes.Commands;
using VNotes.Enums;
using VNotes.Model;
using VNotes.ViewModel;

namespace VNotes.View
{
    /// <summary>
    /// Interaction logic for StickyNotesBlock.xaml
    /// </summary>
    public partial class StickyNotesBlockView : Window
    {
        private StickyNotesBlockVM Model;
        public StickyNotesBlockView(StickyNotesBlockVM model)
        {
            Model = model;
            DataContext = Model;

            InitializeComponent();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void StickyNotesClick(object sender, MouseButtonEventArgs e)
        {
            Model.OnSpawnStickyNote.Execute(sender);
            Model.PlayPaperSound();
        }

        private void CloseButtonPress(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button == null) return;
            Model.PlayPaperSound();
            button.IsEnabled = false;
        }

        private void MinimiseApp(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            Model.PlayPaperSound();
        }

        private void PlaySound(object sender, MouseEventArgs e)
        {
            Model.PlayPaperSound();
        }
    }
}
