namespace JiroRandomPlayer2 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TabMain = new TabControl();
            TabPagePlay = new TabPage();
            BtPlay = new Button();
            TabPagePlayCourse = new TabPage();
            BtCoursePlay = new Button();
            TabPageSettingMain = new TabPage();
            TabSetting = new TabControl();
            TabPageSortSetting = new TabPage();
            LbElapseTime = new Label();
            BtTJARead = new Button();
            NmBPMMax = new NumericUpDown();
            label14 = new Label();
            NmAvgDensityMax = new NumericUpDown();
            NmAvgDensityMin = new NumericUpDown();
            label13 = new Label();
            label11 = new Label();
            NmNotesMax = new NumericUpDown();
            NmNotesMin = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            NmBPMMin = new NumericUpDown();
            NmLevelMax = new NumericUpDown();
            NmLevelMin = new NumericUpDown();
            LbSortedTJACount = new Label();
            label7 = new Label();
            CbSTYLE = new ComboBox();
            LbTJACount = new Label();
            label5 = new Label();
            CbAvgDensity = new CheckBox();
            CbLevelSort = new CheckBox();
            CbBPMSort = new CheckBox();
            CbNotesCountSort = new CheckBox();
            CbMusicTimeSort = new CheckBox();
            TabPageRandomTJC = new TabPage();
            CbSubDirExc = new CheckBox();
            CbSubDirRef = new CheckBox();
            BtExcFolderDelete = new Button();
            BtRefFolderDelete = new Button();
            BtRef2 = new Button();
            BtRef1 = new Button();
            ListBoxExcludeFolderList = new ListBox();
            label4 = new Label();
            ListBoxReferringFolderList = new ListBox();
            label3 = new Label();
            tabPage1 = new TabPage();
            NmMaxMusic = new NumericUpDown();
            label12 = new Label();
            CbSortOrder = new ComboBox();
            CbTJCLevelSort = new CheckBox();
            CbDuplicate = new CheckBox();
            CbShowTJCInfo = new CheckBox();
            CbOldCourseDeleteIfClose = new CheckBox();
            CbMusicCountRandom = new CheckBox();
            NmLife = new NumericUpDown();
            label2 = new Label();
            NmTJCMusics = new NumericUpDown();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            PbReadTJA = new ToolStripProgressBar();
            TabMain.SuspendLayout();
            TabPagePlay.SuspendLayout();
            TabPagePlayCourse.SuspendLayout();
            TabPageSettingMain.SuspendLayout();
            TabSetting.SuspendLayout();
            TabPageSortSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NmBPMMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmAvgDensityMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmAvgDensityMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmNotesMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmNotesMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmBPMMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmLevelMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmLevelMin).BeginInit();
            TabPageRandomTJC.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NmMaxMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmLife).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NmTJCMusics).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TabMain
            // 
            TabMain.Controls.Add(TabPagePlay);
            TabMain.Controls.Add(TabPagePlayCourse);
            TabMain.Controls.Add(TabPageSettingMain);
            TabMain.Location = new Point(12, 12);
            TabMain.Name = "TabMain";
            TabMain.SelectedIndex = 0;
            TabMain.Size = new Size(451, 382);
            TabMain.TabIndex = 0;
            TabMain.SelectedIndexChanged += TabMain_SelectedIndexChanged;
            // 
            // TabPagePlay
            // 
            TabPagePlay.Controls.Add(BtPlay);
            TabPagePlay.Location = new Point(4, 24);
            TabPagePlay.Name = "TabPagePlay";
            TabPagePlay.Padding = new Padding(3);
            TabPagePlay.Size = new Size(443, 354);
            TabPagePlay.TabIndex = 0;
            TabPagePlay.Text = "ランダム再生";
            TabPagePlay.UseVisualStyleBackColor = true;
            // 
            // BtPlay
            // 
            BtPlay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtPlay.Font = new Font("Yu Gothic UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 128);
            BtPlay.Location = new Point(6, 6);
            BtPlay.Name = "BtPlay";
            BtPlay.Size = new Size(431, 342);
            BtPlay.TabIndex = 0;
            BtPlay.Text = "譜面再生";
            BtPlay.UseVisualStyleBackColor = true;
            BtPlay.Click += BtPlay_Click;
            // 
            // TabPagePlayCourse
            // 
            TabPagePlayCourse.Controls.Add(BtCoursePlay);
            TabPagePlayCourse.Location = new Point(4, 24);
            TabPagePlayCourse.Name = "TabPagePlayCourse";
            TabPagePlayCourse.Padding = new Padding(3);
            TabPagePlayCourse.Size = new Size(443, 354);
            TabPagePlayCourse.TabIndex = 1;
            TabPagePlayCourse.Text = "ランダム段位再生";
            TabPagePlayCourse.UseVisualStyleBackColor = true;
            // 
            // BtCoursePlay
            // 
            BtCoursePlay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtCoursePlay.Font = new Font("Yu Gothic UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 128);
            BtCoursePlay.Location = new Point(6, 6);
            BtCoursePlay.Name = "BtCoursePlay";
            BtCoursePlay.Size = new Size(431, 342);
            BtCoursePlay.TabIndex = 1;
            BtCoursePlay.Text = "段位再生";
            BtCoursePlay.UseVisualStyleBackColor = true;
            BtCoursePlay.Click += BtCoursePlay_Click;
            // 
            // TabPageSettingMain
            // 
            TabPageSettingMain.Controls.Add(TabSetting);
            TabPageSettingMain.Location = new Point(4, 24);
            TabPageSettingMain.Name = "TabPageSettingMain";
            TabPageSettingMain.Padding = new Padding(3);
            TabPageSettingMain.Size = new Size(443, 354);
            TabPageSettingMain.TabIndex = 2;
            TabPageSettingMain.Text = "設定";
            TabPageSettingMain.UseVisualStyleBackColor = true;
            // 
            // TabSetting
            // 
            TabSetting.Controls.Add(TabPageSortSetting);
            TabSetting.Controls.Add(TabPageRandomTJC);
            TabSetting.Controls.Add(tabPage1);
            TabSetting.Location = new Point(6, 6);
            TabSetting.Name = "TabSetting";
            TabSetting.SelectedIndex = 0;
            TabSetting.Size = new Size(431, 342);
            TabSetting.TabIndex = 5;
            TabSetting.SelectedIndexChanged += TabSetting_SelectedIndexChanged;
            // 
            // TabPageSortSetting
            // 
            TabPageSortSetting.Controls.Add(LbElapseTime);
            TabPageSortSetting.Controls.Add(BtTJARead);
            TabPageSortSetting.Controls.Add(NmBPMMax);
            TabPageSortSetting.Controls.Add(label14);
            TabPageSortSetting.Controls.Add(NmAvgDensityMax);
            TabPageSortSetting.Controls.Add(NmAvgDensityMin);
            TabPageSortSetting.Controls.Add(label13);
            TabPageSortSetting.Controls.Add(label11);
            TabPageSortSetting.Controls.Add(NmNotesMax);
            TabPageSortSetting.Controls.Add(NmNotesMin);
            TabPageSortSetting.Controls.Add(label10);
            TabPageSortSetting.Controls.Add(label9);
            TabPageSortSetting.Controls.Add(label8);
            TabPageSortSetting.Controls.Add(NmBPMMin);
            TabPageSortSetting.Controls.Add(NmLevelMax);
            TabPageSortSetting.Controls.Add(NmLevelMin);
            TabPageSortSetting.Controls.Add(LbSortedTJACount);
            TabPageSortSetting.Controls.Add(label7);
            TabPageSortSetting.Controls.Add(CbSTYLE);
            TabPageSortSetting.Controls.Add(LbTJACount);
            TabPageSortSetting.Controls.Add(label5);
            TabPageSortSetting.Controls.Add(CbAvgDensity);
            TabPageSortSetting.Controls.Add(CbLevelSort);
            TabPageSortSetting.Controls.Add(CbBPMSort);
            TabPageSortSetting.Controls.Add(CbNotesCountSort);
            TabPageSortSetting.Controls.Add(CbMusicTimeSort);
            TabPageSortSetting.Location = new Point(4, 24);
            TabPageSortSetting.Name = "TabPageSortSetting";
            TabPageSortSetting.Padding = new Padding(3);
            TabPageSortSetting.Size = new Size(423, 314);
            TabPageSortSetting.TabIndex = 0;
            TabPageSortSetting.Text = "譜面ソート";
            TabPageSortSetting.UseVisualStyleBackColor = true;
            // 
            // LbElapseTime
            // 
            LbElapseTime.AutoSize = true;
            LbElapseTime.Location = new Point(6, 293);
            LbElapseTime.Name = "LbElapseTime";
            LbElapseTime.Size = new Size(67, 15);
            LbElapseTime.TabIndex = 33;
            LbElapseTime.Text = "経過時間：";
            // 
            // BtTJARead
            // 
            BtTJARead.Location = new Point(282, 252);
            BtTJARead.Name = "BtTJARead";
            BtTJARead.Size = new Size(135, 56);
            BtTJARead.TabIndex = 32;
            BtTJARead.Text = "対象TJA事前読み込み";
            BtTJARead.UseVisualStyleBackColor = true;
            BtTJARead.Click += BtTJARead_Click;
            // 
            // NmBPMMax
            // 
            NmBPMMax.Location = new Point(358, 31);
            NmBPMMax.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            NmBPMMax.Name = "NmBPMMax";
            NmBPMMax.Size = new Size(59, 23);
            NmBPMMax.TabIndex = 31;
            NmBPMMax.Value = new decimal(new int[] { 180, 0, 0, 0 });
            NmBPMMax.ValueChanged += NmBPMMax_ValueChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(333, 111);
            label14.Name = "label14";
            label14.Size = new Size(19, 15);
            label14.TabIndex = 30;
            label14.Text = "～";
            // 
            // NmAvgDensityMax
            // 
            NmAvgDensityMax.DecimalPlaces = 3;
            NmAvgDensityMax.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NmAvgDensityMax.Location = new Point(358, 106);
            NmAvgDensityMax.Maximum = new decimal(new int[] { 99999, 0, 0, 196608 });
            NmAvgDensityMax.Name = "NmAvgDensityMax";
            NmAvgDensityMax.Size = new Size(59, 23);
            NmAvgDensityMax.TabIndex = 29;
            NmAvgDensityMax.Value = new decimal(new int[] { 5, 0, 0, 0 });
            NmAvgDensityMax.ValueChanged += NmAvgDensityMax_ValueChanged;
            // 
            // NmAvgDensityMin
            // 
            NmAvgDensityMin.DecimalPlaces = 3;
            NmAvgDensityMin.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NmAvgDensityMin.Location = new Point(271, 106);
            NmAvgDensityMin.Maximum = new decimal(new int[] { 99999, 0, 0, 196608 });
            NmAvgDensityMin.Name = "NmAvgDensityMin";
            NmAvgDensityMin.Size = new Size(59, 23);
            NmAvgDensityMin.TabIndex = 28;
            NmAvgDensityMin.Value = new decimal(new int[] { 3, 0, 0, 0 });
            NmAvgDensityMin.ValueChanged += NmAvgDensityMin_ValueChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(333, 86);
            label13.Name = "label13";
            label13.Size = new Size(19, 15);
            label13.TabIndex = 27;
            label13.Text = "～";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(333, 61);
            label11.Name = "label11";
            label11.Size = new Size(19, 15);
            label11.TabIndex = 26;
            label11.Text = "～";
            // 
            // NmNotesMax
            // 
            NmNotesMax.Location = new Point(358, 56);
            NmNotesMax.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NmNotesMax.Name = "NmNotesMax";
            NmNotesMax.Size = new Size(59, 23);
            NmNotesMax.TabIndex = 25;
            NmNotesMax.Value = new decimal(new int[] { 700, 0, 0, 0 });
            NmNotesMax.ValueChanged += NmNotesMax_ValueChanged;
            // 
            // NmNotesMin
            // 
            NmNotesMin.Location = new Point(271, 56);
            NmNotesMin.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NmNotesMin.Name = "NmNotesMin";
            NmNotesMin.Size = new Size(59, 23);
            NmNotesMin.TabIndex = 24;
            NmNotesMin.Value = new decimal(new int[] { 500, 0, 0, 0 });
            NmNotesMin.ValueChanged += NmNotesMin_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(333, 36);
            label10.Name = "label10";
            label10.Size = new Size(19, 15);
            label10.TabIndex = 23;
            label10.Text = "～";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(333, 11);
            label9.Name = "label9";
            label9.Size = new Size(19, 15);
            label9.TabIndex = 22;
            label9.Text = "～";
            // 
            // label8
            // 
            label8.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label8.Location = new Point(239, 6);
            label8.Name = "label8";
            label8.Size = new Size(26, 21);
            label8.TabIndex = 21;
            label8.Text = "☆";
            // 
            // NmBPMMin
            // 
            NmBPMMin.Location = new Point(271, 31);
            NmBPMMin.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            NmBPMMin.Name = "NmBPMMin";
            NmBPMMin.Size = new Size(59, 23);
            NmBPMMin.TabIndex = 19;
            NmBPMMin.Value = new decimal(new int[] { 120, 0, 0, 0 });
            NmBPMMin.ValueChanged += NmBPMMin_ValueChanged;
            // 
            // NmLevelMax
            // 
            NmLevelMax.DecimalPlaces = 1;
            NmLevelMax.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            NmLevelMax.Location = new Point(358, 6);
            NmLevelMax.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NmLevelMax.Name = "NmLevelMax";
            NmLevelMax.Size = new Size(59, 23);
            NmLevelMax.TabIndex = 18;
            NmLevelMax.Value = new decimal(new int[] { 10, 0, 0, 0 });
            NmLevelMax.ValueChanged += NmLevelMax_ValueChanged;
            // 
            // NmLevelMin
            // 
            NmLevelMin.DecimalPlaces = 1;
            NmLevelMin.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            NmLevelMin.Location = new Point(271, 6);
            NmLevelMin.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NmLevelMin.Name = "NmLevelMin";
            NmLevelMin.Size = new Size(59, 23);
            NmLevelMin.TabIndex = 17;
            NmLevelMin.Value = new decimal(new int[] { 8, 0, 0, 0 });
            NmLevelMin.ValueChanged += NmLevelMin_ValueChanged;
            // 
            // LbSortedTJACount
            // 
            LbSortedTJACount.Font = new Font("游ゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            LbSortedTJACount.Location = new Point(282, 208);
            LbSortedTJACount.Name = "LbSortedTJACount";
            LbSortedTJACount.Size = new Size(135, 21);
            LbSortedTJACount.TabIndex = 16;
            LbSortedTJACount.Text = "0";
            LbSortedTJACount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(6, 208);
            label7.Name = "label7";
            label7.Size = new Size(135, 21);
            label7.TabIndex = 15;
            label7.Text = "現在の対象譜面数";
            // 
            // CbSTYLE
            // 
            CbSTYLE.DropDownStyle = ComboBoxStyle.DropDownList;
            CbSTYLE.FormattingEnabled = true;
            CbSTYLE.Items.AddRange(new object[] { "SP", "DP" });
            CbSTYLE.Location = new Point(311, 148);
            CbSTYLE.Name = "CbSTYLE";
            CbSTYLE.Size = new Size(106, 23);
            CbSTYLE.TabIndex = 12;
            CbSTYLE.SelectedIndexChanged += CbSTYLE_SelectedIndexChanged;
            // 
            // LbTJACount
            // 
            LbTJACount.Font = new Font("游ゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            LbTJACount.Location = new Point(282, 174);
            LbTJACount.Name = "LbTJACount";
            LbTJACount.Size = new Size(135, 21);
            LbTJACount.TabIndex = 11;
            LbTJACount.Text = "0";
            LbTJACount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(6, 174);
            label5.Name = "label5";
            label5.Size = new Size(154, 21);
            label5.TabIndex = 10;
            label5.Text = "参照フォルダ内譜面数";
            // 
            // CbAvgDensity
            // 
            CbAvgDensity.AutoSize = true;
            CbAvgDensity.Enabled = false;
            CbAvgDensity.Location = new Point(6, 106);
            CbAvgDensity.Name = "CbAvgDensity";
            CbAvgDensity.Size = new Size(187, 19);
            CbAvgDensity.TabIndex = 9;
            CbAvgDensity.Text = "ノーツの平均秒間密度でソートする";
            CbAvgDensity.UseVisualStyleBackColor = true;
            CbAvgDensity.CheckedChanged += CbAvgDensity_CheckedChanged;
            // 
            // CbLevelSort
            // 
            CbLevelSort.AutoSize = true;
            CbLevelSort.Location = new Point(6, 6);
            CbLevelSort.Name = "CbLevelSort";
            CbLevelSort.Size = new Size(116, 19);
            CbLevelSort.TabIndex = 5;
            CbLevelSort.Text = "難易度でソートする";
            CbLevelSort.UseVisualStyleBackColor = true;
            CbLevelSort.CheckedChanged += CbLevelSort_CheckedChanged;
            // 
            // CbBPMSort
            // 
            CbBPMSort.AutoSize = true;
            CbBPMSort.Location = new Point(6, 31);
            CbBPMSort.Name = "CbBPMSort";
            CbBPMSort.Size = new Size(105, 19);
            CbBPMSort.TabIndex = 6;
            CbBPMSort.Text = "BPMでソートする";
            CbBPMSort.UseVisualStyleBackColor = true;
            CbBPMSort.CheckedChanged += CbBPMSort_CheckedChanged;
            // 
            // CbNotesCountSort
            // 
            CbNotesCountSort.AutoSize = true;
            CbNotesCountSort.Location = new Point(6, 56);
            CbNotesCountSort.Name = "CbNotesCountSort";
            CbNotesCountSort.Size = new Size(117, 19);
            CbNotesCountSort.TabIndex = 7;
            CbNotesCountSort.Text = "ノーツ数でソートする";
            CbNotesCountSort.UseVisualStyleBackColor = true;
            CbNotesCountSort.CheckedChanged += CbNotesCountSort_CheckedChanged;
            // 
            // CbMusicTimeSort
            // 
            CbMusicTimeSort.AutoSize = true;
            CbMusicTimeSort.Enabled = false;
            CbMusicTimeSort.Location = new Point(6, 81);
            CbMusicTimeSort.Name = "CbMusicTimeSort";
            CbMusicTimeSort.Size = new Size(128, 19);
            CbMusicTimeSort.TabIndex = 8;
            CbMusicTimeSort.Text = "再生時間でソートする";
            CbMusicTimeSort.UseVisualStyleBackColor = true;
            CbMusicTimeSort.CheckedChanged += CbMusicTimeSort_CheckedChanged;
            // 
            // TabPageRandomTJC
            // 
            TabPageRandomTJC.Controls.Add(CbSubDirExc);
            TabPageRandomTJC.Controls.Add(CbSubDirRef);
            TabPageRandomTJC.Controls.Add(BtExcFolderDelete);
            TabPageRandomTJC.Controls.Add(BtRefFolderDelete);
            TabPageRandomTJC.Controls.Add(BtRef2);
            TabPageRandomTJC.Controls.Add(BtRef1);
            TabPageRandomTJC.Controls.Add(ListBoxExcludeFolderList);
            TabPageRandomTJC.Controls.Add(label4);
            TabPageRandomTJC.Controls.Add(ListBoxReferringFolderList);
            TabPageRandomTJC.Controls.Add(label3);
            TabPageRandomTJC.Location = new Point(4, 24);
            TabPageRandomTJC.Name = "TabPageRandomTJC";
            TabPageRandomTJC.Padding = new Padding(3);
            TabPageRandomTJC.Size = new Size(423, 314);
            TabPageRandomTJC.TabIndex = 1;
            TabPageRandomTJC.Text = "参照フォルダ設定";
            TabPageRandomTJC.UseVisualStyleBackColor = true;
            // 
            // CbSubDirExc
            // 
            CbSubDirExc.AutoSize = true;
            CbSubDirExc.Location = new Point(6, 289);
            CbSubDirExc.Name = "CbSubDirExc";
            CbSubDirExc.Size = new Size(163, 19);
            CbSubDirExc.TabIndex = 9;
            CbSubDirExc.Text = "全てのサブフォルダを除外する";
            CbSubDirExc.UseVisualStyleBackColor = true;
            // 
            // CbSubDirRef
            // 
            CbSubDirRef.AutoSize = true;
            CbSubDirRef.Location = new Point(6, 136);
            CbSubDirRef.Name = "CbSubDirRef";
            CbSubDirRef.Size = new Size(163, 19);
            CbSubDirRef.TabIndex = 8;
            CbSubDirRef.Text = "全てのサブフォルダを参照する";
            CbSubDirRef.UseVisualStyleBackColor = true;
            CbSubDirRef.CheckedChanged += CbSubDirRef_CheckedChanged;
            // 
            // BtExcFolderDelete
            // 
            BtExcFolderDelete.Location = new Point(187, 285);
            BtExcFolderDelete.Name = "BtExcFolderDelete";
            BtExcFolderDelete.Size = new Size(149, 23);
            BtExcFolderDelete.TabIndex = 7;
            BtExcFolderDelete.Text = "選択した項目を削除する";
            BtExcFolderDelete.UseVisualStyleBackColor = true;
            BtExcFolderDelete.Click += BtExcFolderDelete_Click;
            // 
            // BtRefFolderDelete
            // 
            BtRefFolderDelete.Location = new Point(187, 136);
            BtRefFolderDelete.Name = "BtRefFolderDelete";
            BtRefFolderDelete.Size = new Size(149, 23);
            BtRefFolderDelete.TabIndex = 6;
            BtRefFolderDelete.Text = "選択した項目を削除する";
            BtRefFolderDelete.UseVisualStyleBackColor = true;
            BtRefFolderDelete.Click += BtRefFolderDelete_Click;
            // 
            // BtRef2
            // 
            BtRef2.Location = new Point(342, 285);
            BtRef2.Name = "BtRef2";
            BtRef2.Size = new Size(75, 23);
            BtRef2.TabIndex = 5;
            BtRef2.Text = "参照...";
            BtRef2.UseVisualStyleBackColor = true;
            BtRef2.Click += BtRef2_Click;
            // 
            // BtRef1
            // 
            BtRef1.Location = new Point(342, 136);
            BtRef1.Name = "BtRef1";
            BtRef1.Size = new Size(75, 23);
            BtRef1.TabIndex = 4;
            BtRef1.Text = "参照...";
            BtRef1.UseVisualStyleBackColor = true;
            BtRef1.Click += BtRef1_Click;
            // 
            // ListBoxExcludeFolderList
            // 
            ListBoxExcludeFolderList.FormattingEnabled = true;
            ListBoxExcludeFolderList.ItemHeight = 15;
            ListBoxExcludeFolderList.Location = new Point(6, 180);
            ListBoxExcludeFolderList.Name = "ListBoxExcludeFolderList";
            ListBoxExcludeFolderList.SelectionMode = SelectionMode.MultiExtended;
            ListBoxExcludeFolderList.Size = new Size(411, 94);
            ListBoxExcludeFolderList.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 162);
            label4.Name = "label4";
            label4.Size = new Size(144, 15);
            label4.TabIndex = 2;
            label4.Text = "上記のうち、除外するフォルダ";
            // 
            // ListBoxReferringFolderList
            // 
            ListBoxReferringFolderList.FormattingEnabled = true;
            ListBoxReferringFolderList.ItemHeight = 15;
            ListBoxReferringFolderList.Location = new Point(6, 21);
            ListBoxReferringFolderList.Name = "ListBoxReferringFolderList";
            ListBoxReferringFolderList.SelectionMode = SelectionMode.MultiExtended;
            ListBoxReferringFolderList.Size = new Size(411, 109);
            ListBoxReferringFolderList.TabIndex = 1;
            ListBoxReferringFolderList.ControlAdded += ListBoxReferringFolderList_ControlAdded;
            ListBoxReferringFolderList.ControlRemoved += ListBoxReferringFolderList_ControlRemoved;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(133, 15);
            label3.TabIndex = 0;
            label3.Text = "当アプリで参照するフォルダ";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(NmMaxMusic);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(CbSortOrder);
            tabPage1.Controls.Add(CbTJCLevelSort);
            tabPage1.Controls.Add(CbDuplicate);
            tabPage1.Controls.Add(CbShowTJCInfo);
            tabPage1.Controls.Add(CbOldCourseDeleteIfClose);
            tabPage1.Controls.Add(CbMusicCountRandom);
            tabPage1.Controls.Add(NmLife);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(NmTJCMusics);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(423, 314);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "ランダム段位";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // NmMaxMusic
            // 
            NmMaxMusic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NmMaxMusic.Location = new Point(354, 101);
            NmMaxMusic.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NmMaxMusic.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NmMaxMusic.Name = "NmMaxMusic";
            NmMaxMusic.Size = new Size(63, 23);
            NmMaxMusic.TabIndex = 12;
            NmMaxMusic.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(294, 103);
            label12.Name = "label12";
            label12.Size = new Size(55, 15);
            label12.TabIndex = 11;
            label12.Text = "最大曲数";
            // 
            // CbSortOrder
            // 
            CbSortOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            CbSortOrder.FormattingEnabled = true;
            CbSortOrder.Items.AddRange(new object[] { "昇順", "降順" });
            CbSortOrder.Location = new Point(354, 177);
            CbSortOrder.Name = "CbSortOrder";
            CbSortOrder.Size = new Size(63, 23);
            CbSortOrder.TabIndex = 10;
            // 
            // CbTJCLevelSort
            // 
            CbTJCLevelSort.AutoSize = true;
            CbTJCLevelSort.Location = new Point(6, 177);
            CbTJCLevelSort.Name = "CbTJCLevelSort";
            CbTJCLevelSort.Size = new Size(195, 19);
            CbTJCLevelSort.TabIndex = 9;
            CbTJCLevelSort.Text = "段位内の譜面の難易度をソートする";
            CbTJCLevelSort.UseVisualStyleBackColor = true;
            // 
            // CbDuplicate
            // 
            CbDuplicate.AutoSize = true;
            CbDuplicate.Location = new Point(6, 77);
            CbDuplicate.Name = "CbDuplicate";
            CbDuplicate.Size = new Size(169, 19);
            CbDuplicate.TabIndex = 8;
            CbDuplicate.Text = "コース内楽曲の被りを許可する";
            CbDuplicate.UseVisualStyleBackColor = true;
            // 
            // CbShowTJCInfo
            // 
            CbShowTJCInfo.AutoSize = true;
            CbShowTJCInfo.Location = new Point(6, 152);
            CbShowTJCInfo.Name = "CbShowTJCInfo";
            CbShowTJCInfo.Size = new Size(205, 19);
            CbShowTJCInfo.TabIndex = 7;
            CbShowTJCInfo.Text = "段位再生前に段位の詳細を表示する";
            CbShowTJCInfo.UseVisualStyleBackColor = true;
            // 
            // CbOldCourseDeleteIfClose
            // 
            CbOldCourseDeleteIfClose.AutoSize = true;
            CbOldCourseDeleteIfClose.Location = new Point(6, 127);
            CbOldCourseDeleteIfClose.Name = "CbOldCourseDeleteIfClose";
            CbOldCourseDeleteIfClose.Size = new Size(254, 19);
            CbOldCourseDeleteIfClose.TabIndex = 6;
            CbOldCourseDeleteIfClose.Text = "本アプリ終了時にランダム段位ファイルを削除する";
            CbOldCourseDeleteIfClose.UseVisualStyleBackColor = true;
            // 
            // CbMusicCountRandom
            // 
            CbMusicCountRandom.AutoSize = true;
            CbMusicCountRandom.Location = new Point(6, 102);
            CbMusicCountRandom.Name = "CbMusicCountRandom";
            CbMusicCountRandom.Size = new Size(122, 19);
            CbMusicCountRandom.TabIndex = 4;
            CbMusicCountRandom.Text = "曲数もランダムにする";
            CbMusicCountRandom.UseVisualStyleBackColor = true;
            CbMusicCountRandom.CheckedChanged += CbMusicCountRandom_CheckedChanged;
            // 
            // NmLife
            // 
            NmLife.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NmLife.Location = new Point(218, 35);
            NmLife.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NmLife.Name = "NmLife";
            NmLife.Size = new Size(199, 23);
            NmLife.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(6, 32);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "LIFE値";
            // 
            // NmTJCMusics
            // 
            NmTJCMusics.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NmTJCMusics.Location = new Point(218, 6);
            NmTJCMusics.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NmTJCMusics.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NmTJCMusics.Name = "NmTJCMusics";
            NmTJCMusics.Size = new Size(199, 23);
            NmTJCMusics.TabIndex = 1;
            NmTJCMusics.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(6, 8);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "コース内曲数";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { PbReadTJA });
            statusStrip1.Location = new Point(0, 397);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(475, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // PbReadTJA
            // 
            PbReadTJA.Name = "PbReadTJA";
            PbReadTJA.Size = new Size(460, 16);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 419);
            Controls.Add(statusStrip1);
            Controls.Add(TabMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            TopMost = true;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Shown += Form1_Shown;
            TabMain.ResumeLayout(false);
            TabPagePlay.ResumeLayout(false);
            TabPagePlayCourse.ResumeLayout(false);
            TabPageSettingMain.ResumeLayout(false);
            TabSetting.ResumeLayout(false);
            TabPageSortSetting.ResumeLayout(false);
            TabPageSortSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NmBPMMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmAvgDensityMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmAvgDensityMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmNotesMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmNotesMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmBPMMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmLevelMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmLevelMin).EndInit();
            TabPageRandomTJC.ResumeLayout(false);
            TabPageRandomTJC.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NmMaxMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmLife).EndInit();
            ((System.ComponentModel.ISupportInitialize)NmTJCMusics).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl TabMain;
        private TabPage TabPagePlay;
        private Button BtPlay;
        private TabPage TabPagePlayCourse;
        private TabPage TabPageSettingMain;
        private Button BtCoursePlay;
        private TabControl TabSetting;
        private TabPage TabPageSortSetting;
        private CheckBox CbAvgDensity;
        private CheckBox CbLevelSort;
        private CheckBox CbBPMSort;
        private CheckBox CbNotesCountSort;
        private CheckBox CbMusicTimeSort;
        private TabPage TabPageRandomTJC;
        private TabPage tabPage1;
        private CheckBox CbOldCourseDeleteIfClose;
        private CheckBox CbMusicCountRandom;
        private NumericUpDown NmLife;
        private Label label2;
        private NumericUpDown NmTJCMusics;
        private Label label1;
        private ListBox ListBoxReferringFolderList;
        private Label label3;
        private CheckBox CbDuplicate;
        private CheckBox CbShowTJCInfo;
        private Button BtRef2;
        private Button BtRef1;
        private ListBox ListBoxExcludeFolderList;
        private Label label4;
        private Label LbTJACount;
        private Label label5;
        private ComboBox CbSTYLE;
        private TimeNumericUpDown TnmMusicTimeMin;
        private TimeNumericUpDown TnmMusicTimeMax;
        private Label LbSortedTJACount;
        private Label label7;
        private Button BtExcFolderDelete;
        private Button BtRefFolderDelete;
        private Label label8;
        private NumericUpDown NmBPMMin;
        private NumericUpDown NmLevelMax;
        private NumericUpDown NmLevelMin;
        private Label label11;
        private NumericUpDown NmNotesMax;
        private NumericUpDown NmNotesMin;
        private Label label10;
        private Label label9;
        private ComboBox CbSortOrder;
        private CheckBox CbTJCLevelSort;
        private NumericUpDown NmMaxMusic;
        private Label label12;
        private Label label13;
        private Label label14;
        private NumericUpDown NmAvgDensityMax;
        private NumericUpDown NmAvgDensityMin;
        private NumericUpDown NmBPMMax;
        private Button BtTJARead;
        private CheckBox CbSubDirExc;
        private CheckBox CbSubDirRef;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar PbReadTJA;
        private Label LbElapseTime;
    }
}
