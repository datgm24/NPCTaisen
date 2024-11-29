using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 近接攻撃
    /// </summary>
    public class MeleeAttack : AttackableBase
    {
        public override void Attack()
        {
            Debug.Log($"melee");
        }
    }
}
