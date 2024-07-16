using System;
using System.IO;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Windows.Ink;
using System.Runtime.Serialization;

namespace VNotes.Model
{
    [Serializable]
    public class StickyNote
    {
        [NonSerialized]
        private StrokeCollection? _stickyDrawing;

        [IgnoreDataMember]
        public StrokeCollection StickyDrawingw
        {
            get
            {
                if (_stickyDrawing == null && !string.IsNullOrEmpty(StickyDrawingData))
                {
                    using (var ms = new MemoryStream(Convert.FromBase64String(StickyDrawingData)))
                    {
                        _stickyDrawing = new StrokeCollection(ms);
                    }
                }
                return _stickyDrawing!;
            }
            set
            {
                Console.WriteLine("Rawr");
                _stickyDrawing = value;
                using (var ms = new MemoryStream())
                {
                    _stickyDrawing.Save(ms);
                    StickyDrawingData = Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        [DataMember]
        public string? StickyDrawingData { get; set; }


        [DataMember]
        private string stickyText =
                $@"                                
                                
                                
                                
                                
                                
                                ";

        [IgnoreDataMember]
        public string StickyText 
        {
            get 
            {
                return stickyText;
            } 
            set 
            { 
                stickyText = value;
                Console.WriteLine(stickyText);
            } 
        }

        [DataMember]
        public float StickyPositionX { get; set; }
        [DataMember]
        public float StickyPositionY { get; set; }

        [DataMember]
        public string StickyImagePath { get; set; }

        public StickyNote(Vector2 stickyPosition, string stickyImagePath)
        {
            StickyPositionX = stickyPosition.X;
            StickyPositionY = stickyPosition.Y;
            StickyImagePath = stickyImagePath;
        }
    }
}
