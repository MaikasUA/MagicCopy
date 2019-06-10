using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicCopy
{
    class ImageTagLoad
    {
        string[] ArryInfoFile;
        public void loadingtag(string ID, string FileName, out string Tag, out string IDs/*, string[] scan, out string [] Way*/)
        {
            String UserName = Environment.UserName;
            //string[] str = new string[] {scan[0] };
            bool done = false;
            //char NO = '-';
            Tag = "";
            IDs = "";
            //Way = str;
            try
            {
                ArryInfoFile = File.ReadAllLines(@"C:\Users\" + UserName + @"\AppData\Local\MagicCopy\ImageTag.json");
            }
            catch(Exception)
            {
                File.Create(@"C:\Users\" + UserName + @"\AppData\Local\MagicCopy\ImageTag.json");
            }
            for (int i = 1; i < ArryInfoFile.Length; i++) //Загрузка по клику на imabeBox
            {
                if (done == true) { break; }
                if (!done)
                {
                    ImageCollection newImageTag = JsonConvert.DeserializeObject<ImageCollection>(ArryInfoFile[i]);
                    foreach (var info in newImageTag.ImageTags)
                    {
                        //MessageBox.Show(info.ID + info.TAG + info.WAY + Environment.NewLine);
                        if (ID == info.ID || FileName == info.WAY)
                        {
                            Tag = info.TAG;
                            IDs = info.ID;
                            done = true;
                            break;
                        }
                        else
                        {
                            Tag = "Fail";
                        }
                    }
                }
            }
            //try
            //{
            //    if (ID != "" || FileName != "" || scan[0] != "" && scan[0] != "Click") //Поиск
            //    {
            //        int k = 0;
            //        for (int i = 1; i < ArryInfoFile.Length; i++)
            //        {
            //            ImageCollection newImageTag = JsonConvert.DeserializeObject<ImageCollection>(ArryInfoFile[i]);
            //            foreach (var info in newImageTag.ImageTags)
            //            {
            //                if (scan[0] != "Click" || scan[i] == info.TAG || scan[i] == info.ID)
            //                {
            //                    bool SUCCESS = true;
            //                    for (int d = 0; d < scan.Length; d++)
            //                    {
            //                        int IndexKey = scan[d].IndexOf(NO); //Исключение тэга
            //                        string KeyString = scan[d].Remove(0, 1); //Проверка на исключение тэга
            //                        bool HasMinus = IndexKey == 0 ? true : false;
            //                        if (HasMinus && info.TAG.IndexOf(KeyString) != -1 || HasMinus && info.ID.IndexOf(KeyString) != -1)
            //                        {
            //                            SUCCESS = false;
            //                            break;
            //                        }
            //                        if (info.TAG.IndexOf(scan[d]) == -1 && !HasMinus && info.ID.IndexOf(scan[d]) == -1 && !HasMinus) { SUCCESS = false; break; }
            //                        if (SUCCESS)
            //                        {
            //                            Way[k] = info.WAY;
            //                            str = scan;
            //                            k++;
            //                            break;
            //                        }
            //                    }
            //                }
            //                //MessageBox.Show(info.ID + info.TAG + info.WAY + Environment.NewLine);
            //                if (ID == info.ID || FileName == info.WAY && scan[0] != "no")
            //                {
            //                    Tag = info.TAG;
            //                    done = true;
            //                    break;
            //                }
            //            }
            //            if (done == true) { break; }
            //        }
            //    }
            //}
            //catch(Exception)
            //{
            //    //MessageBox.Show("Error load json");
            //}

        }
    }
}
