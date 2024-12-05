using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 遠隔攻撃オブジェクトの制御クラス。
    /// </summary>
    public class RangedAttack : AttackBase, IAttackable
    {
        protected override void OnHit()
        {
            Debug.Log($"遠隔攻撃が当たった");
        }
    }
}
