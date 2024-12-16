using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 敵の攻撃をリストアップする。
    /// </summary>
    public class AttackedDetector : MonoBehaviour
    {
        static int DefaultAttackedCount => 8;
        /// <summary>
        /// 
        /// </summary>
        public readonly List<Transform> AttackedTransforms = new List<Transform>(DefaultAttackedCount);
        string ownerName;

        /// <summary>
        /// オーナー名を設定する。
        /// </summary>
        /// <param name="owner">オーナーの名前</param>
        public void SetOwnerName(string owner)
        {
            ownerName = owner;
        }

        public void Clear()
        {
            AttackedTransforms.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            var attack = other.GetComponentInParent<AttackBase>();

            // 攻撃ではないか、オーナーなら何もしない
            if ((attack == null) || (attack.IsOwner(ownerName)))
            {
                return;
            }

            AttackedTransforms.Add(other.transform);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }
    }
}
