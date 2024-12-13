using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public interface IScoreAttackWithTransform
    {
        /// <summary>
        /// 自分と相手のTransformから、移動方向ごとのスコアを返す。
        /// </summary>
        /// <param name="myTransform">自分のTransform</param>
        /// <param name="enemyTransform">敵のTransform</param>
        /// <returns>Stopなら攻撃しない。それ以外は、その向きに攻撃</returns>
        DecideMoveAction.ActionType TryAttack(Transform myTransform, Transform enemyTransform);
    }
}
