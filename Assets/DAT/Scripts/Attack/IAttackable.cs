using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 攻撃オブジェクト用インターフェース
    /// </summary>
    public interface IAttackable
    {
        /// <summary>
        /// 出現時に、攻撃主の名前を受け取る。
        /// </summary>
        /// <param name="owner">攻撃主の名前</param>
        /// <param name="color">攻撃の色</param>
        void SetOwnerAndColor(string owner, Color color);

        /// <summary>
        /// 指定の名前と一致していたら、trueを返す。
        /// </summary>
        /// <param name="checkName">チェックする名</param>
        /// <returns>オーナーならtrue</returns>
        bool IsOwner(string checkName);
    }
}
