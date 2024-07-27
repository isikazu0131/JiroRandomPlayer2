using Microsoft.WindowsAPICodePack.Dialogs;

namespace JiroRandomPlayer2 {
    public partial class Form1 : Form {

        /// <summary>
        /// �Q�ƃt�H���_����""""�\�[�g�O""""TJA���X�g
        /// �����A�v���N�����Ɋm�ۂ��Ă���
        /// </summary>
        private List<TJA> TJAs;

        /// <summary>
        /// �ݒ���
        /// </summary>
        private Setting setting;

        /// <summary>
        /// �ݒ肪�ύX���ꂽ�t���O(�N�����A���ʂ�ǂݍ��ޑO��true)
        /// ���ʂ�ǂݍ��ލۂɎg��
        /// </summary>
        private bool FlgSettingChange;

        /// <summary>
        /// �R���|�[�l���g�̕ύX��UI���s���ۂ̃t���O
        /// </summary>
        private bool FlgChangeByUI;

        /// <summary>
        /// ���A�v���̃J�����g�f�B���N�g��
        /// </summary>
        private string currentDir;

        /// <summary>
        /// ���A�v���̋N�����ɍ쐬����TJC
        /// </summary>
        private List<string> TJCs;

        public Form1() {
            InitializeComponent();

            TJCs = new List<string>();

            //
            // �J�X�^��Numeric(���b�p)
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
        /// �t�H�[�����[�h���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e) {
            this.Text = $"{Constants.AppInfo.Name} {Constants.AppInfo.Version}";

            // �N�����A�^�X�N�o�[���N���b�N���ăA�v���P�[�V�����ɖ߂�Ȃ��ƂɃA�C�R�����\������Ȃ�
            // �s��������I�ɉ���
            this.ShowInTaskbar = false;
            this.ShowInTaskbar = true;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // �f�t�H���g�\���͖������
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

            // �J�����g�f�B���N�g���̎擾
            currentDir = AppDomain.CurrentDomain.BaseDirectory;
            FlgSettingChange = false;

            // �ݒ�̓ǂݍ���
            setting = Setting.Read();
            getSettingValue();
        }

        /// <summary>
        /// �Q�Ƃ���t�H���_�ǉ��p�̎Q�ƃ{�^������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRef1_Click(object sender, EventArgs e) {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;
            fileDialog.Multiselect = true;
            // �Q�Ƃ���t�H���_�𕡐��I�����ă��X�g�ɒǉ�����
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok) {
                foreach (var file in fileDialog.FileNames) {
                    ListBoxReferringFolderList.Items.Add(file);
                }
            }
            FlgSettingChange = true;
        }

        /// <summary>
        /// ���O����t�H���_�ǉ��p�̎Q�ƃ{�^������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRef2_Click(object sender, EventArgs e) {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;
            fileDialog.Multiselect = true;
            // �Q�Ƃ���t�H���_�𕡐��I�����ă��X�g�ɒǉ�����
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok) {
                foreach (var file in fileDialog.FileNames) {
                    ListBoxExcludeFolderList.Items.Add(file);
                }
            }
            FlgSettingChange = true;
        }

        /// <summary>
        /// �����_���Đ��{�^������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtPlay_Click(object sender, EventArgs e) {
            // TJA�̃��X�g���擾
            // ���Ƀ���������TJA�̃��X�g������ꍇ(�Q�Ɛ�t�H���_�̕ύX���Ȃ���Ă��Ȃ��ꍇ)�͉������Ȃ�
            // �Q�Ɛ�t�H���_��ݒ肵�Ă��Ȃ��ꍇ
            if (setting.RandomSetting.ReferringDirectories == null || setting.RandomSetting.ReferringDirectories.Count == 0) {
                DirectoryInfo currentDInfo = new DirectoryInfo(currentDir);
                // ���A�v���̔z�u�悪���Y�t�H���_����Ȃ��ꍇ
                if (currentDInfo.Parent.GetFiles("taikojiro.exe", SearchOption.TopDirectoryOnly).Length == 0) {
                    MessageBox.Show("���ʂ̎Q�Ɛ�t�H���_��ݒ肷�邩�Ataikojiro.exe�̃t�H���_�̒����ɓ��A�v���̃t�H���_���i�[���Ă��������B", "����˂�", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(currentDInfo.Parent.FullName, setting);
                    FlgSettingChange = false;
                }
                // �Q�Ɛ�t�H���_��ݒ肵�Ă���ꍇ
            } else {
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(setting.RandomSetting.ReferringDirectories, setting);
                    FlgSettingChange = false;
                }
            }

            // �v���C����
            RandomTJA.Play(TJAs, setting);
        }

        /// <summary>
        /// �I��v�f�̍폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtRefFolderDelete_Click(object sender, EventArgs e) {
            if (ListBoxReferringFolderList.Items.Count > 0 && ListBoxReferringFolderList.SelectedIndex >= 0) {
                // �폜����Ƃ��̕��Y���邽�ߋt���ɍ폜���Ă���
                ListBox.SelectedIndexCollection selectedIndices = ListBoxReferringFolderList.SelectedIndices;
                for (int i = selectedIndices.Count - 1; i >= 0; i--) {
                    ListBoxReferringFolderList.Items.RemoveAt(selectedIndices[i]);
                }
            }
        }

        /// <summary>
        /// �I��v�f�̍폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtExcFolderDelete_Click(object sender, EventArgs e) {
            if (ListBoxExcludeFolderList.Items.Count > 0 && ListBoxExcludeFolderList.SelectedIndex >= 0) {
                // �폜����Ƃ��̕��Y���邽�ߋt���ɍ폜���Ă���
                ListBox.SelectedIndexCollection selectedIndices = ListBoxExcludeFolderList.SelectedIndices;
                for (int i = selectedIndices.Count - 1; i >= 0; i--) { 
                    ListBoxExcludeFolderList.Items.RemoveAt(selectedIndices[i]);
                }
            }
        }

        /// <summary>
        /// �����_���i�ʍĐ��{�^������
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
        /// setting�̓��e�����Ƃɉ�ʏ�̐ݒ���e���X�V����
        /// </summary>
        private void getSettingValue() {

            #region �����_�����ʍĐ��ݒ�
            FlgChangeByUI = true;
            // Level�\�[�g
            CbLevelSort.Checked = setting.RandomSetting.IsLevelSort;
            NmLevelMin.Value = (decimal)setting.RandomSetting.LevelMin;
            NmLevelMax.Value = (decimal)setting.RandomSetting.LevelMax;

            // BPM�\�[�g
            CbBPMSort.Checked = setting.RandomSetting.IsBPMSort;
            NmBPMMin.Value = setting.RandomSetting.BPMMin;
            NmBPMMax.Value = setting.RandomSetting.BPMMax;

            // �m�[�c���\�[�g
            CbNotesCountSort.Checked = setting.RandomSetting.IsNotesCountSort;
            NmNotesMin.Value = setting.RandomSetting.NotesCountMin;
            NmNotesMax.Value = setting.RandomSetting.NotesCountMax;

            // �����Đ����ԃ\�[�g
            CbMusicTimeSort.Checked = setting.RandomSetting.IsMusicTimeSort;
            TnmMusicTimeMin.Value = setting.RandomSetting.MusicTimeMin;
            TnmMusicTimeMax.Value = setting.RandomSetting.MusicTimeMax;

            // ���ϖ��x�\�[�g 
            CbAvgDensity.Checked = setting.RandomSetting.IsAvgDensitySort;
            NmAvgDensityMin.Value = (decimal)setting.RandomSetting.AvgDensityMin;
            NmAvgDensityMax.Value = (decimal)setting.RandomSetting.AvgDensityMax;

            CbSTYLE.SelectedIndex = (int)setting.RandomSetting.STYLE;

            #endregion

            #region �Q�ƃt�H���_�ݒ�
            // �Q�ƃt�H���_�ݒ�
            ListBoxReferringFolderList.Items.Clear();
            foreach (var refDir in setting.RandomSetting.ReferringDirectories) {
                ListBoxReferringFolderList.Items.Add(refDir);
            }
            // �Q�ƃt�H���_ �S�ẴT�u�t�H���_���Q�Ƃ��邩
            CbSubDirRef.Checked = setting.RandomSetting.IsSubDirRef;

            // ���O�t�H���_�ݒ�
            ListBoxExcludeFolderList.Items.Clear();
            foreach (var excDir in setting.RandomSetting.ExcludeDirectories) {
                ListBoxExcludeFolderList.Items.Add(excDir);
            }

            // ���O�t�H���_ �S�ẴT�u�t�H���_���Q�Ƃ��邩
            CbSubDirExc.Checked = setting.RandomSetting.IsSubDirExc;
            #endregion

            #region �����_���i�ʍĐ��ݒ�

            // �Ȑ�
            NmTJCMusics.Value = setting.CourseSetting.MusicCount;

            // LIFE
            NmLife.Value = setting.CourseSetting.Life;

            // ���������邩
            CbDuplicate.Checked = setting.CourseSetting.IsDuplicate;

            // �A�v���I�����ɒi�ʂ��폜���邩
            CbOldCourseDeleteIfClose.Checked = setting.CourseSetting.IsOldTJCDeleteIfClose;

            // ���������i�ʂ̏ڍ׏���\�����邩
            CbShowTJCInfo.Checked = setting.CourseSetting.IsShowTJCInfo;

            // �����_���i�ʓ��̋Ȑ��������_���ɂ��邩
            CbMusicCountRandom.Checked = setting.CourseSetting.IsMusicCountRandom;

            // �R�[�X���̕��ʂ̓�Փx���\�[�g���邩
            CbTJCLevelSort.Checked = setting.CourseSetting.IsLevelSort;

            // �R�[�X����Փx�\�[�g��
            CbSortOrder.SelectedIndex = setting.CourseSetting.SortOrder;
            #endregion

            FlgChangeByUI = false;
            ShowSortedTJACount();
        }

        /// <summary>
        /// �\�[�g���̕\��
        /// </summary>
        private void ShowSortedTJACount() {
            if (TJAs != null) {
                LbTJACount.Text = TJAs.Count().ToString();
                LbSortedTJACount.Text = RandomTJA.SortTJA(TJAs, setting).Count().ToString();
            } else {
                LbTJACount.Text = "TJA���X�g���擾";
                LbSortedTJACount.Text = "TJA���X�g���擾";
            }
        }

        /// <summary>
        /// ��ʏ�̐ݒ���e�����Ƃ�setting���X�V����
        /// </summary>
        private void setSettingValue() {
            if (FlgChangeByUI == true) { return; }
            #region �����_���I��ݒ�
            // Level�\�[�g
            setting.RandomSetting.IsLevelSort = CbLevelSort.Checked;
            setting.RandomSetting.LevelMin = (double)NmLevelMin.Value;
            setting.RandomSetting.LevelMax = (double)NmLevelMax.Value;
            // BPM�\�[�g
            setting.RandomSetting.IsBPMSort = CbBPMSort.Checked;
            setting.RandomSetting.BPMMin = (int)NmBPMMin.Value;
            setting.RandomSetting.BPMMax = (int)NmBPMMax.Value;
            // �m�[�c���\�[�g
            setting.RandomSetting.IsNotesCountSort = CbNotesCountSort.Checked;
            setting.RandomSetting.NotesCountMin = (int)NmNotesMin.Value;
            setting.RandomSetting.NotesCountMax = (int)NmNotesMax.Value;
            // �����Đ����ԃ\�[�g
            setting.RandomSetting.IsMusicTimeSort = CbMusicTimeSort.Checked;
            setting.RandomSetting.MusicTimeMin = (int)TnmMusicTimeMin.Value;
            setting.RandomSetting.MusicTimeMax = (int)TnmMusicTimeMax.Value;
            // ���ϖ��x�\�[�g
            setting.RandomSetting.IsAvgDensitySort = CbAvgDensity.Checked;
            setting.RandomSetting.AvgDensityMin = (int)NmAvgDensityMin.Value;
            setting.RandomSetting.AvgDensityMax = (int)NmAvgDensityMax.Value;

            setting.RandomSetting.STYLE = CbSTYLE.SelectedIndex == 0 ? STYLE.SP : STYLE.DP;

            // ��U���Z�b�g���Ă���ݒ肷��
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

            #region �i�ʐݒ�
            // �R�[�X���Ȑ�
            setting.CourseSetting.MusicCount = (int)NmTJCMusics.Value;
            // LIFE
            setting.CourseSetting.Life = (int)NmLife.Value;

            // �y�Ȃ̔��������邩
            setting.CourseSetting.IsDuplicate = CbDuplicate.Checked;
            // �i�ʓ��Ȑ��������_���ɂ��邩
            setting.CourseSetting.IsMusicCountRandom = CbMusicCountRandom.Checked;
            // �R�[�X���Ȑ��̍ő�Ȑ�(�����_����)
            setting.CourseSetting.CourseMusicMax = (int)NmMaxMusic.Value;
            // �A�v���I���������_���i�ʃt�@�C���폜���邩
            setting.CourseSetting.IsOldTJCDeleteIfClose = CbOldCourseDeleteIfClose.Checked;
            // �i�ʍĐ��O�ɒi�ʂ̏ڍׂ�\�����邩
            setting.CourseSetting.IsShowTJCInfo = CbShowTJCInfo.Checked;
            // �i�ʓ��̉�ʂ̓�Փx���\�[�g���邩
            setting.CourseSetting.IsLevelSort = CbTJCLevelSort.Checked;
            // �R�[�X����Փx�̃\�[�g��
            setting.CourseSetting.SortOrder = CbSortOrder.SelectedIndex;
            #endregion

        }

        /// <summary>
        /// �ݒ�^�u�̕\����ʂ��ς�����Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabSetting_SelectedIndexChanged(object sender, EventArgs e) {
            // ��ʏ�̐ݒ���e�����Ƃ�setting���X�V����
            setSettingValue();
            // �ݒ���e��ۑ�����
            Setting.Write(setting);

            getSettingValue();
        }

        /// <summary>
        /// ��Փx�\�[�g�̗L�������؂�ւ�
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
        /// BPM�\�[�g�̗L�������؂�ւ�
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

        #region �e�����̍ő�l�A�ŏ��l���X�V����
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
        /// �t�H�[�������ۂ̋���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (setting.CourseSetting.IsOldTJCDeleteIfClose == true) {
                // �쐬����tjc�̍폜
                foreach (var tjc in TJCs) {
                    if (File.Exists(tjc)) {
                        File.Delete(tjc);
                    }
                }
            }
        }

        private void BtTJARead_Click(object sender, EventArgs e) {
            // TJA�̃��X�g���擾
            // ���Ƀ���������TJA�̃��X�g������ꍇ(�Q�Ɛ�t�H���_�̕ύX���Ȃ���Ă��Ȃ��ꍇ)�͉������Ȃ�
            // �Q�Ɛ�t�H���_��ݒ肵�Ă��Ȃ��ꍇ
            if (setting.RandomSetting.ReferringDirectories == null || setting.RandomSetting.ReferringDirectories.Count == 0) {
                DirectoryInfo currentDInfo = new DirectoryInfo(currentDir);
                // ���A�v���̔z�u�悪���Y�t�H���_����Ȃ��ꍇ
                if (currentDInfo.Parent.GetFiles("taikojiro.exe", SearchOption.TopDirectoryOnly).Length == 0) {
                    MessageBox.Show("���ʂ̎Q�Ɛ�t�H���_��ݒ肷�邩�Ataikojiro.exe�̃t�H���_�̒����ɓ��A�v���̃t�H���_���i�[���Ă��������B", "����˂�", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(currentDInfo.Parent.FullName, setting);
                    FlgSettingChange = false;
                }
                // �Q�Ɛ�t�H���_��ݒ肵�Ă���ꍇ
            } else {
                if (TJAs == null || FlgSettingChange == true) {
                    TJAs = RandomTJA.GetTJAs(setting.RandomSetting.ReferringDirectories, setting);
                    FlgSettingChange = false;
                }
            }

            ShowSortedTJACount();
        }

        private void TabMain_SelectedIndexChanged(object sender, EventArgs e) {
            // ��ʏ�̐ݒ���e�����Ƃ�setting���X�V����
            setSettingValue();
            // �ݒ���e��ۑ�����
            Setting.Write(setting);

            getSettingValue();
        }

        /// <summary>
        /// �y�Ȑ������_���L�������؂�ւ�
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
