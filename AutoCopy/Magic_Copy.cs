using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MagicCopy
{
    public partial class Magic_Copy : Form
    {
        //Сложно вырубай!
        BackgroundWorker Worker;
        FileSystemWatcher Watcher;
        private string WaySave = @"TestSave.sav";
        private string source_way = @"";
        private string one_way = @"";
        private string two_way = @"";
        private string three_way = @"";
        private string four_way = @"";
        private string culling_way = @"";

        private string Key0 = ""; //Key word 1
        private string Key1 = ""; //Key word 2
        private string Key2 = ""; //Key word 3
        private string Key3 = ""; //Key word 4

        private string[] Key;
        private string[] WAYS;

        private uint TotalFile = 0;
        private uint TotalCopyFile = 0;
        private uint TotalCullingFile = 0;
        private bool EndScan = false;
        private bool Helper;

        Control[] WayAndKey;
        Control[] Way;
        Control[] KeyWord;

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

            Watcher = new FileSystemWatcher
            {
                Path = source_way,
                SynchronizingObject = this,
                Filter = "*"
            };
            Watcher.Created += new FileSystemEventHandler(OnChanged);

            ModePanel.BackColor = Color.FromArgb(0, 0, 0, 0);
            Progress.Enabled = true;
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
                Apply.Enabled = true;
                //AutoCheck.Enabled = true;
                source_way = NewSource_way.Text;
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

        private void CopyFiles()
        {
            EndScan = false;
            //What.Text = "";
            Key0 = NewKey_One.Text;
            Key1 = NewKey_Two.Text;
            Key2 = NewKey_Three.Text;
            Key3 = NewKey_Four.Text;

            if (source_way != "") //Checking all way and key word on null and void
            {
                WAYS = new string[]
                {
                    one_way,
                    two_way,
                    three_way,
                    four_way,
                };

                Key = new string[]
                {
                    Key0,
                    Key1,
                    Key2,
                    Key3,
                };
                int i = 0;
                for (; ;)
                {
                    if (i == 4)
                    {
                        MessageBox.Show("All way or key word is empty!\nOr error way.");
                        break;
                    }
                    if (WAYS[i] == "" || Key[i] == "")
                    {
                        i++;
                    }
                    else
                    {
                        Key0 = Key0.ToLower();
                        Key1 = Key1.ToLower();
                        Key2 = Key2.ToLower();
                        Key3 = Key3.ToLower();
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
            Worker.ReportProgress(-1, Files.Length);
            int Value = 0;
            EndScan = false;
            try
            {
                if (one_way.Length >= 3) { DirectoryInfo di1 = Directory.Exists(one_way) ? new DirectoryInfo(one_way) : Directory.CreateDirectory(one_way); }
                if (two_way.Length >= 3) { DirectoryInfo di2 = Directory.Exists(two_way) ? new DirectoryInfo(two_way) : Directory.CreateDirectory(two_way); }
                if (three_way.Length >= 3) { DirectoryInfo di3 = Directory.Exists(three_way) ? new DirectoryInfo(three_way) : Directory.CreateDirectory(three_way); }
                if (four_way.Length >= 3) { DirectoryInfo di4 = Directory.Exists(four_way) ? new DirectoryInfo(four_way) : Directory.CreateDirectory(four_way); }
                if (culling_way.Length >= 3) { DirectoryInfo di4 = Directory.Exists(culling_way) ? new DirectoryInfo(culling_way) : Directory.CreateDirectory(culling_way); }
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
                string FN = file.Name.ToLower();

                string[] KEY = new string[4];

                int[] FNstring = new int[]
                {
                    FN.IndexOf(Key0),
                    FN.IndexOf(Key1),
                    FN.IndexOf(Key2),
                    FN.IndexOf(Key3),
                };

                Key = new string[]
                {
                    Key0,
                    Key1,
                    Key2,
                    Key3,
                };

                for (byte i = 0; i < FNstring.Length; i++)
                {
                    if (FNstring[i] != 1) { KEY[i] = Key[i]; }
                }

                try
                {
                    Worker.ReportProgress(++Value, -1);

                    if (Key0 != "" && FN.IndexOf(Key0) != -1 || KEYS[0] == 1) //Scanning files in the source folder for matches
                    {
                        TotalCopyFile++;
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
                        TotalCopyFile++;
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
                        TotalCopyFile++;
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
                        TotalCopyFile++;
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
                    else if (cullingCheck.Checked && culling_way.Length > 3) //Culling
                    {
                        for (byte i = 0; i < FNstring.Length; i++)
                        {
                            if (FNstring[i] == -1)
                            {
                                string sourceFile = Path.Combine(source_way, file.Name); //Reading the source path
                                string destFile = Path.Combine(culling_way, file.Name); //Set the path for copying a file
                                File.Copy(sourceFile, destFile, true); //Copy file
                                TotalCullingFile++;
                                if (DeleteCulling.Checked) { File.Delete(sourceFile); };
                            }
                            else
                                i++;
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (KEYS[i] == 2 && Advanced.Checked)
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
            if (Notifications.Checked)
            {
                string MessageString = String.Format("Done! \nTotal files: {0} \nMatched: {1} \nCulling {2}", TotalFile, TotalCopyFile, TotalCullingFile);
                MessageBox.Show(MessageString);
            }
            TotalFile = 0;
            TotalCopyFile = 0;
            TotalCullingFile = 0;
            EndScan = true;
            //What.Text = "Copy over";
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
                this.NewSource_way.ClientSize = new Size(551, 20);
                this.AdvancedDeletePanel.Visible = false;
                this.Language.Location = new Point(11, 145);
                this.BTNinfo.Location = new Point(11, 220);
                this.InfoRichTextBox.Location = new Point(200, 145);
                this.ModePanel.Visible = false;
                this.ModePanel2.Visible = false;
            }
            else //Advanced Mod
            {
                this.MaximumSize = new Size(994, 560);
                this.MinimumSize = MaximumSize;
                this.Source.ClientSize = new Size(206, 20);
                this.Source.Location = new Point(760, 34);
                this.NewSource_way.ClientSize = new Size(738, 20);
                this.AdvancedDeletePanel.Visible = true;
                this.Language.Location = new Point(11, 246);
                this.BTNinfo.Location = new Point(11, 324);
                this.InfoRichTextBox.Location = new Point(200, 246);
                this.ModePanel.Visible = true;
                this.ModePanel2.Visible = true;
            }
        }

        private void Stop_Click(object sender, EventArgs e) //Stop copy
        {
            Worker.CancelAsync();
            Progress.Value = 0;
        }

        private void Fasttranslation()
        {
            NewTwo_way.Cue = NewOne_way.Cue;
            NewThree_way.Cue = NewOne_way.Cue;
            NewFour_way.Cue = NewOne_way.Cue;
            NewKey_Two.Cue = NewKey_One.Cue;
            NewKey_Three.Cue = NewKey_One.Cue;
            NewKey_Four.Cue = NewKey_One.Cue;
            DeleteAfterTest2.Text = DeleteAfterTest1.Text;
            DeleteAfterTest3.Text = DeleteAfterTest1.Text;
            DeleteAfterTest4.Text = DeleteAfterTest1.Text;
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
            DeleteCulling.Text = DeleteAfterTest1.Text;
        }

        private void English_CheckedChanged(object sender, EventArgs e) //English Localization
        {
            Advanced.Text = "Advanced";
            One.Text = "Folder one";
            Two.Text = "Folder two";
            Three.Text = "Folder three";
            Four.Text = "Folder four";
            DeleteOriginal1.Text = "Delete after copying";
            AnotherTest1.Text = "Another test";
            CopyOnce1.Text = "Copy once";
            Default.Text = "Default";
            AnotherTestDefault.Text = "Another Test";
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
            DeleteAfterTest1.Text = "Delete original";
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
            Fasttranslation();
        }

        private void Russian_CheckedChanged(object sender, EventArgs e) //Russian Localization
        {
            Advanced.Text = "Расширенные";
            One.Text = "Первая папка";
            Two.Text = "Вторая папка";
            Three.Text = "Третья папка";
            Four.Text = "Четвертая папка";
            DeleteOriginal1.Text = "Удалить после копирования";
            AnotherTest1.Text = "Повторная проверка";
            CopyOnce1.Text = "Одно копирование";
            Default.Text = "По умолчанию";
            AnotherTestDefault.Text = "Повторная проверка";
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
            AutoLoading.Text = "Авто загрузка установок";
            AutoCheck.Text = "Автоматическое слежение";
            BTNinfo.Text = "Информация";
            DeleteAfterTest1.Text = "Удалить оригинал";
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
            Fasttranslation();
        }

        private void Ukrainian_CheckedChanged(object sender, EventArgs e) //Ukrainian Localization
        {
            Advanced.Text = "Розширені";
            One.Text = "Перша папка";
            Two.Text = "Друга папка";
            Three.Text = "Третя папка";
            Four.Text = "Четверта папка";
            DeleteOriginal1.Text = "Видалити після копіювання";
            AnotherTest1.Text = "Провторная перевірка";
            CopyOnce1.Text = "Одне копіювання";
            Default.Text = "Стандартнi";
            AnotherTestDefault.Text = "Повторна перевірка";
            DeleteOriginalFile.Text = "Видалити оригінальні файли";
            CopyOnceDefault.Text = "Копіювання (1 файл в 1 папку)";
            Source.Text = "Вихідна папка";
            Apply.Text = "Пуск";
            Stop.Text = "Зупинити";
            Close.Text = "Закрити";
            fileToolStripMenuItem.Text = "Файл";
            saveToolStripMenuItem.Text = "Зберегти";
            loadToolStripMenuItem.Text = "Завантажити";
            resetToolStripMenuItem.Text = "Скинуты";
            closeToolStripMenuItem.Text = "Закрити";
            AutoLoading.Text = "Авто завантаження установок";
            AutoCheck.Text = "Автоматичне стеження";
            BTNinfo.Text = "Інформація";
            DeleteAfterTest1.Text = "Видалити оригінал";
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
            Fasttranslation();
        }

        private void SaveSetting(object sender, EventArgs e)
        {
            string SaveText = "This is a save file executed through the ass.";
            try
            {
                string[] WayAndKey = { AutoLoading.Checked.ToString(), source_way, one_way, two_way, three_way, four_way, culling_way, NewKey_One.Text, NewKey_Two.Text, NewKey_Three.Text, NewKey_Four.Text, SaveText };
                File.WriteAllLines(path: WaySave, contents: WayAndKey, encoding: Encoding.UTF8);
            }
            catch(Exception)
            {

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
            WayAndKey = new Control[] { AutoLoading, NewSource_way, NewOne_way, NewTwo_way, NewThree_way, NewFour_way, NewCulling_way, NewKey_One, NewKey_Two, NewKey_Three, NewKey_Four };
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
        private void AnotherTestCheck(object sender, EventArgs e)
        {
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
    }
}