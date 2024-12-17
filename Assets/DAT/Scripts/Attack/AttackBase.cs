using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 攻撃オブジェクトを制御するベースクラス
    /// </summary>
    public abstract class AttackBase : MonoBehaviour, IAttackable
    {
        /// <summary>
        /// アニメから設定するアルファ値
        /// </summary>
        [HideInInspector]
        public float alpha = 0;

        string ownerName;
        protected bool canHit = false;
        protected Color attackColor;
        MeshRenderer meshRenderer;

        public bool IsOwner(string checkName) => ownerName == checkName;

        /// <summary>
        /// アルファ値を反映させる。
        /// </summary>
        protected virtual void Update()
        {
            if (meshRenderer == null)
            {
                meshRenderer = GetComponentInChildren<MeshRenderer>();
            }

            attackColor.a = alpha;
            meshRenderer.material.color = attackColor;
        }

        /// <summary>
        /// 攻撃主を無視する。
        /// 攻撃主以外のとき、OnHitを呼び出す。
        /// </summary>
        /// <param name="other">衝突相手の情報</param>
        void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                if (damageable.Damage(ownerName))
                {
                    // ぶつかったときに呼び出す
                    OnHit(other);
                }
            }
        }

        void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }

        public void SetOwnerAndColor(string owner, Color color)
        {
            ownerName = owner;
            canHit = false;
            attackColor = color;
        }

        /// <summary>
        /// 攻撃が当たったときに、各攻撃の処理を実装するメソッド。
        /// </summary>
        protected abstract void OnHit(Collider other);


    }
}
