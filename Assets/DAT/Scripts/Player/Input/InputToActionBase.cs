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
        public abstract void InputToAction(IMovable move, IAttackActionable[] attacks);
    }
}
