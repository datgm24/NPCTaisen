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
        public override bool Attack(IAttackActionListener listener)
        {
            if (!base.Attack(listener))
            {
                return false;
            }

            Debug.Log($"ranged");
            return true;
        }

        public override IAttackable SpawnAttack(string ownerName, Color attackColor)
        {
            var attackObject = base.SpawnAttack(ownerName, attackColor);
            return attackObject;
        }
    }
}
