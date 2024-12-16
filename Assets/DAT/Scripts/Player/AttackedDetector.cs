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
        List<Transform> attackedTransforms = new List<Transform>(DefaultAttackedCount);
        string ownerName;

        /// <summary>
        /// オーナー名を設定する。
        /// </summary>
        /// <param name="owner"></param>
        void SetOwnerName(string owner)
        {
            ownerName = owner;
        }

        public void Clear()
        {
            attackedTransforms.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            var attack = other.GetComponent<AttackBase>();
            // 攻撃ではないか、オーナーなら何もしない
            if ((attack == null) || (attack.IsOwner(ownerName)))
            {
                return;
            }

            Debug.Log($"リストアップ {other.transform.position}");
            attackedTransforms.Add(other.transform);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }
    }
}
