using System.Runtime.Serialization;
using System.Windows.Forms;

namespace MagicCopy
{
    [DataContract]
    class FileDataBase
    {
        [DataMember]
        public FilesTag[] FileTags { get; set; }
    }

    [DataContract]
    class FilesTag
    {
        [DataMember]
        public string Artist { get; set; }
        [DataMember]
        public string Tags { get; set; }
        [DataMember]
        public string MegaLink { get; set; }
        [DataMember]
        public string TimeCreate { get; set; }
        [DataMember]
        public string ImageWay { get; set; }
        public Control Setting { get; internal set; }
        public string ID { get; internal set; }

        public void FilesTags(string artist, string tags, string megalinl, string timecreate, string imageway)
        {
            Artist = artist;
            Tags = tags;
            MegaLink = megalinl;
            TimeCreate = timecreate;
            ImageWay = imageway;
        }
    }
}
