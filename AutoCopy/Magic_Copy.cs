using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;

//994; 520 Default size

namespace MagicCopy
{
    public partial class Magic_Copy : Form
    {
        private BackgroundWorker Worker;
        private BackgroundWorker ImageWorker;
        private FileSystemWatcher Watcher;
        private long totalMemory = GC.GetTotalMemory(true);
        private string WaySave = @"C:\Users\" + Environment.UserName + @"\AppData\Local\MagicCopy\SaveSetting.sav";
        private string WayCataloge = @"ID.sav";
        private string source_way = @"";
        private string one_way = @"";
        private string two_way = @"";
        private string three_way = @"";
        private string four_way = @"";
        private string culling_way = @"";
        private char NO = '-';

        private string[] Key1 = new string[] { };
        private string[] Key2 = new string[] { };
        private string[] Key3 = new string[] { };
        private string[] Key4 = new string[] { };
        private string[] KeyWordScan;

        //private string[] Key;
        private string[] WAYS;

        private uint TotalFile = 0;
        private uint TotalCopyFile = 0;
        private uint TotalCullingFile = 0;
        private bool EndScan = false;
        private bool Helper;
        private bool ImageStop = false;

        //General
        private float UserLimitMemory = 2048;
        private float TotalUseMem = 0;
        private int TotalPic = 0;
        //private int ClickArts;
        //private string ClickArtsID;

        private Control[] WayAndKey;
        private Control[] Way;
        private Control[] KeyWord;

        private List<PictureBox> pictureBox = new List<PictureBox>();
        private PictureBox PicBox;
        //private string source_wayPanel;
        private bool FirstImageWindow = true;
        private byte HMaxLocalImageWindow = 0;
        private int id = 0;
        private int x = 0; //Magic
        private int y = 0; //Magic
        private int k = 0; //Magic
        bool exitLoop = false;

        private string ID = ""; //Art ID
        private string SelectFileWay = ""; //Art Way


        public Magic_Copy()
        {

            //AppearanceCatalogeSelect.Visible = false; //Remove after create style
            //Size resolution = Screen.PrimaryScreen.Bounds.Size; Monotor Size
            //MessageBox.Show(resolution.ToString());
            InitializeComponent();
            SettingMod();

            CopyOnceDefault.Checked = true;

            Worker = new BackgroundWorker();
            Worker.DoWork += FuckingWorker;
            Worker.ProgressChanged += ProgressChanged;
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;

            ImageWorker = new BackgroundWorker();
            ImageWorker.DoWork += FuckingWorkerImage;
            ImageWorker.ProgressChanged += ProgressImageChanged;
            ImageWorker.WorkerReportsProgress = true;
            ImageWorker.WorkerSupportsCancellation = true;

            Watcher = new FileSystemWatcher
            {
                Path = source_way,
                SynchronizingObject = this,
                Filter = "*"
            };

            Watcher.Created += new FileSystemEventHandler(OnChanged);

            ModePanel.BackColor = Color.FromArgb(0, 0, 0, 0);
            Progress.Enabled = true;
            debugOptionsToolStripMenuItem.Visible = false;
        }

        private void MagicCopy_Load(object sender, EventArgs e)
        {
            try
            {
                CheckingFileSave();
                Watcher.Path = source_way;
                Watcher.EnableRaisingEvents = true;
            }
            catch(Exception)
            {

            }
        }

        private void Source_way_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Apply.Enabled = true;
                //AutoCheck.Enabled = true;
                source_way = NewSource_way.Text;
            }
            catch (ArgumentException)
            {
                Apply.Enabled = false;
                //AutoCheck.Enabled = false;
            }
        }

        private void Source_Click(object sender, EventArgs e) //Select Source Folder
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                NewSource_way.Text = SOURCE.SelectedPath;
                source_way = SOURCE.SelectedPath;
            }
        }

        private void One_way_TextChanged(object sender, EventArgs e) //one way
        {
            one_way = NewOne_way.Text;
            
        }
        private void One_Click(object sender, EventArgs e)//Way for key word 1
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                NewOne_way.Text = SOURCE.SelectedPath;
                one_way = SOURCE.SelectedPath;
            }
        }

        private void Tow_way_TextChanged(object sender, EventArgs e) //two way
        {
            two_way = NewTwo_way.Text;
        }

        private void Tow_Click(object sender, EventArgs e) //Way for key word 2
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                NewTwo_way.Text = SOURCE.SelectedPath;
                two_way = SOURCE.SelectedPath;
            }
        }

        private void Three_way_TextChanged(object sender, EventArgs e) //three way
        {
            three_way = NewThree_way.Text;
        }

        private void Three_Click(object sender, EventArgs e) //Way for key word 3
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                NewThree_way.Text = SOURCE.SelectedPath;
                three_way = SOURCE.SelectedPath;
            }
        }

        private void Four_way_TextChanged(object sender, EventArgs e) //four way
        {
            four_way = NewFour_way.Text;
        }

        private void Four_Click(object sender, EventArgs e) //Way for key word 4
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                NewFour_way.Text = SOURCE.SelectedPath;
                four_way = SOURCE.SelectedPath;
            }
        }
        DateTime lastRead = DateTime.MinValue;

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(source_way);
            if (lastWriteTime != lastRead && AutoCheck.Checked)
            {
                lastRead = lastWriteTime;
                CopyFiles();
            }
        }

        private void FuckingWorker(object source, DoWorkEventArgs e) //The bitch got all the nerves
        {
            CopyFiles();
        }

        private void FuckingWorkerImage(object source, DoWorkEventArgs e)
        {
            DebugImageCheck();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cullingCheck.Checked == true && culling_way.Length < 3)
                {
                    MessageBox.Show("Error Culling way!");
                }
                else
                {
                    Worker.RunWorkerAsync();
                }
            }
            catch (Exception)
            {

            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (EndScan)
                {
                    Progress.Value = 0;
                }
                if (e.ProgressPercentage == -1)
                {
                    Progress.Maximum = (int)e.UserState;
                }
                else
                {
                    Progress.Value = e.ProgressPercentage;
                }
                if (Progress.Value == Progress.Maximum)
                {
                    Progress.Value = 0;
                }
            }
            catch (Exception)
            {

            }
        }

        private void ProgressImageChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (EndScan)
                {
                    Progress.Value = 0;
                }
                if (e.ProgressPercentage == -1)
                {
                    Progress.Maximum = (int)e.UserState;
                }
                else
                {
                    Progress.Value = e.ProgressPercentage;
                }
                if (Progress.Value == Progress.Maximum)
                {
                    Progress.Value = 0;
                }
            }
            catch (Exception)
            {

            }
        }

        private void CopyFiles()
        {
            Invoke((MethodInvoker)delegate
            {
                ScanModePbtn.Enabled = false;
                DebugBTN.Enabled = false;
            });

            EndScan = false;
            //What.Text = "";
            //Key0 = NewKey_One.Text;
            Key1 = NewKey_One.Text.Split(',');
            Key2 = NewKey_Two.Text.Split(',');
            Key3 = NewKey_Three.Text.Split(',');
            Key4 = NewKey_Four.Text.Split(',');
            
            for (int i = 0; i < Key1.Length; i++)
            {
                Key1[i] = Key1[i].Trim();
            }
            for (int i = 0; i < Key2.Length; i++)
            {
                Key2[i] = Key2[i].Trim();
            }
            for (int i = 0; i < Key3.Length; i++)
            {
                Key3[i] = Key3[i].Trim();
            }
            for (int i = 0; i < Key4.Length; i++)
            {
                Key4[i] = Key4[i].Trim();
            }

            if (source_way != "") //Checking all way and key word on null and void
            {
                WAYS = new string[]
                {
                    one_way,
                    two_way,
                    three_way,
                    four_way,
                };

                int i = 0;
                for (; ;)
                {
                    if (i == 4)
                    {
                        MessageBox.Show("All way or key word is empty!\nOr error way.");
                        break;
                    }
                    if (WAYS[i] == ""/* || Key[i] == ""*/)//Решить проблему ключевых слов
                    {
                        i++;
                    }
                    else
                    {
                        for (int a = 0; a < Key1.Length; a++)
                        {
                            Key1[a] = Key1[a].ToLower();
                        }
                        for (int a = 0; a < Key2.Length; a++)
                        {
                            Key2[a] = Key2[a].ToLower();
                        }
                        for (int a = 0; a < Key3.Length; a++)
                        {
                            Key3[a] = Key3[a].ToLower();
                        }
                        for (int a = 0; a < Key4.Length; a++)
                        {
                            Key4[a] = Key4[a].ToLower();
                        }
                        break;
                    }
                }
            }

            string[] WAY = new string[4];
            {
                WAY[0] = one_way;
                WAY[1] = two_way;
                WAY[2] = three_way;
                WAY[3] = four_way;
            }
            string[][] KEYWORDArry = new string[][]
            {
                Key1,
                Key2,
                Key3,
                Key4            
            };

            if (source_way.Length < 3) { MessageBox.Show("Error source way!"); return; }

            DirectoryInfo FileInfo = new DirectoryInfo(source_way); //Assuming Test is your Folder

            if (!FileInfo.Exists) { MessageBox.Show("Error way!"); return; }

            FileInfo[] Files = FileInfo.GetFiles("*"); //Getting Text files

            for (byte i = 0; i < WAY.Length; i++)
            {
                if (WAY[i] == source_way && WAY[i].Length != 1 && WAY[i] != "*")
                {
                    if (Russian.Checked) { MessageBox.Show("Ошибка! Исходный и конечный пути не должны быть одинаковыми"); }
                    if (Ukrainian.Checked) { MessageBox.Show("Помилка! Вихідний і кінцевий шляху не повинні бути однаковими"); }
                    else { MessageBox.Show("Error! The source and destination paths must not be the same"); }
                    Invoke((MethodInvoker)delegate
                    {
                        ScanModePbtn.Enabled = true;
                        DebugBTN.Enabled = true;
                    });
                    return;
                }
            }

            //Progress.Maximum = Files.Length; //Progress bar
            Worker.ReportProgress(-1, Files.Length);
            int Value = 0;
            EndScan = false;
            try
            {
                if (one_way.Length >= 3) { DirectoryInfo di1 = Directory.Exists(one_way) ? new DirectoryInfo(one_way) : Directory.CreateDirectory(one_way); }
                if (two_way.Length >= 3) { DirectoryInfo di2 = Directory.Exists(two_way) ? new DirectoryInfo(two_way) : Directory.CreateDirectory(two_way); }
                if (three_way.Length >= 3) { DirectoryInfo di3 = Directory.Exists(three_way) ? new DirectoryInfo(three_way) : Directory.CreateDirectory(three_way); }
                if (four_way.Length >= 3) { DirectoryInfo di4 = Directory.Exists(four_way) ? new DirectoryInfo(four_way) : Directory.CreateDirectory(four_way); }
                //if (culling_way.Length >= 3) { DirectoryInfo di4 = Directory.Exists(culling_way) ? new DirectoryInfo(culling_way) : Directory.CreateDirectory(culling_way); }
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Error way!");
                return;
            }

            byte[] KEYS = new byte[4];

            foreach (FileInfo file in Files)
            {
                TotalFile++;
            }

            foreach (FileInfo file in Files) //Copy file
            {
                if (Worker.CancellationPending)
                {
                    return;
                }

                string RemoveTrashSymbol = file.Name.ToLower();
                Remove_Trash(RemoveTrashSymbol, out RemoveTrashSymbol);

                string[] KEY = new string[4];

                try
                {
                    Worker.ReportProgress(++Value, -1);

                    if (Key1.Length >= 0 && Key1[0] != "" || KEYS[0] == 1 || Key1[0] == "*") //Scanning files in the source folder for matches
                    {
                        bool SUCCESS = true;
                        for (int i = 0; i < Key1.Length; i++)
                        {
                            int IndexKey = Key1[i].IndexOf(NO);
                            string KeyString = Key1[i].Remove(0, 1);

                            bool HasMinus = IndexKey == 0 ? true : false;

                            if (HasMinus && RemoveTrashSymbol.IndexOf(KeyString) != -1)
                            {
                                SUCCESS = false;
                                break;
                            }

                            if (RemoveTrashSymbol.IndexOf(Key1[i]) == -1 && !HasMinus) { SUCCESS = false; break; }

                        }
                        if (SUCCESS || Key1[0] == "*")
                        {
                            try
                            {

                                string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                                string destFile = Path.Combine(one_way, file.Name); //Set the path for copying a file

                                if (Advanced.Checked && DeleteModTumbler1.Checked && AnotherTest1.Checked) //Delete mod
                                {
                                    File.Delete(sourceFile);
                                }

                                else { File.Copy(sourceFile, destFile, true); } //Copy file

                                if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }


                                TotalCopyFile++;

                                //if (AnotherTestDefault.Checked)
                                //{
                                //    KEYS[0] = 2;
                                //    NewChecked(RemoveTrashSymbol, KEYS, KEY);
                                //}

                            }
                            catch(Exception)
                            {

                            }
                        }
                    }

                    if (Key2.Length >= 0 && Key2[0] != "" || KEYS[1] == 1 || Key2[0] == "*") //Scanning files in the source folder for matches
                    {
                        bool SUCCESS = true;
                        for (int i = 0; i < Key2.Length; i++)
                        {
                            int IndexKey = Key2[i].IndexOf(NO);
                            string KeyString = Key2[i].Remove(0, 1);

                            bool HasMinus = IndexKey == 0 ? true : false;

                            if (HasMinus && RemoveTrashSymbol.IndexOf(KeyString) != -1)
                            {
                                SUCCESS = false;
                                break;
                            }

                            if (RemoveTrashSymbol.IndexOf(Key2[i]) == -1 && !HasMinus) { SUCCESS = false; break; }
                        }
                        if (SUCCESS || Key2[0] == "*")
                        {
                            try
                            {
                                string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                                string destFile = Path.Combine(two_way, file.Name); //Set the path for copying a file

                                if (Advanced.Checked && DeleteModTumbler2.Checked && AnotherTest2.Checked) //Delete mod
                                {
                                    File.Delete(sourceFile);
                                }

                                else { File.Copy(sourceFile, destFile, true); } //Copy file

                                if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }

                                TotalCopyFile++;

                                //if (AnotherTestDefault.Checked)
                                //{
                                //    KEYS[1] = 2;
                                //    NewChecked(RemoveTrashSymbol, KEYS, KEY);
                                //}

                                //if (Advanced.Checked) //Checking Advanced setting
                                //{
                                //    if (DeleteOriginal1.Checked) { File.Delete(sourceFile); }

                                //    if (AnotherTest1.Checked)
                                //    {
                                //        KEYS[1] = 2;
                                //        NewChecked(RemoveTrashSymbol, KEYS, KEY);
                                //    }
                                //}
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    if (Key3.Length >= 0 && Key3[0] != "" || KEYS[2] == 1 || Key3[0] == "*") //Scanning files in the source folder for matches
                    {
                        bool SUCCESS = true;
                        for (int i = 0; i < Key3.Length; i++)
                        {
                            int IndexKey = Key3[i].IndexOf(NO);
                            string KeyString = Key3[i].Remove(0, 1);

                            bool HasMinus = IndexKey == 0 ? true : false;

                            if (HasMinus && RemoveTrashSymbol.IndexOf(KeyString) != -1)
                            {
                                SUCCESS = false;
                                break;
                            }

                            if (RemoveTrashSymbol.IndexOf(Key3[i]) == -1 && !HasMinus) { SUCCESS = false; break; }
                        }
                        if (SUCCESS || Key3[0] == "*")
                        {
                            string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                            string destFile = Path.Combine(three_way, file.Name); //Set the path for copying a file

                            if (Advanced.Checked && DeleteModTumbler3.Checked && AnotherTest3.Checked) //Delete mod
                            {
                                File.Delete(sourceFile);
                            }

                            else { File.Copy(sourceFile, destFile, true); } //Copy file

                            if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }

                            TotalCopyFile++;

                            //if (AnotherTestDefault.Checked)
                            //{
                            //    KEYS[2] = 2;
                            //    NewChecked(RemoveTrashSymbol, KEYS, KEY);
                            //}

                            //if (Advanced.Checked) //Checking Advanced setting
                            //{
                            //    if (DeleteOriginal1.Checked) { File.Delete(sourceFile); }

                            //    if (AnotherTest1.Checked)
                            //    {
                            //        KEYS[2] = 2;
                            //        NewChecked(RemoveTrashSymbol, KEYS, KEY);
                            //    }
                            //}
                        }
                    }
                    if (Key4.Length >= 0 && Key4[0] != "" || KEYS[3] == 1 || Key4[0] == "*") //Scanning files in the source folder for matches
                    {
                        bool SUCCESS = true;
                        for (int i = 0; i < Key4.Length; i++)
                        {
                            int IndexKey = Key4[i].IndexOf(NO);
                            string KeyString = Key4[i].Remove(0, 1);

                            bool HasMinus = IndexKey == 0 ? true : false;

                            if (HasMinus && RemoveTrashSymbol.IndexOf(KeyString) != -1)
                            {
                                SUCCESS = false;
                                break;
                            }

                            if (RemoveTrashSymbol.IndexOf(Key4[i]) == -1 && !HasMinus) { SUCCESS = false; break; }
                        }
                        if (SUCCESS || Key4[0] == "*")
                        {
                            string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                            string destFile = Path.Combine(four_way, file.Name); //Set the path for copying a file

                            if (Advanced.Checked && DeleteModTumbler4.Checked && AnotherTest4.Checked) //Delete mod
                            {
                                File.Delete(sourceFile);
                            }

                            else { File.Copy(sourceFile, destFile, true); } //Copy file

                            if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }

                            TotalCopyFile++;

                            //if (AnotherTestDefault.Checked)
                            //{
                            //    KEYS[3] = 2;
                            //    NewChecked(RemoveTrashSymbol, KEYS, KEY);
                            //}

                            //if (Advanced.Checked) //Checking Advanced setting
                            //{
                            //    if (DeleteOriginal1.Checked) { File.Delete(sourceFile); }

                            //    if (AnotherTest1.Checked)
                            //    {
                            //        KEYS[3] = 2;
                            //        NewChecked(RemoveTrashSymbol, KEYS, KEY);
                            //    }
                            //}
                        }
                    }
                    //else if (cullingCheck.Checked && culling_way.Length > 3) //Culling
                    //{
                    //    for (byte i = 0; i < FNstring.Length; i++)
                    //    {
                    //        if (FNstring[i] == -1)
                    //        {
                    //            string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                    //            string destFile = Path.Combine(culling_way, file.Name); //Set the path for copying a file
                    //            File.Copy(sourceFile, destFile, true); //Copy file
                    //            TotalCullingFile++;
                    //            if (DeleteCulling.Checked) { File.Delete(sourceFile); };
                    //        }
                    //        else
                    //            i++;
                    //    }
                    //}
                    //for (int i = 0; i < 4; i++)
                    //{
                    //    if (KEYS[i] == 2 && Advanced.Checked)
                    //    {
                    //        string sourceFile = Path.Combine(source_way, file.Name);

                    //        File.Delete(sourceFile);
                    //    }
                    //    if (KEYS[i] == 2 && Default.Checked && DeleteAfterTestDefault.Checked)
                    //    {
                    //        string sourceFile = Path.Combine(source_way, file.Name);

                    //        File.Delete(sourceFile);
                    //        i = 4;
                    //    }
                    //}
                    //KEYS[0] = 0;
                    //KEYS[1] = 0;
                    //KEYS[2] = 0;
                    //KEYS[3] = 0;
                }
                catch (Exception) //Catching errors
                {
                    //MessageBox.Show("Not found");
                }
            }
            if (Notifications.Checked)
            {
                Invoke((MethodInvoker)delegate
                {
                    ScanModePbtn.Enabled = true;
                    DebugBTN.Enabled = true;
                    ClearBTNimage.Enabled = true;
                });
                string MessageString = String.Format("Done! \nTotal files: {0} \nMatched: {1} \nCulling {2}", TotalFile, TotalCopyFile, TotalCullingFile);
                MessageBox.Show(MessageString);
            }
            TotalFile = 0;
            TotalCopyFile = 0;
            TotalCullingFile = 0;
            EndScan = true;
            //What.Text = "Copy over";
            Invoke((MethodInvoker)delegate
            {
                ScanModePbtn.Enabled = true;
                DebugBTN.Enabled = true;
                ClearBTNimage.Enabled = true;
                CallClear();
            });
        }

        private static void NewChecked(string FN, byte[] KEYS, string[] KEY)
        {
            for (byte i = 0; i < KEYS.Length; i++)
            {
                try
                {
                    if (KEYS[i] == 2) { i++; }
                    if (FN.IndexOf(KEY[i]) != -1) { KEYS[i] = 1; }
                }
                catch (Exception)
                {

                }
            }
        }

        private void Close_Click(object sender, EventArgs e) //Close program
        {
            Invoke((MethodInvoker)delegate
            {
                ScanModePbtn.Enabled = true;
                DebugBTN.Enabled = true;
                ClearBTNimage.Enabled = true;
            });
            Close();
        }

        private void What_Click(object sender, EventArgs e) //Progress bar
        {
            Enabled = false;
        } 

        private void Default_CheckedChanged(object sender, EventArgs e) //Default setting
        {
            AdvancedDeletePanel.Enabled = false;
            DefaultPanel.Enabled = true;

            SettingMod();
        }

        private void Advanced_CheckedChanged(object sender, EventArgs e) //Advanced setting
        {
            AdvancedDeletePanel.Enabled = true;
            DefaultPanel.Enabled = false;

            SettingMod();
        }

        private void SettingMod()
        {
            if (!Advanced.Checked) //Default Mod
            {
                this.MaximumSize = new Size(778, 420);
                this.MinimumSize = MaximumSize;
                this.ProgramMod.Location = new Point(12, 180);
                this.Source.ClientSize = new Size(182, 20);
                this.Source.Location = new Point(572, 20);
                this.NewSource_way.ClientSize = new Size(551, 20);
                this.NewSource_way.Location = new Point(11, 22);
                this.AdvancedDeletePanel.Visible = false;
                this.Language.Location = new Point(11, 105);
                //this.BTNinfo.Location = new Point(11, 230);
                this.InfoRichTextBox.Location = new Point(200, 105);
                this.ModePanel.Visible = false;
                this.ModePanel2.Visible = false;
                this.WayPanel.Location = new Point(11, 48);
                this.ProgramMod.Location = new Point(12, 213);
            }
            else //Advanced Mod
            {
                this.MaximumSize = new Size(994, 520);
                this.MinimumSize = MaximumSize;
                this.Source.ClientSize = new Size(206, 20);
                this.Source.Location = new Point(759, 20);
                this.NewSource_way.ClientSize = new Size(738, 20);
                this.NewSource_way.Location = new Point(11, 22);
                this.AdvancedDeletePanel.Visible = true;
                this.Language.Location = new Point(12, 206);
                //this.BTNinfo.Location = new Point(11, 284);
                this.InfoRichTextBox.Location = new Point(199, 206);
                this.ModePanel.Visible = true;
                this.ModePanel2.Visible = true;
                this.WayPanel.Location = new Point(11, 48);
                //this.ProgramMod.Location = new Point(12, 313);
            }
        }

        private void Stop_Click(object sender, EventArgs e) //Stop copy
        {
            Worker.CancelAsync();
            Progress.Value = 0;
        }

        private void FastTranslation()
        {
            NewTwo_way.Cue = NewOne_way.Cue;
            NewThree_way.Cue = NewOne_way.Cue;
            NewFour_way.Cue = NewOne_way.Cue;
            NewKey_Two.Cue = NewKey_One.Cue;
            NewKey_Three.Cue = NewKey_One.Cue;
            NewKey_Four.Cue = NewKey_One.Cue;
            DeleteModTumbler2.Text = DeleteModTumbler1.Text;
            DeleteModTumbler3.Text = DeleteModTumbler1.Text;
            DeleteModTumbler4.Text = DeleteModTumbler1.Text;
            AnotherTest2.Text = AnotherTest1.Text;
            AnotherTest3.Text = AnotherTest1.Text;
            AnotherTest4.Text = AnotherTest1.Text;
            DeleteOriginal2.Text = DeleteOriginal1.Text;
            DeleteOriginal3.Text = DeleteOriginal1.Text;
            DeleteOriginal4.Text = DeleteOriginal1.Text;
            CopyOnce2.Text = CopyOnce1.Text;
            CopyOnce3.Text = CopyOnce1.Text;
            CopyOnce4.Text = CopyOnce1.Text;
            Clone2.Text = Clone1.Text;
            BTNClear2.Text = BTNClear1.Text;
            DeleteCulling.Text = DeleteModTumbler1.Text;
        }

        private void English_CheckedChanged(object sender, EventArgs e) //English Localization
        {
            Advanced.Text = "Advanced";
            DeleteOriginal1.Text = "Delete after copying";
            AnotherTest1.Text = "Only delete";
            CopyOnce1.Text = "Copy once";
            Default.Text = "Default";
            AnotherTestDefault.Text = "Only delete";
            DeleteOriginalFile.Text = "Delete all original file";
            CopyOnceDefault.Text = "Copy (1 file to 1 folder)";
            Source.Text = "Source folder";
            Apply.Text = "Start";
            Stop.Text = "Stop";
            Close.Text = "Close";
            fileToolStripMenuItem.Text = "File";
            resetToolStripMenuItem.Text = "Reset";
            saveToolStripMenuItem.Text = "Save";
            loadToolStripMenuItem.Text = "Loading";
            closeToolStripMenuItem.Text = "Close";
            AutoLoading.Text = "Auto loading setting";
            AutoCheck.Text = "Automatic tracking";
            BTNinfo.Text = "Info";
            DeleteModTumbler1.Text = "Unlock delete mod";
            Clone1.Text = "Clone";
            BTNClear1.Text = "Clear";
            Notifications.Text = "Show notifications";
            DeleteAfterTestDefault.Text = "Delete after test";
            NewSource_way.Cue = "The path to the folder in which the scan occurs. Example C:\\My Folder";
            NewOne_way.Cue = "Where to move";
            NewKey_One.Cue = "Key word for scan";
            NewCulling_way.Cue = "Way for culling";
            CullingFolder.Text = "Culling folder";
            cullingCheck.Text = "Use culling";
            ScanModePbtn.Text = "Collection";
            helpInfoToolStripMenuItem.Text = "\"Collection\"  Help";
            FastTranslation();
        }

        private void Russian_CheckedChanged(object sender, EventArgs e) //Russian Localization
        {
            Advanced.Text = "Расширенные";
            DeleteOriginal1.Text = "Удалить после копирования";
            AnotherTest1.Text = "Только удаление";
            CopyOnce1.Text = "Одно копирование";
            Default.Text = "По умолчанию";
            AnotherTestDefault.Text = "Только удаление";
            DeleteOriginalFile.Text = "Удалить оригинальные файлы";
            CopyOnceDefault.Text = "Копирование (1 файл в 1 папку)";
            Source.Text = "Исходная папка";
            Apply.Text = "Пуск";
            Stop.Text = "Остановить";
            Close.Text = "Закрыть";
            fileToolStripMenuItem.Text = "Файл";
            resetToolStripMenuItem.Text = "Сбросить";
            saveToolStripMenuItem.Text = "Сохранить";
            loadToolStripMenuItem.Text = "Загрузить";
            closeToolStripMenuItem.Text = "Закрыть";
            AutoLoading.Text = "Автозагрузка установок";
            AutoCheck.Text = "Автоматическое слежение";
            BTNinfo.Text = "Информация";
            DeleteModTumbler1.Text = "Режим удаления";
            Clone1.Text = "Клонировать";
            BTNClear1.Text = "Очистить";
            Notifications.Text = "Показывать уведомления";
            DeleteAfterTestDefault.Text = "Удалить после проверки";
            NewSource_way.Cue = "Путь к папке, в которой происходит сканирование. Пример C:\\My Folder";
            NewOne_way.Cue = "Куда перемещать";
            NewKey_One.Cue = "Ключевое слово для поиска";
            NewCulling_way.Cue = "Путь для отбраковки";
            CullingFolder.Text = "Папка отбраковки";
            cullingCheck.Text = "Отбраковка";
            ScanModePbtn.Text = "Коллекция";
            helpInfoToolStripMenuItem.Text = "\"Коллекция\" Помощь";
            FastTranslation();
        }

        private void Ukrainian_CheckedChanged(object sender, EventArgs e) //Ukrainian Localization
        {
            Advanced.Text = "Розширені";
            DeleteOriginal1.Text = "Видалити після копіювання";
            AnotherTest1.Text = "Тiльки видалення";
            CopyOnce1.Text = "Одне копіювання";
            Default.Text = "Стандартнi";
            AnotherTestDefault.Text = "Тiльки видалення";
            DeleteOriginalFile.Text = "Видалити оригінальні файли";
            CopyOnceDefault.Text = "Копівання (1 файл в 1 папку)";
            Source.Text = "Вихідна папка";
            Apply.Text = "Пуск";
            Stop.Text = "Зупинити";
            Close.Text = "Закрити";
            fileToolStripMenuItem.Text = "Файл";
            saveToolStripMenuItem.Text = "Зберегти";
            loadToolStripMenuItem.Text = "Завантажити";
            resetToolStripMenuItem.Text = "Скинуты";
            closeToolStripMenuItem.Text = "Закрити";
            AutoLoading.Text = "Автозавантаження установок";
            AutoCheck.Text = "Автоматичне стеження";
            BTNinfo.Text = "Інформація";
            DeleteModTumbler1.Text = "Режим видалення";
            Clone1.Text = "Клонувати";
            BTNClear1.Text = "Очистити";
            Notifications.Text = "Показувати сповіщення";
            DeleteAfterTestDefault.Text = "Видалити після перевірки";
            NewSource_way.Cue = "Шлях до папки, в якій відбувається сканування. Приклад C:\\My Folder";
            NewOne_way.Cue = "Куди переміщати";
            NewKey_One.Cue = "Ключове слово для сканування";
            NewCulling_way.Cue = "Шлях для відбраковування";
            CullingFolder.Text = "Папка відбраковування";
            cullingCheck.Text = "Відбраковування";
            ScanModePbtn.Text = "Колекція";
            helpInfoToolStripMenuItem.Text = "\"Колекцiя\" Допомога";
            FastTranslation();
        }

        private void SaveSetting(object sender, EventArgs e)
        {
            string SaveText = "This is a save file executed through the ass.";
            try
            {
                string[] WayAndKey = 
                {   AutoLoading.Checked.ToString(), source_way, one_way, two_way,
                    three_way, four_way, culling_way, NewKey_One.Text, NewKey_Two.Text,
                    NewKey_Three.Text, NewKey_Four.Text,
                    English.Checked.ToString(),
                    Russian.Checked.ToString(),
                    Ukrainian.Checked.ToString(),
                    Default.Checked.ToString(),
                    Advanced.Checked.ToString(),
                    SaveText
                };

                File.WriteAllLines(path: WaySave, contents: WayAndKey, encoding: Encoding.UTF8);
            }
            catch(Exception)
            {
                MessageBox.Show("Unexpected save error!");
            }
        }

        private void LoadingSetting_Click(object sender, EventArgs e)
        {
            LoadingSetting();
        }

        private void CheckingFileSave()
        {
            Control AutoLoadingChecking = AutoLoading;
            string[] readSetting = File.ReadAllLines(WaySave, Encoding.UTF8);
            if (readSetting[0] == "True")
            {
                LoadingSetting();
            }
        }

        private void LoadingSetting()
        {
            WayAndText();
            try
            {
                string[] readSetting = File.ReadAllLines(WaySave, Encoding.UTF8);
                AutoLoading.Checked = Convert.ToBoolean(readSetting[0]);
                try
                {
                    for (int i = 1; i < 11; i++) { WayAndKey[i].Text = readSetting[i]; }
                    English.Checked = Convert.ToBoolean(readSetting[11]);
                    Russian.Checked = Convert.ToBoolean(readSetting[12]);
                    Ukrainian.Checked = Convert.ToBoolean(readSetting[13]);
                    Default.Checked = Convert.ToBoolean(readSetting[14]);
                    Advanced.Checked = Convert.ToBoolean(readSetting[15]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error load setting!");
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save file not found");
            }
        }

        private void WayAndText()
        {
            WayAndKey = new Control[]
            {
                AutoLoading, NewSource_way, NewOne_way, NewTwo_way,
                NewThree_way, NewFour_way, NewCulling_way, NewKey_One,
                NewKey_Two, NewKey_Three, NewKey_Four, English, Russian, Ukrainian, Default, Advanced
            };
        }

        private void ResetSetting_Click(object sender, EventArgs e)
        {
            try
            {
                WayAndText();
                for (byte i = 1; i < WayAndKey.Length - 4; i++)
                {
                    Progress.Value = 0;
                    try
                    {
                        WayAndKey[i].Text = "";
                    }
                    catch (Exception)
                    {

                    }
                }
                CopyOnce1.Checked = true;
                CopyOnce2.Checked = true;
                CopyOnce3.Checked = true;
                CopyOnce4.Checked = true;
                CopyOnceDefault.Checked = true;
            }
            catch (Exception)
            {

            }
        }

        private void BTNinfo_Click(object sender, EventArgs e)
        {
            if (InfoRichTextBox.Visible)
            {
                InfoRichTextBox.Visible = false;
            }
            else
            {
                InfoRichTextBox.Visible = true;
            }
        }

        private void ControlArry()
        {
            KeyWord = new Control[]
            {
                NewKey_One,
                NewKey_Two,
                NewKey_Three,
                NewKey_Four
            };
            Way = new Control[]
            {
                NewOne_way,
                NewTwo_way,
                NewThree_way,
                NewFour_way
            };
        }

        private void BTNClear1_Click(object sender, EventArgs e)
        {
            ControlArry();
            for (int i = 0; i < Way.Length; i++)
            {
                Way[i].Text = "";
            }
        }

        private void BTNClear2_Click(object sender, EventArgs e)
        {
            ControlArry();
            for (int i = 0; i < KeyWord.Length; i++)
            {
                KeyWord[i].Text = "";
            }
        }

        private void Clone1_Click(object sender, EventArgs e)
        {
            ControlArry();
            if (Way[0].Text != "")
            {
                for (int i = 1; i < Way.Length; i++)
                {
                    Way[i].Text = Way[0].Text;
                }
            }
            else
            {
                string clone = "";
                for (int i = 0; i < Way.Length; i++)
                {
                    if(Way[i].Text != "")
                    {
                        clone = Way[i].Text;
                    }
                }
                for (int i = 0; i < Way.Length; i++)
                {
                    Way[i].Text = clone;
                }
            }
        }

        private void Clone2_Click(object sender, EventArgs e)
        {
            ControlArry();
            if (KeyWord[0].Text != "")
            {
                for (int i = 1; i < KeyWord.Length; i++)
                {
                    KeyWord[i].Text = KeyWord[0].Text;
                }
            }
            else
            {
                string clone = "";
                for (int i = 0; i < KeyWord.Length; i++)
                {
                    if (KeyWord[i].Text != "")
                    {
                        clone = KeyWord[i].Text;
                    }
                }
                for (int i = 0; i < KeyWord.Length; i++)
                {
                    KeyWord[i].Text = clone;
                }
            }
        }

        private void AnotherTestCheck(object sender, EventArgs e)//ненужная хрень
        {
            DeleteModTumbler1.Enabled = AnotherTest1.Checked;
            DeleteModTumbler2.Enabled = AnotherTest2.Checked;
            DeleteModTumbler3.Enabled = AnotherTest3.Checked;
            DeleteModTumbler4.Enabled = AnotherTest4.Checked;
            if (!DeleteModTumbler1.Enabled) { DeleteModTumbler1.Checked = false; }
            if (!DeleteModTumbler2.Enabled) { DeleteModTumbler2.Checked = false; }
            if (!DeleteModTumbler3.Enabled) { DeleteModTumbler3.Checked = false; }
            if (!DeleteModTumbler4.Enabled) { DeleteModTumbler4.Checked = false; }
        }

        private void AnotherTestDelault(object sender, EventArgs e)
        {
            DeleteAfterTestDefault.Enabled = AnotherTestDefault.Checked;
            if(!DeleteAfterTestDefault.Enabled) { DeleteAfterTestDefault.Checked = false; }
        }

        private void AutoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoCheck.Checked)
            {
                Notifications.Enabled = false;
                Progress.Enabled = false;
                Progress.Value = 0;
                if (Notifications.Checked) { Helper = true; Notifications.Checked = false; }
                else
                    Helper = false; Notifications.Checked = false;
            }
            else
            {
                Notifications.Enabled = true;
                Progress.Enabled = true;
                if (Helper == true) { Notifications.Checked = true; };
            }
        }

        private void CullingCheck_CheckedChanged(object sender, EventArgs e)
        {
            NewCulling_way.Enabled = cullingCheck.Checked;
            CullingFolder.Enabled = cullingCheck.Checked;
            DeleteCulling.Enabled = cullingCheck.Checked;
        }

        private void CullingFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                NewCulling_way.Text = SOURCE.SelectedPath;
                culling_way = SOURCE.SelectedPath;
            }
        }

        private void NewCulling_way_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Apply.Enabled = true;
                culling_way = NewCulling_way.Text;
            }
            catch (ArgumentException)
            {
                Apply.Enabled = false;
            }
        }

        private void helpInfoToolStripMenuItem_Click(object sender, EventArgs e)//Сделать
        {
            if (English.Checked)   { MessageBox.Show("The Collection module is at the development stage, for the program to work correctly, at least 4gb RAM \n Possible errors if RAM size low! \n Correcting the consumption of computer resources is not optimized due to the lack of statistics \n Higher request to send the results of the program to the email specified in info \n P.s. When setting the limit of RAM, do not exceed half of the total amount of your RAM"); }
            if (Russian.Checked)   { MessageBox.Show("Модуль Коллекция на стадии разработки, для корректной работы программы необходимо минимум 4gb ОЗУ\nПри меньшем объеме возможны ошибки! \nКорректирование потребление ресурсов компьютера не оптимизированно из-за недостатка статистики \nОгромная просьба присылать результаты работы программы на email указанный в info \nP.s. При установке лимита ОЗУ не превышайте половину от общего объема вашей ОЗУ"); }
            if (Ukrainian.Checked) { MessageBox.Show("Модуль Колекцiя на стадії розробки, для коректної роботи програми необхідно мінімум 4gb ОЗУ \n Прі меншому обсязі можливі помилки! \n Корректірованіе споживання ресурсів комп'ютера не оптимізовані через нестачу статистики \n Огромная прохання надсилати результати роботи програми на email вказаний в info \n P.s. При установці ліміту ОЗУ не перевищуйте половину від загального обсягу вашої ОЗУ"); }
        }

        private void MultiP(object sender, EventArgs e)
        {
            bool Mp = MultiScanPanel.Visible == true ? false : true;
            MultiScanPanel.Visible = Mp;            
            MultiScanPanel.BringToFront(); //Убрать заглушку после работы с панелями //Что это за заглушка?
            Apply.Enabled = !Mp;
            Stop.Enabled = !Mp;
            ModePanel2.Visible = !Mp;
            //Source.Visible = !Mp;
            Advanced.Checked = true;
        }

        //public static Bitmap LoadBitmap(string path)
        //{
        //    //Открыть файл в режиме только для чтения
        //    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    //Получить двоичный считыватель для потока файлов
        //    using (BinaryReader reader = new BinaryReader(stream))
        //    {
        //        //скопировать содержимое файла в поток памяти
        //        var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
        //        //сделать новый объект Bitmap владельцем MemoryStream
        //        return new Bitmap(memoryStream);
        //    }
        //}

        private void CollectionStartScan(object sender, EventArgs e)
        {
            ClearBTNimage.Enabled = false;
            String UserName = Environment.UserName;
            TotalUseMem = 0;
            ImageStop = false;
            KeyWordScan = KeyWordCatalog.Text.Split(',');
            string wayToFile = @"";
            if (KeyWordScan != null && KeyWordScan[0] != "")
            {
                try
                {
                    string[] ArryInfoFile = new string[] { };
                    try
                    {
                        ArryInfoFile = File.ReadAllLines(@"C:\Users\" + UserName + @"\AppData\Local\MagicCopy\ImageTag.json");
                    }
                    catch (Exception)
                    {
                        File.Create(@"C:\Users\" + UserName + @"\AppData\Local\MagicCopy\ImageTag.json");
                    }
                    exitLoop = false;
                    for (int i = 1; i < ArryInfoFile.Length; i++)
                    {
                        if (exitLoop) break;
                        ImageCollection newImageTag = JsonConvert.DeserializeObject<ImageCollection>(ArryInfoFile[i]);
                        foreach (var info in newImageTag.ImageTags)
                        {
                            if (exitLoop) break;
                            if (KeyWordScan[0] != "Click" || KeyWordScan[i] == info.TAG || KeyWordScan[i] == info.ID)
                            {
                                bool SUCCESS = true;
                                for (int d = 0; d < KeyWordScan.Length; d++)
                                {
                                    if (exitLoop) break;
                                    //string RemoveTrashSymbol = info.TAG.ToLower();
                                    //Remove_Trash(RemoveTrashSymbol, out RemoveTrashSymbol);
                                    int IndexKey = KeyWordScan[d].IndexOf(NO); //Exeption tag
                                    string KeyString = KeyWordScan[d].Remove(0, 1); //Check exeption tag
                                    bool HasMinus = IndexKey == 0 ? true : false;
                                    if (HasMinus && info.TAG.IndexOf(KeyString) != -1 || HasMinus && info.ID.IndexOf(KeyString) != -1)
                                    {
                                        SUCCESS = false;
                                        break;
                                    }
                                    if (info.TAG.IndexOf(KeyWordScan[d]) == -1 && !HasMinus && info.ID.IndexOf(KeyWordScan[d]) == -1 && !HasMinus) { SUCCESS = false; break; }
                                    else{ wayToFile = info.WAY; }                                    
                                }
                                if (SUCCESS)
                                {
                                    if (TotalUseMem > UserLimitMemory)
                                    {
                                        CallClear();
                                        MessageBox.Show("Memory end");
                                        TotalUseMem = 0;
                                        break;
                                    }
                                    if (HMaxLocalImageWindow == 7) { y += 105; HMaxLocalImageWindow = 0; x = 0; FirstImageWindow = true; }
                                    //создание
                                    PicBox = new PictureBox();
                                    try
                                    {
                                        PicBox.Image = Image.FromFile(wayToFile);
                                        PicBox.SizeMode = PictureBoxSizeMode.Zoom;
                                        PicBox.Name = wayToFile;
                                        PicBox.Tag = info.ID; //Тэг файла
                                        this.PicBox.Click += new EventHandler(TegEditMethod);
                                        this.PicBox.DoubleClick += new EventHandler(FullScrean);
                                        if (FirstImageWindow) { PicBox.Left = 1; FirstImageWindow = false; HMaxLocalImageWindow++; }
                                        else { x += 105; PicBox.Left = x; HMaxLocalImageWindow++; }
                                        PicBox.Top = 10 + y;
                                        PicBox.Height = 100;
                                        PicBox.Width = 100;
                                        PicBox.Visible = true;

                                        Image.FromFile(wayToFile).Dispose();
                                    }
                                    catch
                                    {

                                    }

                                    Invoke((MethodInvoker)delegate
                                    {
                                        //размещаем на панели
                                        ResultPanel.Controls.Add(PicBox);
                                        linkLabel2.Text = "Total loading arts: " + Convert.ToString(TotalPic++);
                                        //добавляем в коллекцию 
                                        pictureBox.Add(PicBox);
                                        TotalUseMem = GC.GetTotalMemory(true) / 2048; //2.8f;
                                        linkLabel1.Text = "Total uing memory: " + TotalUseMem.ToString();
                                    });

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
                //FoundFileInJson(KeyWordScan, out string[] result);
                //DebugImageCheck(); //Вызывает загрузку артов в imagebox


            }
            else
            {
                try
                {
                    //MessageBox.Show(UserLimit.ToString());
                    ImageWorker.RunWorkerAsync();
                    DebugBTN.Enabled = false;
                    ResultPanel.AutoScroll = false;
                }
                catch (Exception)
                {
                }
            }
        }
        private void DebugImageCheck()
        {
            //if (source_wayPanel == "")
            //{
            //    //GetSetFileTag();
            //}
            try
            {
                //LoadBitmap(source_wayPanel);
                //Random rnd = new Random();
                //DebugBTN.Enabled = false;
                //ResultPanel.AutoScroll = false;
                DirectoryInfo FileInfo = new DirectoryInfo(source_way);
                FileInfo[] Files = FileInfo.GetFiles("*");
                foreach (FileInfo file in Files)
                {
                    if (TotalUseMem > UserLimitMemory || ImageStop)
                    {
                        CallClear();
                        if (!ImageStop) { MessageBox.Show("Memory end"); }
                        TotalUseMem = 0;
                        break;
                    }
                    try
                    {
                        if (HMaxLocalImageWindow == 7) { y += 105; HMaxLocalImageWindow = 0; x = 0; FirstImageWindow = true; }
                        //создание
                        PicBox = new PictureBox();

                        try
                        {
                            string imageWay = Path.Combine(source_way, file.Name);
                            PicBox.Image = Image.FromFile(imageWay);
                            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
                            PicBox.Name = imageWay;
                            PicBox.Tag = file.Name; //ID файла
                            this.PicBox.Click += new EventHandler(TegEditMethod);
                            this.PicBox.DoubleClick += new EventHandler(FullScrean);
                            if (FirstImageWindow) { PicBox.Left = 1; FirstImageWindow = false; HMaxLocalImageWindow++; }
                            else { x += 105; PicBox.Left = x; HMaxLocalImageWindow++; }
                            PicBox.Top = 10 + y;
                            PicBox.Height = 100;
                            PicBox.Width = 100;
                            PicBox.Visible = true;

                            Image.FromFile(imageWay).Dispose();
                        }
                        catch
                        {

                        }


                        Invoke((MethodInvoker)delegate 
                        {
                            //размещаем на панели
                            ResultPanel.Controls.Add(PicBox);
                            linkLabel2.Text = "Total loading arts: " + Convert.ToString(TotalPic ++);
                            //добавляем в коллекцию 
                            pictureBox.Add(PicBox);
                            TotalUseMem = GC.GetTotalMemory(true) / 1000; 
                            linkLabel1.Text = "Total uing memory: " + TotalUseMem.ToString();
                        });
                     

                        //очистка
                        id++;
                        CallClear();
                        //PicBox.Image.Dispose();
                        k++;
                    }
                    catch (Exception ex)
                    {
                        //PicBox.ErrorImage 
                        MessageBox.Show(Convert.ToString(ex.Message));
                    }
                }
                ImageWorker.CancelAsync();
                Invoke((MethodInvoker)delegate
                {
                    ResultPanel.AutoScroll = true;
                    DebugBTN.Enabled = true;
                    ClearBTNimage.Enabled = true;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                ImageWorker.CancelAsync();
                Invoke((MethodInvoker)delegate
                {
                    ResultPanel.AutoScroll = true;
                    DebugBTN.Enabled = true;
                    ClearBTNimage.Enabled = true;
                });
            }
        }

        private void ClearBTNimage_Click(object sender, EventArgs e)
        {
            try
            {
                PicBox.Left = 1; FirstImageWindow = false; HMaxLocalImageWindow++;
                ResultPanel.Controls.Clear();
                pictureBox.Clear();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                TotalUseMem = 0;
                TotalPic = 0;
                linkLabel1.Text = "Total uing memory: 0";
                linkLabel2.Text = "Total loading arts: 0";
                TagFiles.Text = "";
                MegaLinkEdit.Text = "";
                x = 0;
                y = 0;
                k = 0;
                TotalUseMem = UserLimitMemory * 22;
            }
            catch
            {

            }
        }

        private void TegEditMethod(object sender, EventArgs e)
        {
            /*PictureBox clickedPicBox = sender as PictureBox;
            ArtistEdit.Text = Convert.ToString(clickedPicBox.Tag);*///call tag
            PictureBox clickedPicBox = sender as PictureBox;
            clickedPicBox.BorderStyle = BorderStyle.Fixed3D;
            GetSetFileTag(Convert.ToString(clickedPicBox.Name), Convert.ToString(clickedPicBox.Tag));
            //JsonTest(Convert.ToString(clickedPicBox.Tag));
        }
        private void FullScrean(object sender, EventArgs e) //Full screan
        {
            Size resolution = Screen.PrimaryScreen.Bounds.Size;
            PictureBox clickedPicBox = sender as PictureBox;
            //MessageBox.Show(e.ToString());
            System.Diagnostics.Process.Start("explorer", Convert.ToString(clickedPicBox.Name));
            //clickedPicBox.Size = Screen.PrimaryScreen.Bounds.Size;
        }

        private void GetSetFileTag(string way, string info)
        {
            string[] Get = new string[1] {"no" };
            string ways = way;
            string Info = "";
            string ArtID = Regex.Replace(info, @"[^0-9].*", ""); //info.Remove(info.IndexOf('_'));
            string RemoveID = Regex.Replace(info, @"^(?<id>\d+)", "");
            Remove_Trash(info, out Info);
            string tag = ways.Remove(ways.IndexOf('.'));
            //string FoundTags;
            FileDataBase myCollection = new FileDataBase();
            myCollection.FileTags = new FilesTag[1];
            ID = ArtID;
            SelectFileWay = ways;
            LoadJsonSaveTag();

            //FoundTags = TagFiles.Text.Split(',');

            //ReadAndAddTagFilesInCollection(ArtID, RemoveID, way, out FoundTags);

            //TagFiles.Text = FoundTags;

            myCollection.FileTags[0] = new FilesTag()
            {                
                //Artist = Info,
                //Tags = Info,
                //TimeCreate = Convert.ToString(File.GetCreationTime(ways)),
                MegaLink = ArtID.Length == 0 ? ArtID = "Can't get ID file" : "https://derpibooru.org/" + ArtID,
                //ImageWay = ways
            };

            foreach (var files in myCollection.FileTags)
            {
                //TagFiles.Text = files.Artist;
                //TagFiles.Text += files.Tags;
                //TagFiles.Text += files.TimeCreate;
                MegaLinkEdit.Text = files.MegaLink;
                //ImageWayBox.Text = files.ImageWay;
            }
        }


        private string Remove_Trash(string fileName, out string RemoveTrash)
        {
            RemoveTrash = fileName.Replace('+', ' ').Replace('_', ' ').Replace('-', ' ');
            return RemoveTrash;
        }

        private void DeleteModTumbler_CheckedChanged(object sender, EventArgs e)
        {
            AnotherTest1.Enabled = DeleteModTumbler1.Checked;
            AnotherTest2.Enabled = DeleteModTumbler2.Checked;
            AnotherTest3.Enabled = DeleteModTumbler3.Checked;
            AnotherTest4.Enabled = DeleteModTumbler4.Checked;
            if (!DeleteModTumbler1.Checked) { CopyOnce1.Checked = true; }
            if (!DeleteModTumbler2.Checked) { CopyOnce2.Checked = true; }
            if (!DeleteModTumbler3.Checked) { CopyOnce3.Checked = true; }
            if (!DeleteModTumbler4.Checked) { CopyOnce4.Checked = true; }
        }

        private void debugMode(object sender, EventArgs e)
        {
            bool DB = DebugMod.Checked == false ? true : false;
            DebugMod.Checked = DB;
            AppearanceCatalogeSelect.Visible = DB;
            debugOptionsToolStripMenuItem.Visible = DB;
        }

        private void STOPbtn_Click(object sender, EventArgs e)
        {
            DebugImageCheck();
        }

        private void UserLimit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UserLimitMemory = Convert.ToInt32(UserLimit.Text);
                if (Convert.ToInt32(UserLimit.Text) > 8096)
                {
                    MessageBox.Show("WARNING! You have exaggerated the maximum permissible value of memory! If you have less than 16gb ram installed on your computer it breaks the program");
                }
                if (Convert.ToInt32(UserLimit.Text) <= 0)
                {
                    UserLimit.Text = "512";
                    UserLimitMemory = Convert.ToInt32(UserLimit.Text);
                };
            }
            catch (Exception)
            {
                UserLimit.ForeColor = Color.Red;
                UserLimit.Text = "1024";
            }
        }

        private void CallClear ()
        {
            GC.Collect(1, GCCollectionMode.Forced);
            GC.AddMemoryPressure(1);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        //private string ReadAndAddTagFilesInCollection(string RawID, string RawTag, string WayFile, out string FoundID)
        //{
        //    int i = 0;
        //    string FileTag = "";
        //    string VOID = "";
        //    CathErrorReadTag();
        //    string[] ReadTagFiles = File.ReadAllLines(WayCataloge, Encoding.UTF8);

        //    MessageBox.Show(WayFile);

        //    //if (ReadTagFiles.Length == 0) { SaveTagInFile(RawID, RawTag, WayFile); }
          
        //    while(i < ReadTagFiles.Length)
        //    {               
        //        if (RawID == Regex.Replace(ReadTagFiles[i], @"[^0-9].*", ""))
        //        {
        //            File.ReadAllLines(WayCataloge, Encoding.UTF8);
        //            FileTag = Regex.Replace(ReadTagFiles[i], @"^(?<id>\d+)", ""); //Remove ID
        //            LoadingTagOutFile(i, RawID);
        //            //MessageBox.Show("Нашло");
        //            FoundID = FileTag;
        //            return FoundID;
        //        }

        //        if (i == ReadTagFiles.Length -1 && RawID != Regex.Replace(ReadTagFiles[i], @"[^0-9].*", ""))
        //        {
        //            MessageBox.Show("Noting, create new info");
        //            //SaveTagInFile(RawID, VOID, WayFile);
        //            FoundID = VOID;
        //            return FoundID;
        //        }
        //        i++;
        //    }
        //    FoundID = VOID;
        //    return VOID;
        //}

        private void LoadingTagOutFile(int i, string RawID)
        {
            string TagFile = "";
            string[] ReadTagFiles = File.ReadAllLines(WayCataloge, Encoding.UTF8);
            TagFile = Regex.Replace(ReadTagFiles[i], @"^(?<id>\d+)", "");
            //ClickArts = i;
            //ClickArtsID = RawID;
            //MessageBox.Show("TAG found! This is: " + TagFile);
            //SaveTagInFile(RawID, TagFile, WayCataloge);
        }

        //private void SaveTagInFile(string RawID, string RawTag, string WayFile)// Not found
        //{
        //    ImageTag imageTag = new ImageTag();
        //    imageTag.savetags(RawID, RawTag, WayFile);
        //    imageTag.loadingtag();
        //    StreamWriter writer = new StreamWriter(WayCataloge, true);
        //    writer.WriteLine(RawID + " TAG: " + RawTag + " WAY: " + WayFile);
        //    writer.Close();
        //}

        private void CathErrorReadTag()
        {
            try
            {
                File.ReadAllLines(WayCataloge);
            }
            catch (Exception)
            {
                StreamWriter writer = new StreamWriter(WayCataloge, true);
                writer.Close();
            }
        }

        private void UnlockTagEdit_Click(object sender, EventArgs e)
        {
            UnlockLockTagsEdit();
        }

        private void CancelAndResetTags(object sender, EventArgs e)
        {
            UnlockLockTagsEdit();
            //LoadingTagOutFile(ClickArts, ClickArtsID);
        }

        private void UnlockLockTagsEdit()
        {
            LoadJsonSaveTag();
            TagFiles.ReadOnly = TagFiles.ReadOnly ? TagFiles.ReadOnly = false : TagFiles.ReadOnly = true;
            SaveTags.Enabled = !TagFiles.ReadOnly;
            CancelTagsEdit.Enabled = !TagFiles.ReadOnly;
        }

        private void LoadJsonSaveTag()
        {
            ImageTagLoad imageTagLoad = new ImageTagLoad();
            imageTagLoad.loadingtag(ID, SelectFileWay, out string Tag, out string IDs/*, HOLE, out HOLE*/);
            if (Tag == "Fail" || Tag == "") { TagFiles.Text = ""; }
            else { TagFiles.Text = Tag; MegaLinkEdit.Text = "https://derpibooru.org/" + IDs; }
        }

        private void FoundFileInJson(string[] scan, out string [] WAYs)
        {
            ImageTagLoad imageTagLoad = new ImageTagLoad();
            imageTagLoad.loadingtag("", "", out string Tag, out string IDs/*, scan, out scan*/);
            WAYs = scan;
        }

        private void SaveTags_Click(object sender, EventArgs e)
        {
            ImageTag imageTag = new ImageTag();
            imageTag.savetags(ID, TagFiles.Text.ToLower(), SelectFileWay);
        }

        private void debugClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageTag imageTag = new ImageTag();
            //imageTag.loadingtag();
        }

        private void openWayFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\" + Environment.UserName + @"\AppData\Local\MagicCopy\");
        }

        private void openDirectoryProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath);
        }

        private void ExitScanBTN_Click(object sender, EventArgs e)
        {
            exitLoop = true;
            ImageWorker.CancelAsync();
        }
    }
}