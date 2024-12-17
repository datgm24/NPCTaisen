using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 2プレイヤー用の操作からアクション呼び出すクラス
    /// </summary>
    public class InputToAction2P : InputToActionBase, ITaisenInput
    {
        public override void UpdateInput()
        {
            inputMove = Vector2.zero;
            inputMove.x = Input.GetAxisRaw("Horizontal2P");
            inputMove.y = Input.GetAxisRaw("Vertical2P");

            attackInputs[0] |= Input.GetButtonDown("Melee2P");
            attackInputs[1] |= Input.GetButtonDown("Range2P");
        }

        public override void InputToAction(IMovable move, IAttackActionable[] attacks)
        {
            HumanInputToAction(move, attacks);
        }
    }
}
