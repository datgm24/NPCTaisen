using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public class Wall : MonoBehaviour, IDamageable
    {
        public bool Damage(string ownerName)
        {
            return true;
        }
    }
}
