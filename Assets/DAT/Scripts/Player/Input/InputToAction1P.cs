using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 1プレイヤー用の操作からアクション呼び出すクラス
    /// </summary>
    public class InputToAction1P : InputToActionBase, ITaisenInput
    {
        public override void UpdateInput()
        {
            inputMove = Vector2.zero;
            inputMove.x = Input.GetAxisRaw("Horizontal1P");
            inputMove.y = Input.GetAxisRaw("Vertical1P");

            attackInputs[0] |= Input.GetButtonDown("Melee1P");
            attackInputs[1] |= Input.GetButtonDown("Range1P");
        }

        public override void InputToAction(IMovable move, IAttackActionable[] attacks)
        {
            HumanInputToAction(move, attacks);
        }
    }
}
