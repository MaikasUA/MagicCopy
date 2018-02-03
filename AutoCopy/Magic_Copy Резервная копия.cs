using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace MagicCopy
{
    public partial class Magic_Copy : Form
    {
        BackgroundWorker Worker;
        FileSystemWatcher Watcher;
        string WaySave = @"TestSave.sav";
        string source_way = @""; 
        string one_way = @"";
        string two_way = @"";
        string three_way = @"";
        string four_way = @"";

        string HelpEnd = "Where to move. Example D:\\Video\\MP4";

        string Key0 = ""; //Key word 1
        string Key1 = ""; //Key word 2
        string Key2 = ""; //Key word 3
        string Key3 = ""; //Key word 4

        bool EndScan = false;

        Control[] WayAndKey;
        Control[] Way;
        Control[] KeyWord;
        //bool[] Another;
        bool[] AnotherDel;
        //bool[] AnotherDelEnable;

        public Magic_Copy()
        {
            InitializeComponent();
            SettingMod();
            CopyOnceDefault.Checked = true;
            Worker = new BackgroundWorker();
            Worker.DoWork += FuckingWorker;
            Worker.ProgressChanged += ProgressChanged;
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;

            Watcher = new FileSystemWatcher();
            Watcher.Path = source_way;
            Watcher.SynchronizingObject = this;
            Watcher.Filter = "*";
            Watcher.Created += new FileSystemEventHandler(OnChanged);

            ModePanel.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void MagicCopy_Load(object sender, EventArgs e)
        {
            try
            {
                CheckingFileSave();
            }
            catch(Exception)
            {

            }
        }

        private void Source_way_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (EndScan)
                {
                    Progress.Value = 0;
                }
                Apply.Enabled = true;
                //AutoCheck.Enabled = true;
                source_way = Source_way.Text;
                Watcher.Path = source_way;
                Watcher.EnableRaisingEvents = true;
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
                source_way = SOURCE.SelectedPath;
                Source_way.Text = SOURCE.SelectedPath;
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
            two_way = Two_way.Text;
        }

        private void Tow_Click(object sender, EventArgs e) //Way for key word 2
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                Two_way.Text = SOURCE.SelectedPath;
                two_way = SOURCE.SelectedPath;
            }
        }

        private void Three_way_TextChanged(object sender, EventArgs e) //three way
        {
            three_way = Three_way.Text;
        }

        private void Three_Click(object sender, EventArgs e) //Way for key word 3
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                Three_way.Text = SOURCE.SelectedPath;
                three_way = SOURCE.SelectedPath;
            }
        }

        private void Four_way_TextChanged(object sender, EventArgs e) //four way
        {
            four_way = Four_way.Text;
        }

        private void Four_Click(object sender, EventArgs e) //Way for key word 4
        {
            FolderBrowserDialog SOURCE = new FolderBrowserDialog();

            if (SOURCE.ShowDialog() == DialogResult.OK)
            {
                Four_way.Text = SOURCE.SelectedPath;
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

        private void Apply_Click(object sender, EventArgs e)
        {
            //FilesValue();
            try
            {
                Worker.RunWorkerAsync();
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
            }
            catch (Exception)
            {

            }
        }

        private void CopyFiles() 
        {
            //What.Text = "";
            Key0 = Key_One.Text;
            Key1 = Key_Two.Text;
            Key2 = Key_Three.Text;
            Key3 = Key_Four.Text;

            if (source_way != "") //Checking all way and key word on null and void
            {
                byte i = 0;
                if (one_way == "" || Key0 == "") { i++; }
                if (two_way == "" || Key1 == "") { i++; }
                if (three_way == "" || Key2 == "") { i++; }
                if (four_way == "" || Key2 == "") { i++; }
                if (i == 4)
                {
                    MessageBox.Show("All way or key word is empty!\nOr error way.");
                    return;
                }
                else
                {
                    Key0 = Key0.ToLower();
                    Key1 = Key1.ToLower();
                    Key2 = Key2.ToLower();
                    Key3 = Key3.ToLower();
                }
            }

            string[] WAY = new string[4];
            {
                WAY[0] = one_way;
                WAY[1] = two_way;
                WAY[2] = three_way;
                WAY[3] = four_way;
            }

            if (source_way.Length < 3) { MessageBox.Show("Error source way!"); return; }

            DirectoryInfo FileInfo = new DirectoryInfo(source_way); //Assuming Test is your Folder

            if (!FileInfo.Exists) { MessageBox.Show("Error way!"); return; }

            FileInfo[] Files = FileInfo.GetFiles("*"); //Getting Text files

            for (byte i = 0; i < WAY.Length; i++)
            {
                if (WAY[i] == source_way)
                {
                    MessageBox.Show("Error way");
                    return;
                }
            }

            //Progress.Maximum = Files.Length; //Progress bar
            //Worker.ReportProgress(-1, Files.Length);
            int Value = 0;
            EndScan = false;
            try
            {
                if (one_way.Length >= 3) { DirectoryInfo di1 = Directory.Exists(one_way) ? new DirectoryInfo(one_way) : Directory.CreateDirectory(one_way); }
                if (two_way.Length >= 3) { DirectoryInfo di2 = Directory.Exists(two_way) ? new DirectoryInfo(two_way) : Directory.CreateDirectory(two_way); }
                if (three_way.Length >= 3) { DirectoryInfo di3 = Directory.Exists(three_way) ? new DirectoryInfo(three_way) : Directory.CreateDirectory(three_way); }
                if (four_way.Length >= 3) { DirectoryInfo di4 = Directory.Exists(four_way) ? new DirectoryInfo(four_way) : Directory.CreateDirectory(four_way); }
            }
            catch (Exception)
            {
                MessageBox.Show("Error way!");
            }
            byte[] KEYS = new byte[4];

            foreach (FileInfo file in Files) //Copy file
            {
                if (Worker.CancellationPending)
                {
                    return;
                }
                string FN = file.Name.ToLower();

                string[] KEY = new string[4];

                if (FN.IndexOf(Key0) != -1) { KEY[0] = Key0; }
                if (FN.IndexOf(Key1) != -1) { KEY[1] = Key1; }
                if (FN.IndexOf(Key2) != -1) { KEY[2] = Key2; }
                if (FN.IndexOf(Key3) != -1) { KEY[3] = Key3; }

                try
                {
                    Worker.ReportProgress(++Value, -1);

                    if (Key0 != "" && FN.IndexOf(Key0) != -1 || KEYS[0] == 1) //Scanning files in the source folder for matches
                    {
                        string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                        string destFile = Path.Combine(one_way, file.Name); //Set the path for copying a file
                        File.Copy(sourceFile, destFile, true); //Copy file
                        if (AnotherTestDefault.Checked)
                        {
                            KEYS[0] = 2;
                            NewChecked(FN, KEYS, KEY);
                        }

                        if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }

                        if (Advanced.Checked) //Checking Advanced setting
                        {
                            if (DeleteOriginal1.Checked) { File.Delete(sourceFile); }

                            if (AnotherTest1.Checked)
                            {
                                KEYS[0] = 2;
                                NewChecked(FN, KEYS, KEY);
                            }
                        }
                    }
                    if (Key1 != "" && FN.IndexOf(Key1) != -1 || KEYS[1] == 1) //Scanning files in the source folder for matches
                    {
                        string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                        string destFile = Path.Combine(two_way, file.Name); //Set the path for copying a file

                        File.Copy(sourceFile, destFile, true); //Copy file
                        if (AnotherTestDefault.Checked)
                        {
                            KEYS[1] = 2;
                            NewChecked(FN, KEYS, KEY);
                        }

                        if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }

                        if (Advanced.Checked) //Checking Advanced setting
                        {
                            if (DeleteOriginal2.Checked) { File.Delete(sourceFile); }

                            if (AnotherTest2.Checked)
                            {
                                KEYS[1] = 2;
                                NewChecked(FN, KEYS, KEY);
                            }
                        }
                    }
                    if (Key2 != "" && FN.IndexOf(Key2) != -1 || KEYS[2] == 1) //Scanning files in the source folder for matches
                    {
                        string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                        string destFile = Path.Combine(three_way, file.Name); //Set the path for copying a file
                        File.Copy(sourceFile, destFile, true); //Copy file
                        if (AnotherTestDefault.Checked)
                        {
                            KEYS[2] = 2;
                            NewChecked(FN, KEYS, KEY);
                        }

                        if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }

                        if (Advanced.Checked) //Checking Advanced setting
                        {
                            if (DeleteOriginal3.Checked) { File.Delete(sourceFile); }

                            if (AnotherTest3.Checked)
                            {
                                KEYS[2] = 2;
                                NewChecked(FN, KEYS, KEY);
                            }
                        }
                    }
                    if (Key3 != "" && FN.IndexOf(Key3) != -1 || KEYS[3] == 1) //Scanning files in the source folder for matches
                    {
                        string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                        string destFile = Path.Combine(four_way, file.Name); //Set the path for copying a file
                        File.Copy(sourceFile, destFile, true); //Copy file

                        if (AnotherTestDefault.Checked)
                        {
                            KEYS[3] = 2;
                            NewChecked(FN, KEYS, KEY);
                        }

                        if (DeleteOriginalFile.Checked) { File.Delete(sourceFile); }

                        if (Advanced.Checked) //Checking Advanced setting
                        {
                            if (DeleteOriginal4.Checked) { File.Delete(sourceFile); }

                            if (AnotherTest4.Checked)
                            {
                                KEYS[3] = 2;
                                NewChecked(FN, KEYS, KEY);
                            }
                        }
                    }
                    AnotherDel = new bool[]
                    {
                            DeleteAfterTest1.Checked,
                            DeleteAfterTest2.Checked,
                            DeleteAfterTest3.Checked,
                            DeleteAfterTest4.Checked,
                    };
                    for (int i = 0; i < 4; i++)
                    {
                        if (KEYS[i] == 2 && Advanced.Checked && AnotherDel[i])
                        {
                            string sourceFile = Path.Combine(source_way, file.Name);

                            File.Delete(sourceFile);
                        }
                        if (KEYS[i] == 2 && Default.Checked && DeleteAfterTestDefault.Checked)
                        {
                            string sourceFile = Path.Combine(source_way, file.Name);

                            File.Delete(sourceFile);
                            i = 4;
                        }
                    }
                    KEYS[0] = 0;
                    KEYS[1] = 0;
                    KEYS[2] = 0;
                    KEYS[3] = 0;
                }
                catch (Exception) //Catching errors
                {
                    //MessageBox.Show("Not found");
                }
            }
            if (Notifications.Checked && !AutoCheck.Checked)
            {
                MessageBox.Show("Done! \nTotal files: {0}", Progress.Value.ToString());
            }
            EndScan = true;
            //Progress.Value = 0;
            //What.Text = "Copy over";
            //if (Progress.InvokeRequired)
            //{
            //    Progress.Value = (int) e.ProgressPercentage;
            //}
            //else
            //{
            //    Progress.Value = 0;
            //}
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

        private void FilesValue()
        {
            if (!AutoCheck.Checked)
            {
                try
                {
                    DirectoryInfo Dinfo = new DirectoryInfo(@source_way);
                    FileInfo[] files = Dinfo.GetFiles("*");
                    if (files.Length == 0)
                    {
                        MessageBox.Show("No files");
                    }
                    return;
                }
                catch (Exception)
                {

                }
            }            
        }

        private void Close_Click(object sender, EventArgs e) //Close program
        {
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
        }

        private void SettingMod()
        {
            if (!Advanced.Checked) //Default Mod
            {
                this.MaximumSize = new Size(778, 454);
                this.MinimumSize = MaximumSize;
                this.Source.ClientSize = new Size(182, 20);
                this.Source.Location = new Point(572, 36);
                this.Source_way.ClientSize = new Size(551, 20);
                this.AdvancedDeletePanel.Visible = false;
                this.Language.Location = new Point(11, 145);
                this.BTNinfo.Location = new Point(11, 220);
                this.InfoRichTextBox.Location = new Point(200, 145);
                this.ModePanel.Visible = false;
            }
            else //Advanced Mod
            {
                this.MaximumSize = new Size(994, 560);
                this.MinimumSize = MaximumSize;
                this.Source.ClientSize = new Size(206, 20);
                this.Source.Location = new Point(760, 34);
                this.Source_way.ClientSize = new Size(738, 20);
                this.AdvancedDeletePanel.Visible = true;
                this.Language.Location = new Point(11, 246);
                this.BTNinfo.Location = new Point(11, 324);
                this.InfoRichTextBox.Location = new Point(200, 246);
                this.ModePanel.Visible = true;
            }
        }

        private void Stop_Click(object sender, EventArgs e) //Stop copy
        {
            Worker.CancelAsync();
            Progress.Value = 0;
        } 

        private void English_CheckedChanged(object sender, EventArgs e) //English Localization
        {
            Advanced.Text = "Advanced";
            One.Text = "Folder one";
            Two.Text = "Folder two";
            Three.Text = "Folder three";
            Four.Text = "Folder four";
            DeleteOriginal1.Text = "Delete after copying";
            DeleteOriginal2.Text = "Delete after copying";
            DeleteOriginal3.Text = "Delete after copying";
            DeleteOriginal4.Text = "Delete after copying";
            AnotherTest1.Text = "Another test";
            AnotherTest2.Text = "Another test";
            AnotherTest3.Text = "Another test";
            AnotherTest4.Text = "Another test";
            CopyOnce1.Text = "Copy once";
            CopyOnce2.Text = "Copy once";
            CopyOnce3.Text = "Copy once";
            CopyOnce4.Text = "Copy once";
            Default.Text = "Default";
            AnotherTestDefault.Text = "Another Test";
            DeleteOriginalFile.Text = "Delete all original file";
            CopyOnceDefault.Text = "Copy (1 file to 1 folder)";
            Source.Text = "Source folder";
            Apply.Text = "Start";
            Stop.Text = "Stop";
            Close.Text = "Close";
            ResetSetting.Text = "Reset";
            SaveSetting.Text = "Save";
            LoadingSetting.Text = "Loading";
            AutoLoading.Text = "Auto loading setting";
            AutoCheck.Text = "Automatic tracking";
            BTNinfo.Text = "Info";
            DeleteAfterTest1.Text = "Delete original";
            DeleteAfterTest2.Text = "Delete original";
            DeleteAfterTest3.Text = "Delete original";
            DeleteAfterTest4.Text = "Delete original";
            Clone1.Text = "Clone";
            Clone1.Text = "Clone";
            BTNClear1.Text = "Clear";
            BTNClear2.Text = "Clear";
            Notifications.Text = "Show notifications";
            DeleteAfterTestDefault.Text = "Delete after test";
        }

        private void Russian_CheckedChanged(object sender, EventArgs e) //Russian Localization
        {
            Advanced.Text = "Расширенные";
            One.Text = "Первая папка";
            Two.Text = "Вторая папка";
            Three.Text = "Третья папка";
            Four.Text = "Четвертая папка";
            DeleteOriginal1.Text = "Удалить после копирования";
            DeleteOriginal2.Text = "Удалить после копирования";
            DeleteOriginal3.Text = "Удалить после копирования";
            DeleteOriginal4.Text = "Удалить после копирования";
            AnotherTest1.Text = "Повторная проверка";
            AnotherTest2.Text = "Повторная проверка";
            AnotherTest3.Text = "Повторная проверка";
            AnotherTest4.Text = "Повторная проверка";
            CopyOnce1.Text = "Одно копирование";
            CopyOnce2.Text = "Одно копирование";
            CopyOnce3.Text = "Одно копирование";
            CopyOnce4.Text = "Одно копирование";
            Default.Text = "По умолчанию";
            AnotherTestDefault.Text = "Повторная проверка";
            DeleteOriginalFile.Text = "Удалить оригинальные файлы";
            CopyOnceDefault.Text = "Копирование (1 файл в 1 папку)";
            Source.Text = "Исходная папка";
            Apply.Text = "Пуск";
            Stop.Text = "Остановить";
            Close.Text = "Закрыть";
            ResetSetting.Text = "Сбросить";
            SaveSetting.Text = "Сохранить";
            LoadingSetting.Text = "Загрузить";
            AutoLoading.Text = "Авто загрузка установок";
            AutoCheck.Text = "Автоматическое слежение";
            BTNinfo.Text = "Информация";
            DeleteAfterTest1.Text = "Удалить оригинал";
            DeleteAfterTest2.Text = "Удалить оригинал";
            DeleteAfterTest3.Text = "Удалить оригинал";
            DeleteAfterTest4.Text = "Удалить оригинал";
            Clone1.Text = "Клонировать";
            Clone2.Text = "Клонировать";
            BTNClear1.Text = "Очистить";
            BTNClear2.Text = "Очистить";
            Notifications.Text = "Показывать уведомления";
            DeleteAfterTestDefault.Text = "Удалить после проверки";
        }

        private void Ukrainian_CheckedChanged(object sender, EventArgs e) //Ukrainian Localization
        {
            Advanced.Text = "Розширені";
            One.Text = "Перша папка";
            Two.Text = "Друга папка";
            Three.Text = "Третя папка";
            Four.Text = "Четверта папка";
            DeleteOriginal1.Text = "Видалити після копіювання";
            DeleteOriginal2.Text = "Видалити після копіювання";
            DeleteOriginal3.Text = "Видалити після копіювання";
            DeleteOriginal4.Text = "Видалити після копіювання";
            AnotherTest1.Text = "Провторная перевірка";
            AnotherTest2.Text = "Провторная перевірка";
            AnotherTest3.Text = "Провторная перевірка";
            AnotherTest4.Text = "Провторная перевірка";
            CopyOnce1.Text = "Одне копіювання";
            CopyOnce2.Text = "Одне копіювання";
            CopyOnce3.Text = "Одне копіювання";
            CopyOnce4.Text = "Одне копіювання";
            Default.Text = "Стандартнi";
            AnotherTestDefault.Text = "Повторна перевірка";
            DeleteOriginalFile.Text = "Видалити оригінальні файли";
            CopyOnceDefault.Text = "Копіювання (1 файл в 1 папку)";
            Source.Text = "Вихідна папка";
            Apply.Text = "Пуск";
            Stop.Text = "Зупинити";
            Close.Text = "Закрити";
            SaveSetting.Text = "Зберегти";
            LoadingSetting.Text = "Завантажити";
            ResetSetting.Text = "Скинуты";
            AutoLoading.Text = "Авто завантаження установок";
            AutoCheck.Text = "Автоматичне стеження";
            BTNinfo.Text = "Інформація";
            DeleteAfterTest1.Text = "Видалити оригінал";
            DeleteAfterTest2.Text = "Видалити оригінал";
            DeleteAfterTest3.Text = "Видалити оригінал";
            DeleteAfterTest4.Text = "Видалити оригінал";
            Clone1.Text = "Клонувати";
            Clone2.Text = "Клонувати";
            BTNClear1.Text = "Очистити";
            BTNClear2.Text = "Очистити";
            Notifications.Text = "Показувати сповіщення";
            DeleteAfterTestDefault.Text = "Видалити після перевірки";
        }

        private void SaveSetting_Click(object sender, EventArgs e)
        {
            string SaveText = "This is a save file executed through the ass.";
            try
            {
                string[] WayAndKey = { AutoLoading.Checked.ToString(), source_way, one_way, two_way, three_way, four_way, Key_One.Text, Key_Two.Text, Key_Three.Text, Key_Four.Text, SaveText };
                File.WriteAllLines(path: WaySave, contents: WayAndKey, encoding: Encoding.UTF8);
            }
            catch(Exception)
            {

            }
        }

        private void LoadingSetting_Click(object sender, EventArgs e)
        {
            loadingSetting();
        }

        private void CheckingFileSave()
        {
            Control AutoLoadingChecking = AutoLoading;
            string[] readSetting = File.ReadAllLines(WaySave, Encoding.UTF8);
            if (readSetting[0] == "True")
            {
                loadingSetting();
            }
        }

        private void loadingSetting()
        {
            WayAndText();
            try
            {
                string[] readSetting = File.ReadAllLines(WaySave, Encoding.UTF8);
                AutoLoading.Checked = Convert.ToBoolean(readSetting[0]);
                for (byte i = 1; i < readSetting.Length - 1; i++)
                {
                    try
                    {
                        WayAndKey[i].Text = readSetting[i];
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error load setting!");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save file not found");
            }
        }

        private void WayAndText()
        {
            WayAndKey = new Control[] { AutoLoading, Source_way, NewOne_way, Two_way, Three_way, Four_way, Key_One, Key_Two, Key_Three, Key_Four };
        }

        private void ResetSetting_Click(object sender, EventArgs e)
        {
            try
            {
                WayAndText();
                for (byte i = 1; i < WayAndKey.Length; i++)
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
                Key_One,
                Key_Two,
                Key_Three,
                Key_Four
            };
            Way = new Control[]
            {
                NewOne_way,
                Two_way,
                Three_way,
                Four_way
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
        private void AnotherTestCheck(object sender, EventArgs e)
        {
            //            Another = new bool[]
            //            {
            //                AnotherTest1.Checked,
            //                AnotherTest2.Checked,
            //                AnotherTest3.Checked,
            //                AnotherTest4.Checked
            //            };
            //            AnotherDel = new bool[]
            //            {
            //                DeleteAfterTest1.Checked,
            //                DeleteAfterTest2.Checked,
            //                DeleteAfterTest3.Checked,
            //                DeleteAfterTest4.Checked,
            //            };
            //            bool[] AnotherDelEnable = new bool[]
            //            {
            //                DeleteAfterTest1.Enabled,
            //                DeleteAfterTest2.Enabled,
            //                DeleteAfterTest3.Enabled,
            //                DeleteAfterTest4.Enabled
            //            };

            //            Control[] TEST = new Control[]
            //            {
            //                AnotherTest1,
            //                AnotherTest2,
            //                AnotherTest3,
            //                AnotherTest4
            //            };

            //for (int i = 0; i < Another.Length; i++)
            //{
            //    if(!Another[i])
            //    {
            //        AnotherDel[i] = Another[i]; //Not Work
            //        AnotherDelEnable[i] = Another[i]; //Not Work
            //        DeleteAfterTest1.Enabled = Another[i]; //Not Work
            //        AnotherDelEnable[i] = AnotherTest1.Checked; //Not Work
            //        DeleteAfterTest1.Checked = AnotherTest1.Checked; //Work
            //    }
            //    else
            //    {
            //        AnotherDelEnable[i] = Another[i];
            //    }
            //}
            DeleteAfterTest1.Enabled = AnotherTest1.Checked;
            DeleteAfterTest2.Enabled = AnotherTest2.Checked;
            DeleteAfterTest3.Enabled = AnotherTest3.Checked;
            DeleteAfterTest4.Enabled = AnotherTest4.Checked;
            if (!DeleteAfterTest1.Enabled) { DeleteAfterTest1.Checked = false; }
            if (!DeleteAfterTest2.Enabled) { DeleteAfterTest2.Checked = false; }
            if (!DeleteAfterTest3.Enabled) { DeleteAfterTest3.Checked = false; }
            if (!DeleteAfterTest4.Enabled) { DeleteAfterTest4.Checked = false; }
        }

        private void AnotherTestDelault(object sender, EventArgs e)
        {
            DeleteAfterTestDefault.Enabled = AnotherTestDefault.Checked;
            if(!DeleteAfterTestDefault.Enabled) { DeleteAfterTestDefault.Checked = false; }
        }
    }
}