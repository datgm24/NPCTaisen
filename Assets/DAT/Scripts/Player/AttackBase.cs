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

        void OnTriggerEnter(Collider other)
        {
            Debug.Log($"何かにヒット");
            // TODO
            // 相手から、IDamageableを取り出す。取り出せなければ終わり
            // ダメージを与えるメソッドを、ownerを渡して呼び出す
            // falseが戻ったら、攻撃主なので、何もしない
            // trueが戻ったら、攻撃成功。消すなり、当たり判定をなくすなりする。
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
        protected abstract void OnHit();

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
    }
}
