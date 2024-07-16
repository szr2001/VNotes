using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VNotes.ViewModel;

namespace VNotes.View
{
    /// <summary>
    /// Interaction logic for StickyNote.xaml
    /// </summary>
    public partial class StickyNoteView : Window
    {
        private StickyNoteVM Model;
        public StickyNoteView(StickyNoteVM model)
        {
            InkCanvas canvas = new();

            Model = model;
            DataContext = Model;
            InitializeComponent();
        }

        private void ShowNoteOptions(object sender, MouseEventArgs e)
        {
            NoteOptions.Visibility = Visibility.Visible;
        }

        private void HideNoteOptions(object sender, MouseEventArgs e)
        {
            NoteOptions.Visibility = Visibility.Hidden;
        }

        private void SwitchPencil(object sender, RoutedEventArgs e)
        {
            DrawingArea.IsEnabled = true;
            DrawingArea.IsHitTestVisible = true;
            DrawingArea.EditingMode = InkCanvasEditingMode.Ink;

            TextArea.IsEnabled = false;
            TextArea.IsHitTestVisible = false;
        }

        private void SwitchEraser(object sender, RoutedEventArgs e)
        {
            DrawingArea.IsEnabled = true;
            DrawingArea.IsHitTestVisible = true;
            DrawingArea.EditingMode = InkCanvasEditingMode.EraseByPoint;

            TextArea.IsEnabled = false;
            TextArea.IsHitTestVisible = false;
        }

        private void SwitchText(object sender, RoutedEventArgs e)
        {
            DrawingArea.IsEnabled = false;
            DrawingArea.IsHitTestVisible = false;

            TextArea.IsEnabled = true;
            TextArea.IsHitTestVisible = true;
        }

        private void MoveNote(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TextAreaChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

        }
    }
}
