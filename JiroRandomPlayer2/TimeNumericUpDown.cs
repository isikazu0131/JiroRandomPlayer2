using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiroRandomPlayer2 {

    /// <summary>
    /// 分秒を扱うNumericUpDown
    /// </summary>
    public class TimeNumericUpDown : NumericUpDown {
        public TimeNumericUpDown() {
            // 最大値を99999秒
            this.Maximum = 99999;
            this.Minimum = 0;
        }

        /// <summary>
        /// アプデの監視を行う
        /// </summary>
        protected override void UpdateEditText() {
            string timeStr = ToMinSec((int)this.Value);
            try {
                if (TimeSpan.TryParse(this.Text, out TimeSpan time)) {

                    // 誤入力防止
                    if (this.Value < this.Minimum) {
                        this.Value = this.Minimum;
                    } else if (this.Value > this.Maximum) {
                        this.Value = this.Maximum;
                    } else {
                        this.Value = this.Value;
                    }
                } else {
                    throw new FormatException();
                }
            }
            catch (Exception ex) {

            }
            this.Text = timeStr;
        }

        /// <summary>
        /// 時間を分秒に変換
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private string ToMinSec(int time) {
            int min = time / 60;
            int sec = time % 60;

            return $"{min:00}:{sec:00}";
        }

        protected override void ValidateEditText() {

        }
    }
}
