using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 攻撃用インターフェース
    /// </summary>
    public interface IAttackable
    {
        /// <summary>
        /// 攻撃する。
        /// </summary>
        void Attack();
    }
}
