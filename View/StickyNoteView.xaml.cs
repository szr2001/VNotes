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
    }
}
