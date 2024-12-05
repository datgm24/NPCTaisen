using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public interface IDamageable
    {
        /// <summary>
        /// 攻撃主の名前を受け取って、攻撃があたったときの処理を実行する。
        /// 自分が同じ名前なら、攻撃した本人なので、falseを返して何もしない。
        /// </summary>
        /// <param name="ownerName">攻撃者の名前</param>
        /// <returns>他人からの攻撃なら、true。自分の攻撃だったらfalse</returns>
        bool Damage(string ownerName);
    }
}
