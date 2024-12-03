using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 攻撃オブジェクトを制御するベースクラス
    /// </summary>
    public abstract class AttackableBase : MonoBehaviour, IAttackable
    {
        [SerializeField, Tooltip("次の攻撃ができるようになるまでの待機秒数")]
        float interval = 1f;

        public bool IsAttacking { get; protected set; } = false;

        public bool CanAttack => attackedTime >= interval;

        /// <summary>
        /// 攻撃主
        /// </summary>
        protected IMovable attacker;

        /// <summary>
        /// 攻撃してからの経過秒数。
        /// </summary>
        float attackedTime;

        /// <summary>
        /// フレーム更新
        /// </summary>
        protected virtual void Update()
        {
            attackedTime += Time.deltaTime;
        }

        public virtual bool Attack(IMovable from)
        {
            if (!CanAttack)
            {
                return false;
            }

            attacker = from;
            IsAttacking = true;
            attackedTime = 0;
            return true;
        }


        /// <summary>
        /// 攻撃が当たったときに、各攻撃の処理を実装するメソッド。
        /// </summary>
        protected abstract void OnHit();
    }
}
