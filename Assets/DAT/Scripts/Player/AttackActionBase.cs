using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public class AttackActionBase : ScriptableObject, IAttackActionable
    {
        [SerializeField, Tooltip("次の攻撃ができるようになるまでの待機秒数")]
        float interval = 1f;

        [SerializeField, Tooltip("攻撃用オブジェクトのプレハブ")]
        protected AttackBase attackPrefab = default;

        public bool IsAttacking { get; protected set; } = false;

        public bool CanAttack => attackedTime >= interval;

        /// <summary>
        /// 攻撃してからの経過秒数。
        /// </summary>
        float attackedTime;

        /// <summary>
        /// フレーム更新
        /// </summary>
        public virtual void Update()
        {
            attackedTime += Time.deltaTime;
        }

        public virtual bool Attack(IAttackActionListener listener)
        {
            if (!CanAttack)
            {
                return false;
            }

            IsAttacking = true;
            attackedTime = 0;
            listener.OnAttacking(this);
            return true;
        }
    }
}
