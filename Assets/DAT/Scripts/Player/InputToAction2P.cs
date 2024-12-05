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
        public InputToAction2P(IAttackActionListener listener) : base(listener) { }

        public override void InputToAction(IMovable move, IAttackActionable[] attacks)
        {
            Vector2 inputMove = Vector2.zero;
            inputMove.x = Input.GetAxisRaw("Horizontal2P");
            inputMove.y = Input.GetAxisRaw("Vertical2P");
            move.Move(inputMove);

            if (Input.GetButtonDown("Melee2P"))
            {
                attacks[0].Attack(attackActionListener);
            }
            if (Input.GetButtonDown("Range2P"))
            {
                attacks[1].Attack(attackActionListener);
            }
        }
    }
}
