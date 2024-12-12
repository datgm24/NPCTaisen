using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーの遠距離攻撃アクションの実装。
    /// コンクリート（具象）クラスなので、べた書きでよい。
    /// </summary>
    public class RangedAction : AttackActionBase, IAttackActionable
    {
        public override void Score(ref float[] scores, Transform myTransform, Transform enemyTransform)
        {
            // attackMoveRateを、答えに掛ける

            Debug.Log($"遠隔攻撃をあてようとする移動採点");
        }

        public override IAttackable SpawnAttack(string ownerName, Color attackColor)
        {
            var attackObject = base.SpawnAttack(ownerName, attackColor);
            return attackObject;
        }
    }
}