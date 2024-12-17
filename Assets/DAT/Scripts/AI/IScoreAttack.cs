using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public interface IScoreAttack
    {
        /// <summary>
        /// 自分と相手のTransformから、移動方向ごとのスコアを返す。
        /// </summary>
        /// <returns>Stopなら攻撃しない。それ以外は、その向きに攻撃</returns>
        /// <param name="aiActionParams">AIの情報</param>
        /// <returns>攻撃方向を返す。攻撃しないなら、Stop</returns>
        DecideMoveAction.ActionType TryAttack(AIActionParams aiActionParams);
    }
}
