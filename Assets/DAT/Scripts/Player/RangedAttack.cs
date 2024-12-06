using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 遠隔攻撃オブジェクトの制御クラス。
    /// </summary>
    public class RangedAttack : AttackBase, IAttackable
    {
        [SerializeField, Tooltip("速度")]
        float Speed = 8;

        void Awake()
        {
            var rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * Speed;
        }

        // これが呼ばれたら、敵か、壁に当たったので、消す。
        protected override void OnHit(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
