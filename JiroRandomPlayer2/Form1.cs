using Microsoft.WindowsAPICodePack.Dialogs;

namespace JiroRandomPlayer2 {
    public partial class Form1 : Form {

        /// <summary>
        /// 参照フォルダ内の""""ソート前""""TJAリスト
        /// ※当アプリ起動中に確保しておく
        /// </summary>
        private List<TJA> TJAs;

        /// <summary>
        /// 設定情報
        /// </summary>
        private Setting setting;

        /// <summary>
        /// 設定が変更されたフラグ(起動時、譜面を読み込む前はtrue)
        /// 譜面を読み込む際に使う
        /// </summary>
        private bool FlgSettingChange;

        /// <summary>
        /// コンポーネントの変更をUIが行う際のフラグ
        /// </summary>
        private bool FlgChangeByUI;

        /// <summary>
        /// 当アプリのカレントディレクトリ
        /// </summary>
        private string currentDir;

        /// <summary>
        /// 当アプリの起動中に作成したTJC
        /// </summary>
        private List<string> TJCs;

        public Form1() {
            InitializeComponent();

            TJCs = new List<string>();

            //
            // カスタムNumeric(分秒用)
            //
            TnmMusicTimeMin = new TimeNumericUpDown();
            TnmMusicTimeMax = new TimeNumericUpDown();
            TnmMusicTimeMin.Location = new System.Drawing.Point(271, 81);
            TnmMusicTimeMin.Size = new System.Drawing.Size(59, 23);
            TnmMusicTimeMin.Increment = 10;
            TnmMusicTimeMin.ValueChanged += TnmMusicTimeMin_ValueChanged;
            TnmMusicTimeMax.Location = new System.Drawing.Point(358, 81);
            TnmMusicTimeMax.Size = new System.Drawing.Size(59, 23);
            TnmMusicTimeMax.Increment = 10;
            TnmMusicTimeMax.ValueChanged += TnmMusicTimeMax_ValueChanged;
            this.TabPageSortSetting.Controls.Add(TnmMusicTimeMin);
            this.TabPageSortSetting.Controls.Add(TnmMusicTimeMax);
        }


        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e) {
            this.Text = $"{Constants.AppInfo.Name} {Constants.AppInfo.Version}";

            // 起動時、タスクバーをクリックしてアプリケーションに戻らないとにアイコンが表示されない
            // 不具合を強制的に解消
            this.ShowInTaskbar = false;
            this.ShowInTaskbar = true;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // デフォルト表示は無効状態
            NmLevelMin.Enabled = false;
            NmLevelMax.Enabled = false;
            NmBPMMin.Enabled = false;
            NmBPMMax.Enabled = false;
            NmNotesMin.Enabled = false;
            NmNotesMax.Enabled = false;
            TnmMusicTimeMin.Enabled = false;
            TnmMusicTimeMax.Enabled = false;
            NmAvgDensityMin.Enabled = false;
            NmAvgDensityMax.Enabled = false;

            NmMaxMusic.Enabled = false;

            // カレントディレクトリの取得
            currentDir = AppDomain.CurrentDomain.BaseDirectory;
            FlgSettingChange = false;

            // 設定の読み込み
            setting = Setting.Read();
            getSettingValue();
        }

        /// <summary>
        /// 参照するフォルダ追加用の参照ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRef1_Click(object sender, EventArgs e) {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;
            fileDialog.Multiselect = true;
            // 参照するフォルダを複数選択してリストに追加する
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok) {
                foreach (var file in fileDialog.FileNames) {
                    ListBoxReferringFolderList.Items.Add(file);
                }
            }
            FlgSettingChange = true;
        }

        /// <summary>
        /// 除外するフォルダ追加用の参照ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRef2_Click(object sender, EventArgs e) {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;
            fileDialog.Multiselect = true;
            // 参照するフォルダを複数選択してリストに追加する
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok) {
                foreach (var file in fileDialog.FileNames) {
                    ListBoxExcludeFolderList.Items.Add(file);
                }
            }
            FlgSettingChange = true;
        }

        /// <summary>
        /// ランダム再生ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtPlay_Click(object sender, EventArgs e) {
            // TJAのリストを取得
            // 既にメモリ内にTJAのリストがある場合(参照先フォルダの変更がなされていない場合)は何もしない
            // 参照先フォルダを設定していない場合
            if (setting.RandomSetting.ReferringDirectories == null || setting.RandomSetting.ReferringDirectories.Count == 0) {
                DirectoryInfo currentDInfo = new DirectoryInfo(currentDir);
                // 当アプリの配置先が次郎フォルダじゃない場合
                if (currentDInfo.Parent.GetFiles("taikojiro.exe", SearchOption.TopDirectoryOnly).Length == 0) {
                    MessageBox.Show("譜面の参照先フォルダを設定するか、taikojiro.exeのフォルダの直下に当アプリのフォルダを格納してください。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(currentDInfo.Parent.FullName, setting);
                    FlgSettingChange = false;
                }
                // 参照先フォルダを設定している場合
            } else {
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(setting.RandomSetting.ReferringDirectories, setting);
                    FlgSettingChange = false;
                }
            }

            // プレイする
            RandomTJA.Play(TJAs, setting);
        }

        /// <summary>
        /// 選択要素の削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRefFolderDelete_Click(object sender, EventArgs e) {
            if (ListBoxReferringFolderList.Items.Count > 0 && ListBoxReferringFolderList.SelectedIndex >= 0) {
                // 削除するとその分ズレるため逆順に削除していく
                ListBox.SelectedIndexCollection selectedIndices = ListBoxReferringFolderList.SelectedIndices;
                for (int i = selectedIndices.Count - 1; i >= 0; i--) {
                    ListBoxReferringFolderList.Items.RemoveAt(selectedIndices[i]);
                }
            }
        }

        /// <summary>
        /// 選択要素の削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtExcFolderDelete_Click(object sender, EventArgs e) {
            if (ListBoxExcludeFolderList.Items.Count > 0 && ListBoxExcludeFolderList.SelectedIndex >= 0) {
                // 削除するとその分ズレるため逆順に削除していく
                ListBox.SelectedIndexCollection selectedIndices = ListBoxExcludeFolderList.SelectedIndices;
                for (int i = selectedIndices.Count - 1; i >= 0; i--) { 
                    ListBoxExcludeFolderList.Items.RemoveAt(selectedIndices[i]);
                }
            }
        }

        /// <summary>
        /// ランダム段位再生ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtCoursePlay_Click(object sender, EventArgs e) {

            if (TJAs == null) {
                TJAs = RandomTJA.GetTJAs(setting.RandomSetting.ReferringDirectories, setting);
                FlgSettingChange = false;
            }

            var MakedTJC = TJC.Play(TJAs, setting);
            if (MakedTJC == "") {
                return;
            }
            TJCs.Add(MakedTJC);
        }

        /// <summary>
        /// settingの内容をもとに画面上の設定内容を更新する
        /// </summary>
        private void getSettingValue() {

            #region ランダム譜面再生設定
            FlgChangeByUI = true;
            // Levelソート
            CbLevelSort.Checked = setting.RandomSetting.IsLevelSort;
            NmLevelMin.Value = (decimal)setting.RandomSetting.LevelMin;
            NmLevelMax.Value = (decimal)setting.RandomSetting.LevelMax;

            // BPMソート
            CbBPMSort.Checked = setting.RandomSetting.IsBPMSort;
            NmBPMMin.Value = setting.RandomSetting.BPMMin;
            NmBPMMax.Value = setting.RandomSetting.BPMMax;

            // ノーツ数ソート
            CbNotesCountSort.Checked = setting.RandomSetting.IsNotesCountSort;
            NmNotesMin.Value = setting.RandomSetting.NotesCountMin;
            NmNotesMax.Value = setting.RandomSetting.NotesCountMax;

            // 音源再生時間ソート
            CbMusicTimeSort.Checked = setting.RandomSetting.IsMusicTimeSort;
            TnmMusicTimeMin.Value = setting.RandomSetting.MusicTimeMin;
            TnmMusicTimeMax.Value = setting.RandomSetting.MusicTimeMax;

            // 平均密度ソート 
            CbAvgDensity.Checked = setting.RandomSetting.IsAvgDensitySort;
            NmAvgDensityMin.Value = (decimal)setting.RandomSetting.AvgDensityMin;
            NmAvgDensityMax.Value = (decimal)setting.RandomSetting.AvgDensityMax;

            CbSTYLE.SelectedIndex = (int)setting.RandomSetting.STYLE;

            #endregion

            #region 参照フォルダ設定
            // 参照フォルダ設定
            ListBoxReferringFolderList.Items.Clear();
            foreach (var refDir in setting.RandomSetting.ReferringDirectories) {
                ListBoxReferringFolderList.Items.Add(refDir);
            }
            // 参照フォルダ 全てのサブフォルダを参照するか
            CbSubDirRef.Checked = setting.RandomSetting.IsSubDirRef;

            // 除外フォルダ設定
            ListBoxExcludeFolderList.Items.Clear();
            foreach (var excDir in setting.RandomSetting.ExcludeDirectories) {
                ListBoxExcludeFolderList.Items.Add(excDir);
            }

            // 除外フォルダ 全てのサブフォルダを参照するか
            CbSubDirExc.Checked = setting.RandomSetting.IsSubDirExc;
            #endregion

            #region ランダム段位再生設定

            // 曲数
            NmTJCMusics.Value = setting.CourseSetting.MusicCount;

            // LIFE
            NmLife.Value = setting.CourseSetting.Life;

            // 被りを許可するか
            CbDuplicate.Checked = setting.CourseSetting.IsDuplicate;

            // アプリ終了時に段位を削除するか
            CbOldCourseDeleteIfClose.Checked = setting.CourseSetting.IsOldTJCDeleteIfClose;

            // 生成した段位の詳細情報を表示するか
            CbShowTJCInfo.Checked = setting.CourseSetting.IsShowTJCInfo;

            // ランダム段位内の曲数もランダムにするか
            CbMusicCountRandom.Checked = setting.CourseSetting.IsMusicCountRandom;

            // コース内の譜面の難易度をソートするか
            CbTJCLevelSort.Checked = setting.CourseSetting.IsLevelSort;

            // コース内難易度ソート順
            CbSortOrder.SelectedIndex = setting.CourseSetting.SortOrder;
            #endregion

            FlgChangeByUI = false;
            ShowSortedTJACount();
        }

        /// <summary>
        /// ソート情報の表示
        /// </summary>
        private void ShowSortedTJACount() {
            if (TJAs != null) {
                LbTJACount.Text = TJAs.Count().ToString();
                LbSortedTJACount.Text = RandomTJA.SortTJA(TJAs, setting).Count().ToString();
            } else {
                LbTJACount.Text = "TJAリスト未取得";
                LbSortedTJACount.Text = "TJAリスト未取得";
            }
        }

        /// <summary>
        /// 画面上の設定内容をもとにsettingを更新する
        /// </summary>
        private void setSettingValue() {
            if (FlgChangeByUI == true) { return; }
            #region ランダム選択設定
            // Levelソート
            setting.RandomSetting.IsLevelSort = CbLevelSort.Checked;
            setting.RandomSetting.LevelMin = (double)NmLevelMin.Value;
            setting.RandomSetting.LevelMax = (double)NmLevelMax.Value;
            // BPMソート
            setting.RandomSetting.IsBPMSort = CbBPMSort.Checked;
            setting.RandomSetting.BPMMin = (int)NmBPMMin.Value;
            setting.RandomSetting.BPMMax = (int)NmBPMMax.Value;
            // ノーツ数ソート
            setting.RandomSetting.IsNotesCountSort = CbNotesCountSort.Checked;
            setting.RandomSetting.NotesCountMin = (int)NmNotesMin.Value;
            setting.RandomSetting.NotesCountMax = (int)NmNotesMax.Value;
            // 音源再生時間ソート
            setting.RandomSetting.IsMusicTimeSort = CbMusicTimeSort.Checked;
            setting.RandomSetting.MusicTimeMin = (int)TnmMusicTimeMin.Value;
            setting.RandomSetting.MusicTimeMax = (int)TnmMusicTimeMax.Value;
            // 平均密度ソート
            setting.RandomSetting.IsAvgDensitySort = CbAvgDensity.Checked;
            setting.RandomSetting.AvgDensityMin = (int)NmAvgDensityMin.Value;
            setting.RandomSetting.AvgDensityMax = (int)NmAvgDensityMax.Value;

            setting.RandomSetting.STYLE = CbSTYLE.SelectedIndex == 0 ? STYLE.SP : STYLE.DP;

            // 一旦リセットしてから設定する
            setting.RandomSetting.ReferringDirectories = new List<string>();
            foreach (string path in ListBoxReferringFolderList.Items) {
                setting.RandomSetting.ReferringDirectories.Add(path);
            }
            setting.RandomSetting.IsSubDirRef = CbSubDirRef.Checked;

            setting.RandomSetting.ExcludeDirectories = new List<string>();
            foreach (string path in ListBoxExcludeFolderList.Items) {
                setting.RandomSetting.ExcludeDirectories.Add(path);
            }
            setting.RandomSetting.IsSubDirExc = CbSubDirExc.Checked;
            #endregion

            #region 段位設定
            // コース内曲数
            setting.CourseSetting.MusicCount = (int)NmTJCMusics.Value;
            // LIFE
            setting.CourseSetting.Life = (int)NmLife.Value;

            // 楽曲の被りを許可するか
            setting.CourseSetting.IsDuplicate = CbDuplicate.Checked;
            // 段位内曲数もランダムにするか
            setting.CourseSetting.IsMusicCountRandom = CbMusicCountRandom.Checked;
            // コース内曲数の最大曲数(ランダム時)
            setting.CourseSetting.CourseMusicMax = (int)NmMaxMusic.Value;
            // アプリ終了時ランダム段位ファイル削除するか
            setting.CourseSetting.IsOldTJCDeleteIfClose = CbOldCourseDeleteIfClose.Checked;
            // 段位再生前に段位の詳細を表示するか
            setting.CourseSetting.IsShowTJCInfo = CbShowTJCInfo.Checked;
            // 段位内の画面の難易度をソートするか
            setting.CourseSetting.IsLevelSort = CbTJCLevelSort.Checked;
            // コース内難易度のソート順
            setting.CourseSetting.SortOrder = CbSortOrder.SelectedIndex;
            #endregion

        }

        /// <summary>
        /// 設定タブの表示画面が変わったとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabSetting_SelectedIndexChanged(object sender, EventArgs e) {
            // 画面上の設定内容をもとにsettingを更新する
            setSettingValue();
            // 設定内容を保存する
            Setting.Write(setting);

            getSettingValue();
        }

        /// <summary>
        /// 難易度ソートの有効無効切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbLevelSort_CheckedChanged(object sender, EventArgs e) {
            if (CbLevelSort.Checked == true) {
                NmLevelMin.Enabled = true;
                NmLevelMax.Enabled = true;
            } else {
                NmLevelMin.Enabled = false;
                NmLevelMax.Enabled = false;
            }
            setSettingValue();
            ShowSortedTJACount();
        }

        /// <summary>
        /// BPMソートの有効無効切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbBPMSort_CheckedChanged(object sender, EventArgs e) {
            if (CbBPMSort.Checked == true) {
                NmBPMMin.Enabled = true;
                NmBPMMax.Enabled = true;
            } else {
                NmBPMMin.Enabled = false;
                NmBPMMax.Enabled = false;
            }
            setSettingValue();
            ShowSortedTJACount();
        }

        private void CbNotesCountSort_CheckedChanged(object sender, EventArgs e) {
            if (CbNotesCountSort.Checked == true) {
                NmNotesMin.Enabled = true;
                NmNotesMax.Enabled = true;
            } else {
                NmNotesMin.Enabled = false;
                NmNotesMax.Enabled = false;
            }
            setSettingValue();
            ShowSortedTJACount();
        }

        private void CbMusicTimeSort_CheckedChanged(object sender, EventArgs e) {
            if (CbMusicTimeSort.Checked == true) {
                TnmMusicTimeMin.Enabled = true;
                TnmMusicTimeMax.Enabled = true;
            } else {
                TnmMusicTimeMin.Enabled = false;
                TnmMusicTimeMax.Enabled = false;
            }
            setSettingValue();
            ShowSortedTJACount();
        }

        private void CbAvgDensity_CheckedChanged(object sender, EventArgs e) {
            if (CbAvgDensity.Checked == true) {
                NmAvgDensityMin.Enabled = true;
                NmAvgDensityMax.Enabled = true;
            } else {
                NmAvgDensityMin.Enabled = false;
                NmAvgDensityMax.Enabled = false;
            }
            setSettingValue();
            ShowSortedTJACount();
        }

        #region 各条件の最大値、最小値を更新する
        private void NmLevelMin_ValueChanged(object sender, EventArgs e) {
            NmLevelMax.Minimum = NmLevelMin.Value;
            NmLevelMin.Maximum = NmLevelMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void NmLevelMax_ValueChanged(object sender, EventArgs e) {
            NmLevelMax.Minimum = NmLevelMin.Value;
            NmLevelMin.Maximum = NmLevelMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void NmBPMMin_ValueChanged(object sender, EventArgs e) {
            NmBPMMax.Minimum = NmBPMMin.Value;
            NmBPMMin.Maximum = NmBPMMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void NmBPMMax_ValueChanged(object sender, EventArgs e) {
            NmBPMMax.Minimum = NmBPMMin.Value;
            NmBPMMin.Maximum = NmBPMMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void NmNotesMin_ValueChanged(object sender, EventArgs e) {
            NmNotesMax.Minimum = NmNotesMin.Value;
            NmNotesMin.Maximum = NmNotesMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void NmNotesMax_ValueChanged(object sender, EventArgs e) {
            NmNotesMax.Minimum = NmNotesMin.Value;
            NmNotesMin.Maximum = NmNotesMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void TnmMusicTimeMax_ValueChanged(object? sender, EventArgs e) {
            TnmMusicTimeMax.Minimum = TnmMusicTimeMin.Value;
            TnmMusicTimeMin.Maximum = TnmMusicTimeMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void TnmMusicTimeMin_ValueChanged(object? sender, EventArgs e) {
            TnmMusicTimeMax.Minimum = TnmMusicTimeMin.Value;
            TnmMusicTimeMin.Maximum = TnmMusicTimeMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void NmAvgDensityMin_ValueChanged(object sender, EventArgs e) {
            NmAvgDensityMax.Minimum = NmAvgDensityMin.Value;
            NmAvgDensityMin.Maximum = NmAvgDensityMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void NmAvgDensityMax_ValueChanged(object sender, EventArgs e) {
            NmAvgDensityMax.Minimum = NmAvgDensityMin.Value;
            NmAvgDensityMin.Maximum = NmAvgDensityMax.Value;
            setSettingValue();
            ShowSortedTJACount();
        }
        #endregion

        private void CbSTYLE_SelectedIndexChanged(object sender, EventArgs e) {
            setSettingValue();
            ShowSortedTJACount();
        }

        private void ListBoxReferringFolderList_ControlAdded(object sender, ControlEventArgs e) {
            if (FlgChangeByUI == false) FlgSettingChange = true;
            setSettingValue();
            ShowSortedTJACount();
        }

        private void ListBoxReferringFolderList_ControlRemoved(object sender, ControlEventArgs e) {
            if (FlgChangeByUI == false) FlgSettingChange = true;
            setSettingValue();
            ShowSortedTJACount();
        }

        /// <summary>
        /// フォームを閉じる際の挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (setting.CourseSetting.IsOldTJCDeleteIfClose == true) {
                // 作成したtjcの削除
                foreach (var tjc in TJCs) {
                    if (File.Exists(tjc)) {
                        File.Delete(tjc);
                    }
                }
            }
        }

        private void BtTJARead_Click(object sender, EventArgs e) {
            // TJAのリストを取得
            // 既にメモリ内にTJAのリストがある場合(参照先フォルダの変更がなされていない場合)は何もしない
            // 参照先フォルダを設定していない場合
            if (setting.RandomSetting.ReferringDirectories == null || setting.RandomSetting.ReferringDirectories.Count == 0) {
                DirectoryInfo currentDInfo = new DirectoryInfo(currentDir);
                // 当アプリの配置先が次郎フォルダじゃない場合
                if (currentDInfo.Parent.GetFiles("taikojiro.exe", SearchOption.TopDirectoryOnly).Length == 0) {
                    MessageBox.Show("譜面の参照先フォルダを設定するか、taikojiro.exeのフォルダの直下に当アプリのフォルダを格納してください。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(currentDInfo.Parent.FullName, setting);
                    FlgSettingChange = false;
                }
                // 参照先フォルダを設定している場合
            } else {
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(setting.RandomSetting.ReferringDirectories, setting);
                    FlgSettingChange = false;
                }
            }

            ShowSortedTJACount();
        }

        private void TabMain_SelectedIndexChanged(object sender, EventArgs e) {
            // 画面上の設定内容をもとにsettingを更新する
            setSettingValue();
            // 設定内容を保存する
            Setting.Write(setting);

            getSettingValue();
        }

        /// <summary>
        /// 楽曲数ランダム有効無効切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbMusicCountRandom_CheckedChanged(object sender, EventArgs e) {
            if (CbMusicCountRandom.Checked == true) {
                NmMaxMusic.Enabled = true;
            } else {
                NmMaxMusic.Enabled = false;
            }
        }

        private void Form1_Shown(object sender, EventArgs e) {

        }

        private void CbSubDirRef_CheckedChanged(object sender, EventArgs e) {
            FlgSettingChange = true;
        }
    }
}
