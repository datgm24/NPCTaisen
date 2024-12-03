using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public class RangedAttack : AttackableBase
    {
        public override bool Attack(IMovable from)
        {
            if (!base.Attack(from))
            {
                return false;
            }

            Debug.Log($"Ranged");
            return true;
        }

        protected override void OnHit()
        {
            Debug.Log($"遠距離ヒット");
        }
    }
}
