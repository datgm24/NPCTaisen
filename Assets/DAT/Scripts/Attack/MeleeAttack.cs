using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 近接攻撃オブジェクトの制御クラス。
    /// </summary>
    public class MeleeAttack : AttackBase, IAttackable
    {
        protected override void OnHit(Collider other)
        {
            if (!canHit)
            {
                return;
            }

            if (other.CompareTag("Player"))
            {
                canHit = false;
            }
        }

        /// <summary>
        /// 攻撃開始
        /// </summary>
        public void OnAttackStart()
        {
            canHit = true;
        }

        /// <summary>
        /// 攻撃終了
        /// </summary>
        public void OnAttackEnd()
        {
            canHit = false;
        }

        /// <summary>
        /// アニメが終わった
        /// </summary>
        public void OnFinished()
        {
            Destroy( gameObject );
        }
    }
}
