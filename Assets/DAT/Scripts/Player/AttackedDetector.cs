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

        /// <summary>
        /// 攻撃を知らせる。攻撃だったら、trueを返す。
        /// </summary>
        /// <param name="attack">攻撃元のインスタンス</param>
        /// <returns>敵の攻撃で、処理に登録したらtrue</returns>
        public bool Attack(AttackBase attack)
        {
            // 攻撃ではないか、オーナーなら何もしない
            if ((attack == null) || (attack.IsOwner(ownerName)))
            {
                return false;
            }

            AttackedTransforms.Add(attack.transform);
            return true;
        }
    }
}
