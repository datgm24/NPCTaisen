using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 敵の攻撃をリストアップする。
    /// </summary>
    public class AttackedDetector
    {
        static int DefaultAttackedCount => 8;

        /// <summary>
        /// 敵の攻撃オブジェクトのTransformリスト
        /// </summary>
        public readonly List<Transform> AttackedTransforms = new List<Transform>(DefaultAttackedCount);

        string ownerName;
        CapsuleCollider capsuleCollider;

        Collider[] colliders = new Collider[DefaultAttackedCount];
        int attackableAreaLayer;

        public AttackedDetector(string owner, CapsuleCollider capsule)
        {
            ownerName = owner;
            capsuleCollider = capsule;
            attackableAreaLayer = LayerMask.GetMask("AttackableArea");
        }


        /// <summary>
        /// 敵の弾の検出とリストアップ
        /// </summary>
        /// <returns>検出した敵の弾の数</returns>
        public int Detect()
        {
            int count = Physics.OverlapSphereNonAlloc(
                capsuleCollider.bounds.center, capsuleCollider.radius, colliders, attackableAreaLayer, QueryTriggerInteraction.Collide);

            AttackedTransforms.Clear();
            for (int i=0;i<count;i++)
            {
                var attack = colliders[i].GetComponentInParent<AttackBase>();
                // 攻撃主が自分なら対象から外す
                if (attack.IsOwner(ownerName))
                {
                    continue;
                }

                AttackedTransforms.Add(attack.transform);
            }

            return AttackedTransforms.Count;
        }
    }
}
