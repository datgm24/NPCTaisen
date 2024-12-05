using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーの遠距離攻撃アクションの実装。
    /// コンクリート（具象）クラスなので、べた書きでよい。
    /// </summary>
    [CreateAssetMenu(fileName = "RangedActionAsset", menuName = "ScriptableObjects/DAT/RangedActionAsset")]
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

        public override IAttackable SpawnAttack(Vector3 position, Quaternion rotation, string ownerName)
        {
            var attackObject = base.SpawnAttack(position, rotation, ownerName);
            return attackObject;
        }
    }
}
