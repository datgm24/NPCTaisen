using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 渡された情報から、移動方向を採点するインターフェース
    /// </summary>
    public interface IScoreMove
    {
        /// <summary>
        /// 自分と相手のTransformから、移動方向ごとのスコアを返す。
        /// </summary>
        /// <param name="scores">計算したスコアを返す先</param>
        /// <param name="aIActionParams">動作に関するパラメーター</param>
        void ScoreMove(ref float[] scores, AIActionParams aIActionParams);
    }
}
