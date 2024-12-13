using System;
using UnityEngine;

namespace DAT.NPCTaisen
{
    [Serializable]
    public class DecideAttackParams
    {
        [Tooltip("近距離攻撃のウェイト")]
        public float meleeAttackWeight = 1;

        [Tooltip("遠隔攻撃のウェイト")]
        public float rangedAttackWeight = 1;

        [Tooltip("攻撃にかかる秒数")]
        public float untilAttackSeconds = 0.1f;
    }
}
