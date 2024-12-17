using System;
using UnityEngine;

namespace DAT.NPCTaisen
{
    [Serializable]
    public class DecideAttackParams
    {
        [Tooltip("攻撃にかかる秒数")]
        public float untilAttackSeconds = 0.1f;
    }
}
