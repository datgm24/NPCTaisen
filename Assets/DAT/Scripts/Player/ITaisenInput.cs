using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// NPCTaisen用の入力操作からアクションを呼び出すインターフェース。
    /// </summary>
    public interface ITaisenInput
    {
        /// <summary>
        /// 入力やAIの判断から、行動を呼び出す。
        /// </summary>
        void InputToAction(IMoveable move, IAttack[] attacks);
    }
}
