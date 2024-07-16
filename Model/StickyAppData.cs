using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNotes.View;

namespace VNotes.Model
{
    [Serializable]
    public class StickyAppData
    {
        public List<StickyNote> NotesData { get; set; } = new();
        public string AppVersion { get; set; } = "1.0.0";
    }
}
