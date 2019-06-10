namespace MagicCopy
{
    partial class Magic_Copy
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Magic_Copy));
            this.One = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.Button();
            this.Apply = new System.Windows.Forms.Button();
            this.Two_way = new System.Windows.Forms.TextBox();
            this.Three_way = new System.Windows.Forms.TextBox();
            this.Four_way = new System.Windows.Forms.TextBox();
            this.Source_way = new System.Windows.Forms.TextBox();
            this.Key_One = new System.Windows.Forms.TextBox();
            this.Key_Two = new System.Windows.Forms.TextBox();
            this.Key_Three = new System.Windows.Forms.TextBox();
            this.Key_Four = new System.Windows.Forms.TextBox();
            this.Close = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.What = new System.Windows.Forms.Label();
            this.Default = new System.Windows.Forms.RadioButton();
            this.Advanced = new System.Windows.Forms.RadioButton();
            this.AdvancedDeletePanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DeleteAfterTest4 = new System.Windows.Forms.CheckBox();
            this.AnotherTest4 = new System.Windows.Forms.RadioButton();
            this.CopyOnce4 = new System.Windows.Forms.RadioButton();
            this.DeleteOriginal4 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DeleteAfterTest3 = new System.Windows.Forms.CheckBox();
            this.CopyOnce3 = new System.Windows.Forms.RadioButton();
            this.DeleteOriginal3 = new System.Windows.Forms.RadioButton();
            this.AnotherTest3 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DeleteAfterTest2 = new System.Windows.Forms.CheckBox();
            this.CopyOnce2 = new System.Windows.Forms.RadioButton();
            this.AnotherTest2 = new System.Windows.Forms.RadioButton();
            this.DeleteOriginal2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteAfterTest1 = new System.Windows.Forms.CheckBox();
            this.CopyOnce1 = new System.Windows.Forms.RadioButton();
            this.AnotherTest1 = new System.Windows.Forms.RadioButton();
            this.DeleteOriginal1 = new System.Windows.Forms.RadioButton();
            this.Stop = new System.Windows.Forms.Button();
            this.DefaultPanel = new System.Windows.Forms.Panel();
            this.DeleteAfterTestDefault = new System.Windows.Forms.CheckBox();
            this.CopyOnceDefault = new System.Windows.Forms.RadioButton();
            this.DeleteOriginalFile = new System.Windows.Forms.RadioButton();
            this.AnotherTestDefault = new System.Windows.Forms.RadioButton();
            this.Language = new System.Windows.Forms.Panel();
            this.Ukrainian = new System.Windows.Forms.RadioButton();
            this.Russian = new System.Windows.Forms.RadioButton();
            this.English = new System.Windows.Forms.RadioButton();
            this.SaveSetting = new System.Windows.Forms.Button();
            this.LoadingSetting = new System.Windows.Forms.Button();
            this.AutoLoading = new System.Windows.Forms.CheckBox();
            this.ResetSetting = new System.Windows.Forms.Button();
            this.AutoCheck = new System.Windows.Forms.CheckBox();
            this.HelpShow = new System.Windows.Forms.ToolTip(this.components);
            this.Clone1 = new System.Windows.Forms.Button();
            this.Clone2 = new System.Windows.Forms.Button();
            this.BTNClear1 = new System.Windows.Forms.Button();
            this.BTNClear2 = new System.Windows.Forms.Button();
            this.Notifications = new System.Windows.Forms.CheckBox();
            this.BTNinfo = new System.Windows.Forms.Button();
            this.InfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.FastMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ModePanel = new System.Windows.Forms.Panel();
            this.NewOne_way = new MagicCopy.CueTextBox();
            this.NewSource_way = new MagicCopy.CueTextBox();
            this.AdvancedDeletePanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.DefaultPanel.SuspendLayout();
            this.Language.SuspendLayout();
            this.FastMenu.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.ModePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // One
            // 
            this.One.Location = new System.Drawing.Point(11, 89);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(181, 23);
            this.One.TabIndex = 0;
            this.One.Text = "Folder one";
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.One_Click);
            // 
            // Two
            // 
            this.Two.Location = new System.Drawing.Point(198, 89);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(181, 23);
            this.Two.TabIndex = 1;
            this.Two.Text = "Folder tow";
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.Tow_Click);
            // 
            // Three
            // 
            this.Three.Location = new System.Drawing.Point(385, 89);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(181, 23);
            this.Three.TabIndex = 2;
            this.Three.Text = "Folder three";
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.Three_Click);
            // 
            // Four
            // 
            this.Four.Location = new System.Drawing.Point(572, 89);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(181, 23);
            this.Four.TabIndex = 3;
            this.Four.Text = "Folder four";
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.Four_Click);
            // 
            // Source
            // 
            this.Source.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Source.AutoSize = true;
            this.Source.Location = new System.Drawing.Point(759, 36);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(206, 23);
            this.Source.TabIndex = 4;
            this.Source.Text = "Source Folder";
            this.Source.UseVisualStyleBackColor = true;
            this.Source.Click += new System.EventHandler(this.Source_Click);
            // 
            // Apply
            // 
            this.Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Apply.Location = new System.Drawing.Point(285, 10);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(100, 23);
            this.Apply.TabIndex = 5;
            this.Apply.Text = "Start";
            this.HelpShow.SetToolTip(this.Apply, "Start the program.\r\nDisabled for errors in the source folder path!");
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // Two_way
            // 
            this.Two_way.Location = new System.Drawing.Point(199, 65);
            this.Two_way.Name = "Two_way";
            this.Two_way.Size = new System.Drawing.Size(181, 20);
            this.Two_way.TabIndex = 7;
            this.Two_way.Text = "Where to move";
            this.HelpShow.SetToolTip(this.Two_way, "Destination folder");
            this.Two_way.TextChanged += new System.EventHandler(this.Tow_way_TextChanged);
            // 
            // Three_way
            // 
            this.Three_way.Location = new System.Drawing.Point(386, 65);
            this.Three_way.Name = "Three_way";
            this.Three_way.Size = new System.Drawing.Size(181, 20);
            this.Three_way.TabIndex = 8;
            this.Three_way.Text = "Where to move";
            this.HelpShow.SetToolTip(this.Three_way, "Destination folder");
            this.Three_way.TextChanged += new System.EventHandler(this.Three_way_TextChanged);
            // 
            // Four_way
            // 
            this.Four_way.Location = new System.Drawing.Point(573, 65);
            this.Four_way.Name = "Four_way";
            this.Four_way.Size = new System.Drawing.Size(181, 20);
            this.Four_way.TabIndex = 9;
            this.Four_way.Text = "Where to move";
            this.HelpShow.SetToolTip(this.Four_way, "Destination folder");
            this.Four_way.TextChanged += new System.EventHandler(this.Four_way_TextChanged);
            // 
            // Source_way
            // 
            this.Source_way.Location = new System.Drawing.Point(12, 36);
            this.Source_way.MaximumSize = new System.Drawing.Size(741, 20);
            this.Source_way.Name = "Source_way";
            this.Source_way.Size = new System.Drawing.Size(741, 20);
            this.Source_way.TabIndex = 10;
            this.Source_way.Text = "The path to the folder in which the scan occurs. Example C:\\My Folder";
            this.HelpShow.SetToolTip(this.Source_way, "Way to source folder");
            this.Source_way.TextChanged += new System.EventHandler(this.Source_way_TextChanged);
            // 
            // Key_One
            // 
            this.Key_One.Location = new System.Drawing.Point(11, 118);
            this.Key_One.Name = "Key_One";
            this.Key_One.Size = new System.Drawing.Size(181, 20);
            this.Key_One.TabIndex = 11;
            this.Key_One.Text = "Key word for scan";
            this.HelpShow.SetToolTip(this.Key_One, "Keyword for sorting");
            // 
            // Key_Two
            // 
            this.Key_Two.Location = new System.Drawing.Point(198, 118);
            this.Key_Two.Name = "Key_Two";
            this.Key_Two.Size = new System.Drawing.Size(181, 20);
            this.Key_Two.TabIndex = 12;
            this.Key_Two.Text = "Key word for scan";
            this.HelpShow.SetToolTip(this.Key_Two, "Keyword for sorting");
            // 
            // Key_Three
            // 
            this.Key_Three.Location = new System.Drawing.Point(385, 118);
            this.Key_Three.Name = "Key_Three";
            this.Key_Three.Size = new System.Drawing.Size(181, 20);
            this.Key_Three.TabIndex = 13;
            this.Key_Three.Text = "Key word for scan";
            this.HelpShow.SetToolTip(this.Key_Three, "Keyword for sorting");
            // 
            // Key_Four
            // 
            this.Key_Four.Location = new System.Drawing.Point(572, 118);
            this.Key_Four.Name = "Key_Four";
            this.Key_Four.Size = new System.Drawing.Size(181, 20);
            this.Key_Four.TabIndex = 14;
            this.Key_Four.Text = "Key word for scan";
            this.HelpShow.SetToolTip(this.Key_Four, "Keyword for sorting");
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Location = new System.Drawing.Point(286, 61);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(100, 23);
            this.Close.TabIndex = 15;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Progress
            // 
            this.Progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Progress.Location = new System.Drawing.Point(0, 498);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(978, 23);
            this.Progress.TabIndex = 17;
            this.HelpShow.SetToolTip(this.Progress, "Progress bar. It\'s broken... ");
            // 
            // What
            // 
            this.What.AutoSize = true;
            this.What.Location = new System.Drawing.Point(12, 299);
            this.What.Name = "What";
            this.What.Size = new System.Drawing.Size(0, 13);
            this.What.TabIndex = 18;
            // 
            // Default
            // 
            this.Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Default.AutoSize = true;
            this.Default.BackColor = System.Drawing.SystemColors.Window;
            this.Default.Checked = true;
            this.Default.Location = new System.Drawing.Point(3, 22);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(59, 17);
            this.Default.TabIndex = 20;
            this.Default.TabStop = true;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = false;
            this.Default.CheckedChanged += new System.EventHandler(this.Default_CheckedChanged);
            // 
            // Advanced
            // 
            this.Advanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Advanced.AutoSize = true;
            this.Advanced.BackColor = System.Drawing.SystemColors.Window;
            this.Advanced.Location = new System.Drawing.Point(3, 3);
            this.Advanced.Name = "Advanced";
            this.Advanced.Size = new System.Drawing.Size(74, 17);
            this.Advanced.TabIndex = 21;
            this.Advanced.Text = "Advanced";
            this.Advanced.UseVisualStyleBackColor = false;
            this.Advanced.CheckedChanged += new System.EventHandler(this.Advanced_CheckedChanged);
            // 
            // AdvancedDeletePanel
            // 
            this.AdvancedDeletePanel.BackColor = System.Drawing.SystemColors.Window;
            this.AdvancedDeletePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AdvancedDeletePanel.Controls.Add(this.panel4);
            this.AdvancedDeletePanel.Controls.Add(this.panel3);
            this.AdvancedDeletePanel.Controls.Add(this.panel2);
            this.AdvancedDeletePanel.Controls.Add(this.panel1);
            this.AdvancedDeletePanel.Enabled = false;
            this.AdvancedDeletePanel.Location = new System.Drawing.Point(11, 144);
            this.AdvancedDeletePanel.MinimumSize = new System.Drawing.Size(742, 73);
            this.AdvancedDeletePanel.Name = "AdvancedDeletePanel";
            this.AdvancedDeletePanel.Size = new System.Drawing.Size(742, 96);
            this.AdvancedDeletePanel.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.DeleteAfterTest4);
            this.panel4.Controls.Add(this.AnotherTest4);
            this.panel4.Controls.Add(this.CopyOnce4);
            this.panel4.Controls.Add(this.DeleteOriginal4);
            this.panel4.Location = new System.Drawing.Point(560, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(181, 96);
            this.panel4.TabIndex = 4;
            // 
            // DeleteAfterTest4
            // 
            this.DeleteAfterTest4.AutoSize = true;
            this.DeleteAfterTest4.Enabled = false;
            this.DeleteAfterTest4.Location = new System.Drawing.Point(3, 72);
            this.DeleteAfterTest4.Name = "DeleteAfterTest4";
            this.DeleteAfterTest4.Size = new System.Drawing.Size(101, 17);
            this.DeleteAfterTest4.TabIndex = 4;
            this.DeleteAfterTest4.Text = "Delete after test";
            this.DeleteAfterTest4.UseVisualStyleBackColor = true;
            // 
            // AnotherTest4
            // 
            this.AnotherTest4.AutoSize = true;
            this.AnotherTest4.Location = new System.Drawing.Point(3, 26);
            this.AnotherTest4.Name = "AnotherTest4";
            this.AnotherTest4.Size = new System.Drawing.Size(86, 17);
            this.AnotherTest4.TabIndex = 3;
            this.AnotherTest4.Text = "Another Test";
            this.HelpShow.SetToolTip(this.AnotherTest4, "Allows you to copy a file to all folders in case of matching keywords");
            this.AnotherTest4.UseVisualStyleBackColor = true;
            this.AnotherTest4.CheckedChanged += new System.EventHandler(this.AnotherTestCheck);
            // 
            // CopyOnce4
            // 
            this.CopyOnce4.AutoSize = true;
            this.CopyOnce4.Checked = true;
            this.CopyOnce4.Location = new System.Drawing.Point(3, 49);
            this.CopyOnce4.Name = "CopyOnce4";
            this.CopyOnce4.Size = new System.Drawing.Size(78, 17);
            this.CopyOnce4.TabIndex = 2;
            this.CopyOnce4.TabStop = true;
            this.CopyOnce4.Text = "Copy Once";
            this.HelpShow.SetToolTip(this.CopyOnce4, "The program copies the file to the specified folder without deleting the original" +
        "");
            this.CopyOnce4.UseVisualStyleBackColor = true;
            // 
            // DeleteOriginal4
            // 
            this.DeleteOriginal4.AutoSize = true;
            this.DeleteOriginal4.Location = new System.Drawing.Point(3, 3);
            this.DeleteOriginal4.Name = "DeleteOriginal4";
            this.DeleteOriginal4.Size = new System.Drawing.Size(120, 17);
            this.DeleteOriginal4.TabIndex = 0;
            this.DeleteOriginal4.Text = "Delete after copying";
            this.HelpShow.SetToolTip(this.DeleteOriginal4, "Deleting original files after copying");
            this.DeleteOriginal4.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.DeleteAfterTest3);
            this.panel3.Controls.Add(this.CopyOnce3);
            this.panel3.Controls.Add(this.DeleteOriginal3);
            this.panel3.Controls.Add(this.AnotherTest3);
            this.panel3.Location = new System.Drawing.Point(373, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 96);
            this.panel3.TabIndex = 3;
            // 
            // DeleteAfterTest3
            // 
            this.DeleteAfterTest3.AutoSize = true;
            this.DeleteAfterTest3.Enabled = false;
            this.DeleteAfterTest3.Location = new System.Drawing.Point(3, 72);
            this.DeleteAfterTest3.Name = "DeleteAfterTest3";
            this.DeleteAfterTest3.Size = new System.Drawing.Size(101, 17);
            this.DeleteAfterTest3.TabIndex = 3;
            this.DeleteAfterTest3.Text = "Delete after test";
            this.DeleteAfterTest3.UseVisualStyleBackColor = true;
            // 
            // CopyOnce3
            // 
            this.CopyOnce3.AutoSize = true;
            this.CopyOnce3.Checked = true;
            this.CopyOnce3.Location = new System.Drawing.Point(3, 49);
            this.CopyOnce3.Name = "CopyOnce3";
            this.CopyOnce3.Size = new System.Drawing.Size(78, 17);
            this.CopyOnce3.TabIndex = 2;
            this.CopyOnce3.TabStop = true;
            this.CopyOnce3.Text = "Copy Once";
            this.HelpShow.SetToolTip(this.CopyOnce3, "The program copies the file to the specified folder without deleting the original" +
        "");
            this.CopyOnce3.UseVisualStyleBackColor = true;
            // 
            // DeleteOriginal3
            // 
            this.DeleteOriginal3.AutoSize = true;
            this.DeleteOriginal3.Location = new System.Drawing.Point(3, 3);
            this.DeleteOriginal3.Name = "DeleteOriginal3";
            this.DeleteOriginal3.Size = new System.Drawing.Size(120, 17);
            this.DeleteOriginal3.TabIndex = 0;
            this.DeleteOriginal3.Text = "Delete after copying";
            this.HelpShow.SetToolTip(this.DeleteOriginal3, "Deleting original files after copying");
            this.DeleteOriginal3.UseVisualStyleBackColor = true;
            // 
            // AnotherTest3
            // 
            this.AnotherTest3.AutoSize = true;
            this.AnotherTest3.Location = new System.Drawing.Point(3, 26);
            this.AnotherTest3.Name = "AnotherTest3";
            this.AnotherTest3.Size = new System.Drawing.Size(86, 17);
            this.AnotherTest3.TabIndex = 1;
            this.AnotherTest3.Text = "Another Test";
            this.HelpShow.SetToolTip(this.AnotherTest3, "Allows you to copy a file to all folders in case of matching keywords");
            this.AnotherTest3.UseVisualStyleBackColor = true;
            this.AnotherTest3.CheckedChanged += new System.EventHandler(this.AnotherTestCheck);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.DeleteAfterTest2);
            this.panel2.Controls.Add(this.CopyOnce2);
            this.panel2.Controls.Add(this.AnotherTest2);
            this.panel2.Controls.Add(this.DeleteOriginal2);
            this.panel2.Location = new System.Drawing.Point(186, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 96);
            this.panel2.TabIndex = 2;
            // 
            // DeleteAfterTest2
            // 
            this.DeleteAfterTest2.AutoSize = true;
            this.DeleteAfterTest2.Enabled = false;
            this.DeleteAfterTest2.Location = new System.Drawing.Point(3, 72);
            this.DeleteAfterTest2.Name = "DeleteAfterTest2";
            this.DeleteAfterTest2.Size = new System.Drawing.Size(101, 17);
            this.DeleteAfterTest2.TabIndex = 3;
            this.DeleteAfterTest2.Text = "Delete after test";
            this.DeleteAfterTest2.UseVisualStyleBackColor = true;
            // 
            // CopyOnce2
            // 
            this.CopyOnce2.AutoSize = true;
            this.CopyOnce2.Checked = true;
            this.CopyOnce2.Location = new System.Drawing.Point(3, 49);
            this.CopyOnce2.Name = "CopyOnce2";
            this.CopyOnce2.Size = new System.Drawing.Size(78, 17);
            this.CopyOnce2.TabIndex = 2;
            this.CopyOnce2.TabStop = true;
            this.CopyOnce2.Text = "Copy Once";
            this.HelpShow.SetToolTip(this.CopyOnce2, "The program copies the file to the specified folder without deleting the original" +
        "");
            this.CopyOnce2.UseVisualStyleBackColor = true;
            // 
            // AnotherTest2
            // 
            this.AnotherTest2.AutoSize = true;
            this.AnotherTest2.Location = new System.Drawing.Point(3, 26);
            this.AnotherTest2.Name = "AnotherTest2";
            this.AnotherTest2.Size = new System.Drawing.Size(86, 17);
            this.AnotherTest2.TabIndex = 1;
            this.AnotherTest2.Text = "Another Test";
            this.HelpShow.SetToolTip(this.AnotherTest2, "Allows you to copy a file to all folders in case of matching keywords");
            this.AnotherTest2.UseVisualStyleBackColor = true;
            this.AnotherTest2.CheckedChanged += new System.EventHandler(this.AnotherTestCheck);
            // 
            // DeleteOriginal2
            // 
            this.DeleteOriginal2.AutoSize = true;
            this.DeleteOriginal2.Location = new System.Drawing.Point(3, 3);
            this.DeleteOriginal2.Name = "DeleteOriginal2";
            this.DeleteOriginal2.Size = new System.Drawing.Size(120, 17);
            this.DeleteOriginal2.TabIndex = 0;
            this.DeleteOriginal2.Text = "Delete after copying";
            this.HelpShow.SetToolTip(this.DeleteOriginal2, "Deleting original files after copying");
            this.DeleteOriginal2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.DeleteAfterTest1);
            this.panel1.Controls.Add(this.CopyOnce1);
            this.panel1.Controls.Add(this.AnotherTest1);
            this.panel1.Controls.Add(this.DeleteOriginal1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 96);
            this.panel1.TabIndex = 1;
            // 
            // DeleteAfterTest1
            // 
            this.DeleteAfterTest1.AutoSize = true;
            this.DeleteAfterTest1.Enabled = false;
            this.DeleteAfterTest1.Location = new System.Drawing.Point(3, 72);
            this.DeleteAfterTest1.Name = "DeleteAfterTest1";
            this.DeleteAfterTest1.Size = new System.Drawing.Size(101, 17);
            this.DeleteAfterTest1.TabIndex = 3;
            this.DeleteAfterTest1.Text = "Delete after test";
            this.DeleteAfterTest1.UseVisualStyleBackColor = true;
            // 
            // CopyOnce1
            // 
            this.CopyOnce1.AutoSize = true;
            this.CopyOnce1.Checked = true;
            this.CopyOnce1.Location = new System.Drawing.Point(3, 49);
            this.CopyOnce1.Name = "CopyOnce1";
            this.CopyOnce1.Size = new System.Drawing.Size(78, 17);
            this.CopyOnce1.TabIndex = 2;
            this.CopyOnce1.TabStop = true;
            this.CopyOnce1.Text = "Copy Once";
            this.HelpShow.SetToolTip(this.CopyOnce1, "The program copies the file to the specified folder without deleting the original" +
        "");
            this.CopyOnce1.UseVisualStyleBackColor = true;
            // 
            // AnotherTest1
            // 
            this.AnotherTest1.AutoSize = true;
            this.AnotherTest1.Location = new System.Drawing.Point(3, 26);
            this.AnotherTest1.Name = "AnotherTest1";
            this.AnotherTest1.Size = new System.Drawing.Size(86, 17);
            this.AnotherTest1.TabIndex = 1;
            this.AnotherTest1.Text = "Another Test";
            this.HelpShow.SetToolTip(this.AnotherTest1, "Allows you to copy a file to all folders in case of matching keywords");
            this.AnotherTest1.UseVisualStyleBackColor = true;
            this.AnotherTest1.CheckedChanged += new System.EventHandler(this.AnotherTestCheck);
            // 
            // DeleteOriginal1
            // 
            this.DeleteOriginal1.AutoSize = true;
            this.DeleteOriginal1.Location = new System.Drawing.Point(3, 3);
            this.DeleteOriginal1.Name = "DeleteOriginal1";
            this.DeleteOriginal1.Size = new System.Drawing.Size(120, 17);
            this.DeleteOriginal1.TabIndex = 0;
            this.DeleteOriginal1.Text = "Delete after copying";
            this.HelpShow.SetToolTip(this.DeleteOriginal1, "Deleting original files after copying");
            this.DeleteOriginal1.UseVisualStyleBackColor = true;
            // 
            // Stop
            // 
            this.Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop.Location = new System.Drawing.Point(285, 36);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 23);
            this.Stop.TabIndex = 23;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // DefaultPanel
            // 
            this.DefaultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DefaultPanel.BackColor = System.Drawing.SystemColors.Window;
            this.DefaultPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DefaultPanel.Controls.Add(this.DeleteAfterTestDefault);
            this.DefaultPanel.Controls.Add(this.CopyOnceDefault);
            this.DefaultPanel.Controls.Add(this.DeleteOriginalFile);
            this.DefaultPanel.Controls.Add(this.AnotherTestDefault);
            this.DefaultPanel.Location = new System.Drawing.Point(12, 405);
            this.DefaultPanel.Name = "DefaultPanel";
            this.DefaultPanel.Size = new System.Drawing.Size(291, 91);
            this.DefaultPanel.TabIndex = 25;
            // 
            // DeleteAfterTestDefault
            // 
            this.DeleteAfterTestDefault.AutoSize = true;
            this.DeleteAfterTestDefault.Enabled = false;
            this.DeleteAfterTestDefault.Location = new System.Drawing.Point(175, 15);
            this.DeleteAfterTestDefault.Name = "DeleteAfterTestDefault";
            this.DeleteAfterTestDefault.Size = new System.Drawing.Size(101, 17);
            this.DeleteAfterTestDefault.TabIndex = 28;
            this.DeleteAfterTestDefault.Text = "Delete after test";
            this.DeleteAfterTestDefault.UseVisualStyleBackColor = true;
            // 
            // CopyOnceDefault
            // 
            this.CopyOnceDefault.AutoSize = true;
            this.CopyOnceDefault.Checked = true;
            this.CopyOnceDefault.Location = new System.Drawing.Point(3, 55);
            this.CopyOnceDefault.Name = "CopyOnceDefault";
            this.CopyOnceDefault.Size = new System.Drawing.Size(159, 17);
            this.CopyOnceDefault.TabIndex = 27;
            this.CopyOnceDefault.TabStop = true;
            this.CopyOnceDefault.Text = "Copy Once (1 file to 1 folder)";
            this.HelpShow.SetToolTip(this.CopyOnceDefault, "The program copies the file to the specified folder without deleting the original" +
        "");
            this.CopyOnceDefault.UseVisualStyleBackColor = true;
            // 
            // DeleteOriginalFile
            // 
            this.DeleteOriginalFile.AutoSize = true;
            this.DeleteOriginalFile.Location = new System.Drawing.Point(3, 35);
            this.DeleteOriginalFile.Name = "DeleteOriginalFile";
            this.DeleteOriginalFile.Size = new System.Drawing.Size(127, 17);
            this.DeleteOriginalFile.TabIndex = 26;
            this.DeleteOriginalFile.Text = "Delete All Original File";
            this.HelpShow.SetToolTip(this.DeleteOriginalFile, "Deleting original files after copying");
            this.DeleteOriginalFile.UseVisualStyleBackColor = true;
            // 
            // AnotherTestDefault
            // 
            this.AnotherTestDefault.AutoSize = true;
            this.AnotherTestDefault.Location = new System.Drawing.Point(3, 15);
            this.AnotherTestDefault.Name = "AnotherTestDefault";
            this.AnotherTestDefault.Size = new System.Drawing.Size(86, 17);
            this.AnotherTestDefault.TabIndex = 25;
            this.AnotherTestDefault.Text = "Another Test";
            this.HelpShow.SetToolTip(this.AnotherTestDefault, "Allows you to copy a file to all folders in case of matching keywords");
            this.AnotherTestDefault.UseVisualStyleBackColor = true;
            this.AnotherTestDefault.CheckedChanged += new System.EventHandler(this.AnotherTestDelault);
            // 
            // Language
            // 
            this.Language.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Language.BackColor = System.Drawing.SystemColors.Window;
            this.Language.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Language.Controls.Add(this.Ukrainian);
            this.Language.Controls.Add(this.Russian);
            this.Language.Controls.Add(this.English);
            this.Language.Location = new System.Drawing.Point(12, 246);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(181, 72);
            this.Language.TabIndex = 26;
            // 
            // Ukrainian
            // 
            this.Ukrainian.AutoSize = true;
            this.Ukrainian.Location = new System.Drawing.Point(3, 49);
            this.Ukrainian.Name = "Ukrainian";
            this.Ukrainian.Size = new System.Drawing.Size(70, 17);
            this.Ukrainian.TabIndex = 2;
            this.Ukrainian.Text = "Ukrainian";
            this.Ukrainian.UseVisualStyleBackColor = true;
            this.Ukrainian.CheckedChanged += new System.EventHandler(this.Ukrainian_CheckedChanged);
            // 
            // Russian
            // 
            this.Russian.AutoSize = true;
            this.Russian.Location = new System.Drawing.Point(3, 26);
            this.Russian.Name = "Russian";
            this.Russian.Size = new System.Drawing.Size(63, 17);
            this.Russian.TabIndex = 1;
            this.Russian.Text = "Russian";
            this.Russian.UseVisualStyleBackColor = true;
            this.Russian.CheckedChanged += new System.EventHandler(this.Russian_CheckedChanged);
            // 
            // English
            // 
            this.English.AutoSize = true;
            this.English.Checked = true;
            this.English.Location = new System.Drawing.Point(3, 3);
            this.English.Name = "English";
            this.English.Size = new System.Drawing.Size(59, 17);
            this.English.TabIndex = 0;
            this.English.TabStop = true;
            this.English.Text = "English";
            this.HelpShow.SetToolTip(this.English, "The translation may contain errors!");
            this.English.UseVisualStyleBackColor = true;
            this.English.CheckedChanged += new System.EventHandler(this.English_CheckedChanged);
            // 
            // SaveSetting
            // 
            this.SaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSetting.Location = new System.Drawing.Point(183, 10);
            this.SaveSetting.Name = "SaveSetting";
            this.SaveSetting.Size = new System.Drawing.Size(100, 23);
            this.SaveSetting.TabIndex = 27;
            this.SaveSetting.Text = "Save";
            this.HelpShow.SetToolTip(this.SaveSetting, "Save way folder\r\nThe save file will be created in the program folder");
            this.SaveSetting.UseVisualStyleBackColor = true;
            this.SaveSetting.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // LoadingSetting
            // 
            this.LoadingSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingSetting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoadingSetting.Location = new System.Drawing.Point(183, 36);
            this.LoadingSetting.Name = "LoadingSetting";
            this.LoadingSetting.Size = new System.Drawing.Size(100, 23);
            this.LoadingSetting.TabIndex = 28;
            this.LoadingSetting.Text = "Loading";
            this.HelpShow.SetToolTip(this.LoadingSetting, "Load way folder\r\nFrom the save file that was created created in the program folde" +
        "r");
            this.LoadingSetting.UseVisualStyleBackColor = true;
            this.LoadingSetting.Click += new System.EventHandler(this.LoadingSetting_Click);
            // 
            // AutoLoading
            // 
            this.AutoLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoLoading.Location = new System.Drawing.Point(-1, 66);
            this.AutoLoading.Name = "AutoLoading";
            this.AutoLoading.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AutoLoading.Size = new System.Drawing.Size(179, 17);
            this.AutoLoading.TabIndex = 29;
            this.AutoLoading.Text = "Auto loading settings";
            this.AutoLoading.UseVisualStyleBackColor = true;
            // 
            // ResetSetting
            // 
            this.ResetSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetSetting.Location = new System.Drawing.Point(183, 62);
            this.ResetSetting.Name = "ResetSetting";
            this.ResetSetting.Size = new System.Drawing.Size(100, 23);
            this.ResetSetting.TabIndex = 30;
            this.ResetSetting.Text = "Reset";
            this.ResetSetting.UseVisualStyleBackColor = true;
            this.ResetSetting.Click += new System.EventHandler(this.ResetSetting_Click);
            // 
            // AutoCheck
            // 
            this.AutoCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCheck.Location = new System.Drawing.Point(-1, 45);
            this.AutoCheck.Name = "AutoCheck";
            this.AutoCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AutoCheck.Size = new System.Drawing.Size(179, 17);
            this.AutoCheck.TabIndex = 31;
            this.AutoCheck.Text = "Automatic tracking";
            this.HelpShow.SetToolTip(this.AutoCheck, resources.GetString("AutoCheck.ToolTip"));
            this.AutoCheck.UseVisualStyleBackColor = true;
            this.AutoCheck.EnabledChanged += new System.EventHandler(this.LoadingSetting_Click);
            // 
            // HelpShow
            // 
            this.HelpShow.AutoPopDelay = 5000;
            this.HelpShow.InitialDelay = 500;
            this.HelpShow.ReshowDelay = 100;
            // 
            // Clone1
            // 
            this.Clone1.Location = new System.Drawing.Point(2, 3);
            this.Clone1.Name = "Clone1";
            this.Clone1.Size = new System.Drawing.Size(100, 20);
            this.Clone1.TabIndex = 34;
            this.Clone1.Text = "Clone";
            this.HelpShow.SetToolTip(this.Clone1, "Clones the first or any non-empty path");
            this.Clone1.UseVisualStyleBackColor = true;
            this.Clone1.Click += new System.EventHandler(this.Clone1_Click);
            // 
            // Clone2
            // 
            this.Clone2.Location = new System.Drawing.Point(2, 56);
            this.Clone2.Name = "Clone2";
            this.Clone2.Size = new System.Drawing.Size(100, 20);
            this.Clone2.TabIndex = 35;
            this.Clone2.Text = "Clone";
            this.HelpShow.SetToolTip(this.Clone2, "Clones the first keyword or any non-empty keyword");
            this.Clone2.UseVisualStyleBackColor = true;
            this.Clone2.Click += new System.EventHandler(this.Clone2_Click);
            // 
            // BTNClear1
            // 
            this.BTNClear1.Location = new System.Drawing.Point(108, 3);
            this.BTNClear1.Name = "BTNClear1";
            this.BTNClear1.Size = new System.Drawing.Size(100, 20);
            this.BTNClear1.TabIndex = 36;
            this.BTNClear1.Text = "Clear";
            this.HelpShow.SetToolTip(this.BTNClear1, "Clears path fields");
            this.BTNClear1.UseVisualStyleBackColor = true;
            this.BTNClear1.Click += new System.EventHandler(this.BTNClear1_Click);
            // 
            // BTNClear2
            // 
            this.BTNClear2.Location = new System.Drawing.Point(108, 56);
            this.BTNClear2.Name = "BTNClear2";
            this.BTNClear2.Size = new System.Drawing.Size(100, 20);
            this.BTNClear2.TabIndex = 37;
            this.BTNClear2.Text = "Clear";
            this.HelpShow.SetToolTip(this.BTNClear2, "Clears the key word fields");
            this.BTNClear2.UseVisualStyleBackColor = true;
            this.BTNClear2.Click += new System.EventHandler(this.BTNClear2_Click);
            // 
            // Notifications
            // 
            this.Notifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Notifications.Checked = true;
            this.Notifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Notifications.Location = new System.Drawing.Point(-1, 22);
            this.Notifications.Name = "Notifications";
            this.Notifications.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Notifications.Size = new System.Drawing.Size(179, 17);
            this.Notifications.TabIndex = 38;
            this.Notifications.Text = "Show notifications";
            this.HelpShow.SetToolTip(this.Notifications, "ProgressBar is broken, this alternative notifies you when copying is complete");
            this.Notifications.UseVisualStyleBackColor = true;
            // 
            // BTNinfo
            // 
            this.BTNinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNinfo.Location = new System.Drawing.Point(11, 324);
            this.BTNinfo.Name = "BTNinfo";
            this.BTNinfo.Size = new System.Drawing.Size(182, 23);
            this.BTNinfo.TabIndex = 32;
            this.BTNinfo.Text = "Info";
            this.BTNinfo.UseVisualStyleBackColor = true;
            this.BTNinfo.Click += new System.EventHandler(this.BTNinfo_Click);
            // 
            // InfoRichTextBox
            // 
            this.InfoRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.InfoRichTextBox.Location = new System.Drawing.Point(199, 246);
            this.InfoRichTextBox.Name = "InfoRichTextBox";
            this.InfoRichTextBox.ReadOnly = true;
            this.InfoRichTextBox.Size = new System.Drawing.Size(555, 102);
            this.InfoRichTextBox.TabIndex = 33;
            this.InfoRichTextBox.Text = resources.GetString("InfoRichTextBox.Text");
            this.InfoRichTextBox.Visible = false;
            // 
            // FastMenu
            // 
            this.FastMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.FastMenu.Location = new System.Drawing.Point(0, 0);
            this.FastMenu.Name = "FastMenu";
            this.FastMenu.Size = new System.Drawing.Size(978, 24);
            this.FastMenu.TabIndex = 39;
            this.FastMenu.Text = "FastMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadingSetting_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetSetting_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.Advanced);
            this.panel5.Controls.Add(this.Default);
            this.panel5.Location = new System.Drawing.Point(12, 353);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(181, 46);
            this.panel5.TabIndex = 40;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.Notifications);
            this.panel6.Controls.Add(this.ResetSetting);
            this.panel6.Controls.Add(this.Apply);
            this.panel6.Controls.Add(this.Close);
            this.panel6.Controls.Add(this.Stop);
            this.panel6.Controls.Add(this.SaveSetting);
            this.panel6.Controls.Add(this.LoadingSetting);
            this.panel6.Controls.Add(this.AutoLoading);
            this.panel6.Controls.Add(this.AutoCheck);
            this.panel6.Location = new System.Drawing.Point(579, 405);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(393, 91);
            this.panel6.TabIndex = 41;
            // 
            // ModePanel
            // 
            this.ModePanel.Controls.Add(this.BTNClear2);
            this.ModePanel.Controls.Add(this.BTNClear1);
            this.ModePanel.Controls.Add(this.Clone1);
            this.ModePanel.Controls.Add(this.Clone2);
            this.ModePanel.Location = new System.Drawing.Point(757, 62);
            this.ModePanel.Name = "ModePanel";
            this.ModePanel.Size = new System.Drawing.Size(214, 87);
            this.ModePanel.TabIndex = 42;
            // 
            // NewOne_way
            // 
            this.NewOne_way.Cue = "Where to move";
            this.NewOne_way.Location = new System.Drawing.Point(11, 65);
            this.NewOne_way.Name = "NewOne_way";
            this.NewOne_way.Size = new System.Drawing.Size(181, 20);
            this.NewOne_way.TabIndex = 43;
            this.NewOne_way.TextChanged += new System.EventHandler(this.One_way_TextChanged);
            // 
            // NewSource_way
            // 
            this.NewSource_way.Cue = "The path to the folder in which the scan occurs. Example C:\\My Folder";
            this.NewSource_way.Location = new System.Drawing.Point(198, 374);
            this.NewSource_way.Name = "NewSource_way";
            this.NewSource_way.Size = new System.Drawing.Size(100, 20);
            this.NewSource_way.TabIndex = 44;
            // 
            // Magic_Copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(978, 521);
            this.Controls.Add(this.NewSource_way);
            this.Controls.Add(this.NewOne_way);
            this.Controls.Add(this.InfoRichTextBox);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.BTNinfo);
            this.Controls.Add(this.DefaultPanel);
            this.Controls.Add(this.AdvancedDeletePanel);
            this.Controls.Add(this.What);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Key_Four);
            this.Controls.Add(this.Key_Three);
            this.Controls.Add(this.Key_Two);
            this.Controls.Add(this.Key_One);
            this.Controls.Add(this.Source_way);
            this.Controls.Add(this.Four_way);
            this.Controls.Add(this.Three_way);
            this.Controls.Add(this.Two_way);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.Four);
            this.Controls.Add(this.Three);
            this.Controls.Add(this.Two);
            this.Controls.Add(this.One);
            this.Controls.Add(this.FastMenu);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.ModePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.FastMenu;
            this.Name = "Magic_Copy";
            this.Text = "Magic Copy";
            this.Load += new System.EventHandler(this.MagicCopy_Load);
            this.AdvancedDeletePanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.DefaultPanel.ResumeLayout(false);
            this.DefaultPanel.PerformLayout();
            this.Language.ResumeLayout(false);
            this.Language.PerformLayout();
            this.FastMenu.ResumeLayout(false);
            this.FastMenu.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ModePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button One;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button Three;
        private System.Windows.Forms.Button Four;
        private System.Windows.Forms.Button Source;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.TextBox Two_way;
        private System.Windows.Forms.TextBox Three_way;
        private System.Windows.Forms.TextBox Four_way;
        private System.Windows.Forms.TextBox Source_way;
        private System.Windows.Forms.TextBox Key_One;
        private System.Windows.Forms.TextBox Key_Two;
        private System.Windows.Forms.TextBox Key_Three;
        private System.Windows.Forms.TextBox Key_Four;
        private new System.Windows.Forms.Button Close;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label What;
        private System.Windows.Forms.RadioButton Default;
        private System.Windows.Forms.RadioButton Advanced;
        private System.Windows.Forms.Panel AdvancedDeletePanel;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.RadioButton DeleteOriginal1;
        private System.Windows.Forms.RadioButton CopyOnce4;
        private System.Windows.Forms.RadioButton DeleteOriginal4;
        private System.Windows.Forms.RadioButton CopyOnce3;
        private System.Windows.Forms.RadioButton DeleteOriginal3;
        private System.Windows.Forms.RadioButton AnotherTest3;
        private System.Windows.Forms.RadioButton CopyOnce2;
        private System.Windows.Forms.RadioButton AnotherTest2;
        private System.Windows.Forms.RadioButton DeleteOriginal2;
        private System.Windows.Forms.RadioButton CopyOnce1;
        private System.Windows.Forms.RadioButton AnotherTest1;
        private System.Windows.Forms.Panel DefaultPanel;
        private System.Windows.Forms.RadioButton CopyOnceDefault;
        private System.Windows.Forms.RadioButton DeleteOriginalFile;
        private System.Windows.Forms.RadioButton AnotherTestDefault;
        private System.Windows.Forms.Panel Language;
        private System.Windows.Forms.RadioButton Russian;
        private System.Windows.Forms.RadioButton English;
        private System.Windows.Forms.RadioButton Ukrainian;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveSetting;
        private System.Windows.Forms.Button LoadingSetting;
        private System.Windows.Forms.CheckBox AutoLoading;
        private System.Windows.Forms.Button ResetSetting;
        private System.Windows.Forms.CheckBox AutoCheck;
        private System.Windows.Forms.RadioButton AnotherTest4;
        private System.Windows.Forms.ToolTip HelpShow;
        private System.Windows.Forms.Button BTNinfo;
        private System.Windows.Forms.RichTextBox InfoRichTextBox;
        private System.Windows.Forms.Button Clone1;
        private System.Windows.Forms.Button Clone2;
        private System.Windows.Forms.Button BTNClear1;
        private System.Windows.Forms.Button BTNClear2;
        private System.Windows.Forms.CheckBox DeleteAfterTest4;
        private System.Windows.Forms.CheckBox DeleteAfterTest3;
        private System.Windows.Forms.CheckBox DeleteAfterTest2;
        private System.Windows.Forms.CheckBox DeleteAfterTest1;
        private System.Windows.Forms.CheckBox DeleteAfterTestDefault;
        private System.Windows.Forms.CheckBox Notifications;
        private System.Windows.Forms.MenuStrip FastMenu;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel ModePanel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private CueTextBox NewOne_way;
        private CueTextBox NewSource_way;
    }
}

