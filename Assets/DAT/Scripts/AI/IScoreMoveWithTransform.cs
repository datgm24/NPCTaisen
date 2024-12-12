using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// Transformから、移動方向を採点するインターフェース
    /// </summary>
    public interface IScoreMoveWithTransform
    {
        /// <summary>
        /// 自分と相手のTransformから、移動方向ごとのスコアを返す。
        /// </summary>
        /// <param name="scores">計算したスコアを返す先</param>
        /// <param name="myTransform">自分のTransform</param>
        /// <param name="enemyTransform">敵のTransform</param>
        void Score(ref float[] scores, Transform myTransform, Transform enemyTransform);
    }
}
