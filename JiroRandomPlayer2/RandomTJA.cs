using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiroRandomPlayer2 {
    /// <summary>
    /// ランダム選定についてのメソッドを集めたクラス
    /// </summary>
    public class RandomTJA {

        public static List<TJA> GetTJAs(string Dir, Setting setting) {
            List<string> dirList = new List<string>();
            dirList.Add(Dir);
            return GetTJAs(dirList, setting);
        }

        /// <summary>
        /// 指定されたディレクトリからTJAのリストを取得する
        /// </summary>
        /// <param name="Directories"></param>
        /// <returns></returns>
        public static List<TJA> GetTJAs(List<string> Directories, Setting setting) {
            List<TJA> TJAs = new List<TJA>();
            foreach (var dir in Directories) {
                TJAs.AddRange(TJA.GetTJAs(dir, setting));
            }
            return TJAs;
        }

        /// <summary>
        /// TJAを指定された条件で決めます
        /// </summary>
        /// <returns></returns>
        public static List<TJA> SortTJA(List<TJA> TJAs, Setting setting) {
            // フィルタリング用にtjaのリストを新しく定義しておく
            var SelectedTJAs = TJAs;
            // 除外フォルダに属しているtjaの除外
            foreach (var exclusionDName in setting.RandomSetting.ExcludeDirectories) {
                // サブディレクトリも含め除外する
                if(setting.RandomSetting.IsSubDirExc == true) {
                    SelectedTJAs = SelectedTJAs.Where(x => x.TJAPath.DirectoryName.Contains(exclusionDName) == false).ToList();
                } else {
                    // 除外フォルダ直下のフォルダ(先頭フォルダ)の配列を用意
                    var excFiles = Directory.GetFiles(exclusionDName, "*.tja", SearchOption.TopDirectoryOnly).ToList();
                    // 除外フォルダ直下のtjaファイルを除外する
                    SelectedTJAs = SelectedTJAs.Where(x => excFiles.Contains(x.TJAPath.FullName) == false).ToList();
                }
            }
            // LEVELでのソート
            if (setting.RandomSetting.IsLevelSort == true) {
                SelectedTJAs = SelectedTJAs.Where(x => x.LEVEL >= setting.RandomSetting.LevelMin && x.LEVEL <= setting.RandomSetting.LevelMax).ToList();
            }
            // BPMでのソート
            if (setting.RandomSetting.IsBPMSort == true) {
                SelectedTJAs = SelectedTJAs.Where(x => x.BPM >= setting.RandomSetting.BPMMin && x.BPM <= setting.RandomSetting.BPMMax).ToList();
            }
            // ノーツ数でのソート
            if (setting.RandomSetting.IsNotesCountSort == true) {
                SelectedTJAs = SelectedTJAs.Where(x => x.NotesCount >= setting.RandomSetting.NotesCountMin && x.NotesCount <= setting.RandomSetting.NotesCountMax).ToList();
            }
            // ノーツ数でのソート
            if (setting.RandomSetting.IsMusicTimeSort == true) {
                SelectedTJAs = SelectedTJAs.Where(x => x.MusicPlayTime >= setting.RandomSetting.MusicTimeMin && x.MusicPlayTime <= setting.RandomSetting.MusicTimeMax).ToList();
            }
            // ノーツ数でのソート
            if (setting.RandomSetting.IsAvgDensitySort == true) {
                SelectedTJAs = SelectedTJAs.Where(x => (x.NotesCount / x.TJAPlayTime) >= setting.RandomSetting.AvgDensityMin && (x.NotesCount / x.TJAPlayTime) <= setting.RandomSetting.AvgDensityMax).ToList();
            }

            //STYLEの選択
            SelectedTJAs = SelectedTJAs.Where(x => x.STYLE == setting.RandomSetting.STYLE).ToList();
            return SelectedTJAs;
        }

        public static TJA SelectTJA(List<TJA> sortedTJAs) {
            Random random = new Random();
            return sortedTJAs[random.Next(sortedTJAs.Count)];
        }

        /// <summary>
        /// ランダム再生
        /// </summary>
        /// <param name="TJAs"></param>
        /// <param name="setting"></param>
        public static void Play(List<TJA> TJAs, Setting setting) {

            // taikojiro.exeのあるフォルダ直下に当アプリをおいてほしい
            DirectoryInfo jiroDInfo = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
            var taikojiro = jiroDInfo.GetFiles("taikojiro.exe", SearchOption.AllDirectories);

            if (taikojiro.Length == 0) {
                MessageBox.Show("次郎が検出されません。太鼓さん次郎があるフォルダの直下に入れてください。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            // 条件で絞る
            var sortedTJAs = SortTJA(TJAs, setting);
            if(sortedTJAs.Count() == 0) {
                MessageBox.Show("検索条件に合う譜面が見つかりません。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return; 
            }

            // ランダムで選択する
            var selectedTJA = SelectTJA(sortedTJAs);

            MmdDropFile mmdDropFile = new MmdDropFile(selectedTJA.TJAPath.FullName);
            Process[] processes = Process.GetProcessesByName("taikojiro");
            Process Jiro;

            if (processes.Length > 0) {
                FileDrop.DropFile(processes[0].MainWindowHandle, mmdDropFile);
            } else {
                Jiro = Process.Start(taikojiro[0].FullName, selectedTJA.TJAPath.FullName);
                Jiro.WaitForInputIdle();
            }
        }
    }
}
