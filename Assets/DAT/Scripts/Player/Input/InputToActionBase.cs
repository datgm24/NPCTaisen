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
        /// 移動入力値
        /// </summary>
        protected Vector2 inputMove = Vector2.zero;
        /// <summary>
        /// 攻撃フラグ
        /// </summary>
        protected bool[] attackInputs = new bool[2];

        public abstract void UpdateInput();
        public abstract void InputToAction(IMovable move, IAttackActionable[] attacks);

        /// <summary>
        /// 人力入力から、アクションを実行する。
        /// </summary>
        /// <param name="move">移動オブジェクト</param>
        /// <param name="attacks">攻撃オブジェクト</param>
        protected void HumanInputToAction(IMovable move, IAttackActionable[] attacks)
        {
            move.Move(inputMove);

            for (int i = 0; i < attackInputs.Length; i++)
            {
                if (attackInputs[i])
                {
                    attacks[i].Attack();
                }
                attackInputs[i] = false;
            }
        }
    }
}
