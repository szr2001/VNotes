using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNotes.Model;

namespace VNotes.Interfaces
{
    public interface ISave
    {
        public void Save(StickyAppData data);

        public StickyAppData Load();
    }
}
