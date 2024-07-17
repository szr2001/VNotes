using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private int TextAreaMinSize = 500;
        public StickyNoteView(StickyNoteVM model)
        {
            Model = model;
            if(new Vector2(model.NoteData.StickyPositionX, model.NoteData.StickyPositionY) != Vector2.Zero)
            {
                Top = model.NoteData.StickyPositionY;
                Left = model.NoteData.StickyPositionX;
            }
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
            DrawingArea.IsHitTestVisible = true;
            DrawingArea.EditingMode = InkCanvasEditingMode.Ink;

            TextArea.IsHitTestVisible = false;
        }

        private void SwitchEraser(object sender, RoutedEventArgs e)
        {
            DrawingArea.IsHitTestVisible = true;
            DrawingArea.EditingMode = InkCanvasEditingMode.EraseByPoint;

            TextArea.IsHitTestVisible = false;
        }

        private void SwitchText(object sender, RoutedEventArgs e)
        {
            DrawingArea.IsHitTestVisible = false;

            TextArea.IsHitTestVisible = true;
        }

        private void MoveNote(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            Model.NoteData.StickyPositionX = (float)Left;
            Model.NoteData.StickyPositionY = (float)Top;
        }

        private void TextAreaChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
            Model.PlayPencilSound();
        }

        private void EditTextAreaText(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox == null) return;

            int caretIndex = textBox.CaretIndex;

            bool atEndOfText = caretIndex >= textBox.Text.Length;

            if (!atEndOfText)
            {
                textBox.Text = textBox.Text.Remove(caretIndex, 1);
            }

            textBox.Text = textBox.Text.Insert(caretIndex, e.Text);

            textBox.CaretIndex = caretIndex + 1;

            e.Handled = true;
        }

        private void AddDrawingStrokes(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            if (DataContext is StickyNoteVM viewModel && viewModel.NoteData != null)
            {
                viewModel.NoteData.StickyDrawing = DrawingArea.Strokes;
                Model.PlayPencilSound();
            }
        }

        bool OldDrawing = true;
        bool OldText = false;
        private void LockEditing(object sender, RoutedEventArgs e)
        {
            OldDrawing = DrawingArea.IsHitTestVisible;
            OldText = TextArea.IsHitTestVisible;

            PencilBtn.Visibility = Visibility.Hidden;
            EraserBtn.Visibility = Visibility.Hidden;
            TextBtn.Visibility = Visibility.Hidden;
            DrawingArea.IsHitTestVisible = false;
            TextArea.IsHitTestVisible = false;
        }

        private void UnlockEditing(object sender, RoutedEventArgs e)
        {
            DrawingArea.IsHitTestVisible = OldDrawing;
            TextArea.IsHitTestVisible = OldText;
            PencilBtn.Visibility = Visibility.Visible;
            EraserBtn.Visibility = Visibility.Visible;
            TextBtn.Visibility = Visibility.Visible;
        }

        private void CrumblePaperSound(object sender, RoutedEventArgs e)
        {
            Model.PlayPaperSound();
        }

        private void EraseDrawingStrokes(object sender, RoutedEventArgs e)
        {
            if (DataContext is StickyNoteVM viewModel && viewModel.NoteData != null)
            {
                viewModel.NoteData.StickyDrawing = DrawingArea.Strokes;
                Model.PlayPencilSound();
            }
        }
    }
}
