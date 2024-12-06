using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーの近接攻撃アクションの実装。
    /// コンクリート（具象）クラスなので、べた書きでよい。
    /// </summary>
    [CreateAssetMenu(fileName = "MeleeActionAsset", menuName = "ScriptableObjects/DAT/MeleeActionAsset")]
    public class MeleeAction : AttackActionBase, IAttackActionable
    {
        public override bool Attack(IAttackActionListener listener)
        {
            if (!base.Attack(listener))
            {
                return false;
            }

            Debug.Log($"melee");
            return true;
        }

        public override IAttackable SpawnAttack(Transform sourceTransform, string ownerName, Color attackColor)
        {
            var attackObject = base.SpawnAttack(sourceTransform, ownerName, attackColor);
            return attackObject;
        }
    }
}
