using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーの近接攻撃アクションの実装。
    /// コンクリート（具象）クラスなので、べた書きでよい。
    /// </summary>
    public class MeleeAction : AttackActionBase, IAttackActionable
    {
        public override bool Attack(IAttackActionListener listener)
        {
            if (!base.Attack(listener))
            {
                return false;
            }

            return true;
        }

        public override IAttackable SpawnAttack(string ownerName, Color attackColor)
        {
            var attackObject = base.SpawnAttack(ownerName, attackColor);
            return attackObject;
        }

        public override void Score(ref float[] scores, Transform myTransform, Transform enemyTransform)
        {
            Debug.Log($"近距離攻撃をあてようとする移動採点");
        }
    }
}