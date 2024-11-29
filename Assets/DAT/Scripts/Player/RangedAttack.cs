using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public class RangedAttack : AttackableBase
    {
        public override void Attack()
        {
            Debug.Log($"Ranged");
        }
    }
}
