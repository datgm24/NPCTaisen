using System;
using UnityEngine;

namespace DAT.NPCTaisen
{
    [Serializable]
    public class DecideMoveParams
    {
        [Tooltip("自分の攻撃を当てようとするウェイト")]
        public float attackWeight = 1;

        [Tooltip("敵からの距離")]
        public float fromEnemyDistance = 5;

        [Tooltip("敵からの距離のウェイト")]
        public float fromEnemyWeight = 1;

        [Tooltip("敵の攻撃を避けるウェイト")]
        public float escapeEnemyAttackWeight = 1;

        [Tooltip("敵がフリーズ中に、攻撃を当てようとするウェイト")]
        public float enemyFreezeAttackWeight = 1;
    }
}
