using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace MagicCopy
{
    class ImageCollection
    {
        public ImageTag[] ImageTags { get; set; }
    }

    class ImageTag
    {
        public string ID { get; set; }
        public string TAG { get; set; }
        public string WAY { get; set; }

        public void savetags(string id, string tag, string way)
        {
            ImageCollection myCollection = new ImageCollection();

            myCollection.ImageTags = new ImageTag[1];

            myCollection.ImageTags[0] = new ImageTag()
            {
                ID = id,
                TAG = tag,
                WAY = way,
            };

            //for (int i = 0; i < 1; i++)
            //{
            //    myCollection.ImageTags[i] = new ImageTag()
            //    {
            //        ID = id,
            //        TAG = tag,
            //        WAY = way,
            //    };
            //}

            string serialized = JsonConvert.SerializeObject(myCollection);
            String UserName = Environment.UserName;
            File.AppendAllText(@"C:\Users\" + UserName + @"\AppData\Local\MagicCopy\ImageTag.json", Environment.NewLine + serialized);

            //streamWriter.WriteLine. для записи в файл
        }

    }

}
