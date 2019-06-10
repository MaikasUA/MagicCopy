using System.Runtime.Serialization;

namespace MagicCopy
{
    [DataContract]
    class SaveDataBase
    {
        [DataMember]
        public SaveTag[] SaveTags { get; set; }
    }

    [DataContract]
    class SaveTag
    {
        [DataMember]
        public bool AutoLoading { get; set; }
        [DataMember]
        public string NewSource_way { get; set; }
        [DataMember]
        public string NewOne_way { get; set; }
        [DataMember]
        public string NewTwo_way { get; set; }
        [DataMember]
        public string NewThree_way { get; set; }
        [DataMember]
        public string NewFour_way { get; set; }
        [DataMember]
        public string [] NewKey_One { get; set; }
        [DataMember]
        public string [] NewKey_Two { get; set; }
        [DataMember]
        public string [] NewKey_Three { get; set; }
        [DataMember]
        public string [] NewKey_Four { get; set; }

        //public Control Setting { get; internal set; }

        public void SaveTags(bool autoLoading, string newSource_way, string newOne_way, string newTwo_way, string newThree_way, string newFour_way, string [] newKey_One, string [] newKey_Two, string [] newKey_Three, string [] newKey_Four)
        {
            AutoLoading = autoLoading;
            NewSource_way = newSource_way;
            NewOne_way = newOne_way;
            NewTwo_way = newTwo_way;
            NewThree_way = newThree_way;
            NewFour_way = newFour_way;
            NewKey_One = newKey_One;
            NewKey_Two = newKey_Two;
            NewKey_Three = newKey_Three;
            NewKey_Four = newKey_Four;
        }
    }
}
