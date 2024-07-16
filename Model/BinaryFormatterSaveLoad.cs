using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using VNotes.Interfaces;

//make the BinaryFormatter work again.
#pragma warning disable SYSLIB0011

namespace VNotes.Model
{
    class BinaryFormatterSaveLoad : ISave
    {
        private readonly string savePath;

        private BinaryFormatter formatter = new();
        public BinaryFormatterSaveLoad(string savepath)
        {
            savePath = $@"{savepath}/NotesData";

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }
        }

        public StickyAppData Load()
        {
            StickyAppData? data = null;
            if (File.Exists(savePath))
            {
                using (FileStream stream = new(savePath, FileMode.Open))
                {
                    data = (StickyAppData)formatter.Deserialize(stream);
                }
            }
            if(data == null)
            {
                data = new();
            }
            return data;
        }

        public void Save(StickyAppData data)
        {
            using(FileStream stream = new(savePath,FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }
        }
    }
}
