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
        public override bool Attack(IMovable from)
        {
            if (!base.Attack(from))
            {
                return false;
            }

            Debug.Log($"melee");
            return true;
        }

        protected override void OnHit()
        {
            Debug.Log($"近接ヒット");
        }
    }
}
