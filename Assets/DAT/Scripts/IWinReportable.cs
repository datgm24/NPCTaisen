using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 勝ったことを知らせるためのインターフェース
    /// </summary>
    public interface IWinReportable
    {
        /// <summary>
        /// 勝ったことを知らせる。
        /// </summary>
        /// <param name="player">自分のインスタンスを渡す</param>
        void ReportWin(PlayerController player);
    }
}
