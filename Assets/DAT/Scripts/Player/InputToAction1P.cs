using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 1プレイヤー用の操作からアクション呼び出すクラス
    /// </summary>
    public class InputToAction1P : ITaisenInput
    {
        public void InputToAction(IMovable move, IAttackable[] attacks)
        {
            Vector2 inputMove = Vector2.zero;
            inputMove.x = Input.GetAxisRaw("Horizontal1P");
            inputMove.y = Input.GetAxisRaw("Vertical1P");
            move.Move(inputMove);

            if (Input.GetButtonDown("Melee1P"))
            {
                attacks[0].Attack();
            }
            if (Input.GetButtonDown("Range1P"))
            {
                attacks[1].Attack();
            }
        }
    }
}
