using UnityEngine;

namespace DAT.NPCTaisen
{
    public class DecideMoveAction : DecideActionBase, IDecideAction
    {
        enum ActionType
        {
            None,
            Up,
            UpRight,
            Right,
            DownRight,
            Down,
            DownLeft,
            Left,
            UpLeft,
        }

        readonly Vector2[] moveVector = new Vector2[]
        {
            Vector2.zero,
            Vector2.up,
            (Vector2.up + Vector2.right).normalized,
            Vector2.right,
            (Vector2.right + Vector2.down).normalized,
            Vector2.down,
            (Vector2.down + Vector2.left).normalized,
            Vector2.left,
            (Vector2.up + Vector2.left).normalized,
        };

        /// <summary>
        /// 判定と行動。
        /// </summary>
        /// <param name="move">移動のためのインターフェース</param>
        public void DecideAndAction(IMovable move)
        {
            move.Move(moveVector[Decision]);
        }
    }
}
