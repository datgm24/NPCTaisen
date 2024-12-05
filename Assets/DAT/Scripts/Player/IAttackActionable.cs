using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーの攻撃アクションのインターフェース
    /// </summary>
    public interface IAttackActionable
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
        /// <param name="listener">攻撃を開始するときに、通知する先のインスタンス</param>
        /// <returns>攻撃を開始したら、true。</returns>
        bool Attack(IAttackActionListener listener);

        /// <summary>
        /// 更新処理。MonoBehaviourのUpdateから呼び出す。
        /// </summary>
        void Update();
    }
}
