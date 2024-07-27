using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JiroRandomPlayer2 {
    public class Setting {

        /// <summary>
        /// ランダム選択設定
        /// </summary>
        public RandomSetting RandomSetting { get; set; }

        /// <summary>
        /// ランダム段位設定
        /// </summary>
        public CourseSetting CourseSetting { get; set; }

        /// <summary>
        /// 設定ファイル読み込み
        /// </summary>
        /// <returns></returns>
        public static Setting Read() {
            Setting setting = new Setting();
            setting.RandomSetting = RandomSetting.Read();
            setting.CourseSetting = CourseSetting.Read();
            return setting;
        }
        
        /// <summary>
        /// 設定ファイル書き込み
        /// </summary>
        /// <param name="setting"></param>
        public static void Write(Setting setting) {
            RandomSetting.Write(setting.RandomSetting);
            CourseSetting.Write(setting.CourseSetting);
        }
    }

    /// <summary>
    /// ランダム選択設定
    /// </summary>
    public class RandomSetting {
        #region 条件設定
        /// <summary>
        /// 難易度でソートするか
        /// </summary>
        public bool IsLevelSort { get; set; }

        /// <summary>
        /// BPMでソートするか
        /// </summary>
        public bool IsBPMSort { get; set; }

        /// <summary>
        /// ノーツ数範囲でソートするか
        /// </summary>
        public bool IsNotesCountSort { get; set; }

        /// <summary>
        /// 音源再生時間でソートするか
        /// </summary>
        public bool IsMusicTimeSort { get; set; }

        /// <summary>
        /// 平均密度でソートするか
        /// </summary>
        public bool IsAvgDensitySort {  get; set; }

        /// <summary>
        /// 難易度最小値
        /// </summary>
        public double LevelMin { get; set; }

        /// <summary>
        /// 難易度最大値
        /// </summary>
        public double LevelMax { get; set; }

        /// <summary>
        /// BPM最小値
        /// </summary>
        public int BPMMin { get; set; }

        /// <summary>
        /// BPM最大値
        /// </summary>
        public int BPMMax { get; set; }

        /// <summary>
        /// ノーツ数最小値
        /// </summary>
        public int NotesCountMin { get; set; }
        
        /// <summary>
        /// ノーツ数最大値
        /// </summary>
        public int NotesCountMax { get; set; }

        /// <summary>
        /// 楽曲再生時間最小値(秒)
        /// </summary>
        public int MusicTimeMin { get; set; }

        /// <summary>
        /// 楽曲再生時間最大値(秒)
        /// </summary>
        public int MusicTimeMax { get; set; }

        /// <summary>
        /// 平均密度最小値
        /// </summary>
        public double AvgDensityMin { get; set; }

        /// <summary>
        /// 平均密度最大値
        /// </summary>
        public double AvgDensityMax { get; set; }

        /// <summary>
        /// STYLE
        /// </summary>
        public STYLE STYLE { get; set; }
        #endregion

        #region フォルダ関係
        /// <summary>
        /// 参照フォルダ
        /// </summary>
        public List<string> ReferringDirectories { get; set; }

        /// <summary>
        /// 参照フォルダ 全てのサブディレクトリを参照するか
        /// デフォルト: true
        /// </summary>
        public bool IsSubDirRef { get; set; }

        /// <summary>
        /// 除外フォルダ
        /// </summary>
        public List<string> ExcludeDirectories { get; set; }

        /// <summary>
        /// 除外フォルダ すべてのサブディレクトリを参照するか
        /// デフォルト: true
        /// </summary>
        public bool IsSubDirExc { get; set; }
        #endregion

        /// <summary>
        /// 初期設定値を適用
        /// </summary>
        public RandomSetting() {
            LevelMin = 8;
            LevelMax = 10;
            BPMMin = 140;
            BPMMax = 180;
            NotesCountMin = 600;
            NotesCountMax = 800;
            MusicTimeMin = 90;
            MusicTimeMax = 150;
            AvgDensityMin = 3.000;
            AvgDensityMax = 5.000;
            STYLE = STYLE.SP;
            IsSubDirRef = true;
            IsSubDirExc = true;
            ReferringDirectories = new List<string>();
            ExcludeDirectories = new List<string>();
        }

        /// <summary>
        /// 設定jsonファイルを読み込みます
        /// </summary>
        /// <returns></returns>
        public static RandomSetting Read() {
            RandomSetting setting = new RandomSetting();
            // 設定フォルダがなければ、一旦フォルダだけ作って設定クラスのインスタンスを生成しなおす
            if (Directory.Exists(Constants.FileName.SettingFolder) == false) {
                Directory.CreateDirectory(Constants.FileName.SettingFolder);
                return setting;
            }
            try {
                if (File.Exists(Constants.FileName.RandomSettingFile)) {
                    string jsonStr = File.ReadAllText(Constants.FileName.RandomSettingFile);
                    setting = JsonSerializer.Deserialize<RandomSetting>(jsonStr);
                }
                return setting;
            }
            catch {
                return new RandomSetting();
            }
        }

        /// <summary>
        /// 設定ファイル(json)を書き込みます
        /// </summary>
        /// <param name="setting"></param>
        public static void Write(RandomSetting setting) {
            try {
                string jsonStr = JsonSerializer.Serialize(setting);
                File.WriteAllText(Constants.FileName.RandomSettingFile, jsonStr);
            }
            catch (Exception ex) {
                MessageBox.Show($"ランダム選択設定ファイルの保存に失敗しました。: \r\n" +
                                $"{ex.Message}");
            }
        }
    }

    /// <summary>
    /// ランダム段位設定
    /// </summary>
    public class CourseSetting {
        /// <summary>
        /// 曲数
        /// </summary>
        public int MusicCount { get; set; }

        /// <summary>
        /// LIFE値
        /// </summary>
        public int Life { get; set; }

        /// <summary>
        /// 段位内譜面の被りを許可するか
        /// </summary>
        public bool IsDuplicate { get; set; }

        /// <summary>
        /// アプリ終了時生成した段位を削除するか
        /// </summary>
        public bool IsOldTJCDeleteIfClose { get; set; }

        /// <summary>
        /// 生成した段位の詳細情報を表示するか
        /// </summary>
        public bool IsShowTJCInfo { get; set; }

        /// <summary>
        /// 曲数もランダムにするか
        /// </summary>
        public bool IsMusicCountRandom { get; set; }

        /// <summary>
        /// 段位内の譜面の難易度をソートするか
        /// </summary>
        public bool IsLevelSort { get; set; }

        /// <summary>
        /// ソート順
        /// (0: 昇順 / 1: 降順)
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// 楽曲数ランダムのランダムコース内楽曲数の最大値
        /// </summary>
        public int CourseMusicMax { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CourseSetting() {
            MusicCount = 3;
        }

        /// <summary>
        /// 設定jsonファイルを読み込みます
        /// </summary>
        /// <returns></returns>
        public static CourseSetting Read() {
            CourseSetting setting = new CourseSetting();
            // 設定フォルダがなければ、一旦フォルダだけ作って設定クラスのインスタンスを生成しなおす
            if (Directory.Exists(Constants.FileName.SettingFolder) == false) {
                Directory.CreateDirectory(Constants.FileName.SettingFolder);
                return setting;
            }
            try {
                if (File.Exists(Constants.FileName.CourseSettingFile)) {
                    string jsonStr = File.ReadAllText(Constants.FileName.CourseSettingFile);
                    setting = JsonSerializer.Deserialize<CourseSetting>(jsonStr);
                }
                return setting;
            }
            catch {
                return new CourseSetting();
            }
        }

        /// <summary>
        /// 設定ファイル(json)を書き込みます
        /// </summary>
        /// <param name="setting"></param>
        public static void Write(CourseSetting setting) {
            try {
                string jsonStr = JsonSerializer.Serialize(setting);
                File.WriteAllText(Constants.FileName.CourseSettingFile, jsonStr);
            }
            catch (Exception ex) {
                MessageBox.Show($"ランダム選択設定ファイルの保存に失敗しました。: \r\n" +
                                $"{ex.Message}");
            }
        }
    }

    /// <summary>
    /// 高度な設定
    /// </summary>
    public class HighLevelSetting {

        /// <summary>
        /// 難易度の幅
        /// </summary>
        public double Increment;
    }

}
