using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 近接攻撃オブジェクトの制御クラス。
    /// </summary>
    public class MeleeAttack : AttackBase, IAttackable
    {
        protected override void OnHit()
        {
            Debug.Log($"近接ヒット");
        }
    }
}
