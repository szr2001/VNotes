using System;
using System.IO;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Windows.Ink;
using System.Runtime.Serialization;
using System.Collections.Specialized;

namespace VNotes.Model
{
    [Serializable]
    public class StickyNote
    {
        [NonSerialized]
        private StrokeCollection? _stickyDrawing = null;

        [IgnoreDataMember]
        public StrokeCollection StickyDrawing
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
                if(_stickyDrawing == null)
                {
                    _stickyDrawing = new();
                }
                return _stickyDrawing!;
            }
            set
            {
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
