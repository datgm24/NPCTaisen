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

        public override IAttackable SpawnAttack(Vector3 position, Quaternion rotation, string ownerName)
        {
            var attackObject = base.SpawnAttack(position, rotation, ownerName);
            return attackObject;
        }
    }
}
