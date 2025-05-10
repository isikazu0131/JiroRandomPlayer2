using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace JiroRandomPlayer2 {
    /// <summary>
    /// 定数クラス
    /// </summary>
    public class Constants {
        /// <summary>
        /// このアプリケーションについての基本情報
        /// </summary>
        public class AppInfo {
            /// <summary>
            /// アプリケーション名
            /// </summary>
            public const string Name = "太鼓さん次郎ランダム再生アプリ";

            /// <summary>
            /// バージョン
            /// </summary>
            public const string Version = "V1.0.2";
        }

        /// <summary>
        /// ファイル・ディレクトリ等についての情報
        /// </summary>
        public class FileName {
            /// <summary>
            /// 設定ファイル
            /// </summary>
            public const string RandomSettingFile = @"Setting\RandomSetting.json";

            /// <summary>
            /// 設定ファイル
            /// </summary>
            public const string CourseSettingFile = @"Setting\CourseSetting.json";

            /// <summary>
            /// 設定ファイルの格納されているフォルダ
            /// </summary>
            public const string SettingFolder = "Setting";
        }
    }
}
