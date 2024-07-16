using System.Drawing;
using System.Numerics;
using System.Windows.Ink;

namespace VNotes.Model
{
    public class StickyNote
    {
        public StrokeCollection StickyDrawing { get; set; } = [];
        public string StickyText { get; set; } = 
                $@"                                
                                
                                
                                
                                
                                
                                ";
        public Vector2 StickyPosition { get; set; }
        public string StickyImagePath { get; set; }
        public StickyNote(Vector2 stickyPosition, string stickyImagePath)
        {
            StickyPosition = stickyPosition;
            StickyImagePath = stickyImagePath;
        }
    }
}
