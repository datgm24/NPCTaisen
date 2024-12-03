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
        /// 攻撃モーション中のとき、true
        /// </summary>
        bool IsAttacking { get; }

        /// <summary>
        /// 次の攻撃ができる状態なら、true
        /// </summary>
        bool CanAttack { get; }

        /// <summary>
        /// 攻撃する。
        /// </summary>
        /// <returns>攻撃を開始したら、true。</returns>
        bool Attack(IMovable attacker);
    }
}
