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
        public override bool Attack()
        {
            if (!base.Attack())
            {
                return false;
            }

            Debug.Log($"ranged");
            return true;
        }
    }
}
