using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiroRandomPlayer2 {
    /// <summary>
    /// TJCファイル関連クラス
    /// </summary>
    public class TJC {

        /// <summary>
        /// 段位再生
        /// </summary>
        /// <param name="TJAs"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string Play(List<TJA> TJAs, Setting setting) {

            // 太鼓さん次郎の検出
            Process[] processes = Process.GetProcessesByName("taikojiro");
            Process Jiro;

            if(processes.Length <= 0) {
                MessageBox.Show("太鼓さん次郎を起動してください", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "";
            }

            // taikojiro.exeのあるフォルダ直下に当アプリをおいてほしい
            DirectoryInfo taikojirofolder = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
            var jiroFInfo = taikojirofolder.GetFiles("taikojiro.exe", SearchOption.AllDirectories);

            if (jiroFInfo.Length == 0) {
                MessageBox.Show("次郎が検出されません。太鼓さん次郎があるフォルダの直下に入れてください。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "";
            }

            // ここでランダム段位の曲を決める
            List<TJA> sortedTJAs = RandomTJA.SortTJA(TJAs, setting);
            List<TJA> selectedTJAs = SelectTJAs(sortedTJAs, setting);
            if(selectedTJAs.Count() == 0) {
                return "";
            }

            // tjcを作成する
            string tjcPath = Write(selectedTJAs, jiroFInfo[0], setting);

            if(tjcPath == "") {
                return "";
            }
            MmdDropFile mmdDropFile = new MmdDropFile(tjcPath);

            if (processes.Length > 0) {
                FileDrop.DropFile(processes[0].MainWindowHandle, mmdDropFile);
            } else {
                MessageBox.Show("太鼓さん次郎が起動していません。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            // tjcについての情報を表示
            if (setting.CourseSetting.IsShowTJCInfo == true) {
                ShowTJCInfo(selectedTJAs);
            }

            // TJCのパスを返す
            return tjcPath;

        }

        /// <summary>
        /// tjcの情報表示
        /// </summary>
        /// <param name="selectedTJAs"></param>
        private static void ShowTJCInfo(List<TJA> selectedTJAs) {
            string msg = "";
            var totalNotes = 0;

            foreach (var selectedTJA in selectedTJAs.Select((value, index) => (value, index))) {
                msg += $"{selectedTJA.index + 1} 曲目 : {selectedTJA.value.TITLE}, Level : {selectedTJA.value.LEVEL} , {selectedTJA.value.NotesCount} Notes\r\n";
                totalNotes += selectedTJA.value.NotesCount;
            }
            MessageBox.Show($"{msg}\r\n" +
                            $"合計ノーツ数 : {totalNotes} Notes", "今回の段位構成");
        }

        /// <summary>
        /// ソートされたTJAからランダムコース用のTJAリストを選択する
        /// </summary>
        /// <param name="sortedTJAs"></param>
        /// <returns></returns>
        public static List<TJA> SelectTJAs(List<TJA> sortedTJAs, Setting setting) {

            List<TJA> selectedTJAs = new List<TJA>();
            // 段位内曲数
            int musicCount = setting.CourseSetting.MusicCount;

            if (setting.CourseSetting.IsMusicCountRandom == true) { 
                Random rand = new Random();
                musicCount = rand.Next(1, setting.CourseSetting.CourseMusicMax);
            }

            if (sortedTJAs.Count() < musicCount)
            {
                MessageBox.Show("条件に当てはまる譜面が少なすぎます。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return selectedTJAs;
            }

            // 選び続ける
            while (selectedTJAs.Count() != musicCount) {
                var selectedTJA = RandomTJA.SelectTJA(sortedTJAs);
                // 被りアリ選択
                if (setting.CourseSetting.IsDuplicate == true) {
                    selectedTJAs.Add(selectedTJA);
                // 被りなし選択
                } else {
                    if (selectedTJAs.Contains(selectedTJA)) { 
                        continue;
                    }
                    selectedTJAs.Add(selectedTJA);
                }
            }

            // 難易度順のソート
            if (setting.CourseSetting.IsLevelSort == true) { 
                // 昇順
                if(setting.CourseSetting.SortOrder == 0) {
                    selectedTJAs = selectedTJAs.OrderBy(x => x.LEVEL).ToList();
                // 降順
                } else {
                    selectedTJAs = selectedTJAs.OrderByDescending(x => x.LEVEL).ToList();
                }
            }

            return selectedTJAs;
        }

        /// <summary>
        /// TJCファイルを出力する
        /// </summary>
        /// <param name="selectedTJAs"></param>
        /// <param name="JiroFInfo"></param>
        /// <returns></returns>
        public static string Write(List<TJA> selectedTJAs, FileInfo JiroFInfo, Setting setting) {

            // 使用するTJAに1つでも次郎内のディレクトリに存在しなかった場合
            if (selectedTJAs.Any(x => x.TJAPath.FullName.Contains(JiroFInfo.DirectoryName) == false)) {
                MessageBox.Show("次郎のディレクトリ内に存在しないtjaがあります。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "";
            }
            try {
                DateTime nowDt = DateTime.Now;
                string tjcPath = $@"{JiroFInfo.Directory.FullName}\RandomCourse_{nowDt.ToString("yyyyMMddHHmmss")}.tjc";

                using (StreamWriter sw = new StreamWriter(tjcPath, false, Encoding.GetEncoding("Shift_jis"))) {
                    // tjcに書き込む内容
                    List<string> lines = new List<string>();
                    lines.Add($"TITLE:ランダム段位{nowDt.ToString("yyyy/MM/dd HH:mm:ss")}\r\n" +
                              $"LIFE:{setting.CourseSetting.Life}");
                    foreach(var tja in selectedTJAs) {
                        // tjaの相対パスを取得して書いていく
                        string relativePath = tja.TJAPath.FullName.Replace(JiroFInfo.DirectoryName + "\\", "");
                        lines.Add($"SONG:{relativePath}");
                    }

                    foreach (var line in lines) { 
                        sw.WriteLine(line);
                    }
                }

                return tjcPath;
            }
            catch (Exception e) {
                MessageBox.Show("ランダム段位の生成に失敗しました。", "ざんねん", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                return "";
            }
        }

        /// <summary>
        /// 作成したtjcを削除する
        /// </summary>
        /// <param name="TJCsPath"></param>
        public static void Delete(List<string> TJCsPath) {
            foreach (var tjcPath in TJCsPath) {
                if (File.Exists(tjcPath)) { 
                    File.Delete(tjcPath);
                }
            }
        }
    }
}
