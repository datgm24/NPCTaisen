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
        /// 攻撃アニメの状態
        /// </summary>
        PlayerAnimationState AnimationState { get; }

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

        /// <summary>
        /// 攻撃オブジェクトを生成する。
        /// </summary>
        /// <param name="position">生成先の座標</param>
        /// <param name="rotation">向き</param>
        /// <param name="ownerName">攻撃主の名前</param>
        IAttackable SpawnAttack(Vector3 position, Quaternion rotation, string ownerName);
    }
}
