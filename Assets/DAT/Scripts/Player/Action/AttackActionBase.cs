using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public abstract class AttackActionBase : MonoBehaviour, IAttackActionable, IScoreMoveWithTransform, IScoreAttackWithTransform
    {
        [SerializeField, Tooltip("プレイヤーの攻撃モーション")]
        PlayerAnimationState attackAnimation = PlayerAnimationState.MeleeAttack;

        [SerializeField, Tooltip("次の攻撃ができるようになるまでの待機秒数")]
        float interval = 1f;

        [SerializeField, Tooltip("攻撃用オブジェクトのプレハブ")]
        protected AttackBase attackPrefab = default;

        [SerializeField, Tooltip("攻撃を当てようとする優先度。デフォルト1。0にすると、攻撃を当てようとする動きをしない。")]
        protected float attackMoveRate = 1f;

        public bool IsAttacking { get; protected set; } = false;

        public bool CanAttack => attackedTime >= interval;

        public PlayerAnimationState AnimationState => attackAnimation;

        /// <summary>
        /// 攻撃してからの経過秒数。
        /// </summary>
        float attackedTime;

        /// <summary>
        /// 攻撃元の攻撃開始を知らせるインスタンス
        /// </summary>
        IAttackActionListener attackActionListener;

        /// <summary>
        /// 攻撃を知らせる際のインスタンスを渡す。
        /// </summary>
        /// <param name="attackListener">設定するインスタンス</param>
        public void SetAttackListener(IAttackActionListener attackListener)
        {
            attackActionListener = attackListener;
        }

        /// <summary>
        /// フレーム更新
        /// </summary>
        public virtual void Update()
        {
            attackedTime += Time.deltaTime;
        }

        public virtual bool Attack()
        {
            if (!CanAttack)
            {
                return false;
            }

            IsAttacking = true;
            attackedTime = 0;
            attackActionListener.OnAttacking(this);
            return true;
        }

        public virtual IAttackable SpawnAttack(string ownerName, Color attackColor)
        {
            var attackObject = Instantiate(attackPrefab, transform.position, transform.rotation).GetComponent<IAttackable>();
            attackObject.SetOwnerAndColor(ownerName, attackColor);
            return attackObject;
        }

        public abstract void ScoreMove(ref float[] scores, Transform myTransform, Transform enemyTransform);

        public abstract DecideMoveAction.ActionType TryAttack(Transform myTransform, Transform enemyTransform);
    }
}
