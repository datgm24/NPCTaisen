using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 操作やAIの指示から、アクションを呼び出す共通クラス。
    /// </summary>
    public abstract class InputToActionBase : ITaisenInput
    {
        /// <summary>
        /// 攻撃するときに、コントローラーに知らせるためのインスタンス
        /// </summary>
        protected IAttackActionListener attackActionListener;

        public InputToActionBase(IAttackActionListener listener)
        {
            attackActionListener = listener;
        }

        public abstract void InputToAction(IMovable move, IAttackActionable[] attacks);
    }
}
