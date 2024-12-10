using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// AIに操作をさせるクラス。
    /// </summary>
    public class AIAction : InputToActionBase, ITaisenInput
    {
        DecideActionParams decideActionParams;
        DecideMoveAction decideMoveAction = new();
        DecideAttackAction decideAttackAction = new();

        public AIAction(IAttackActionListener listener, DecideActionParams decideActionParams) : base(listener)
        {
            this.decideActionParams = decideActionParams;
        }

        public override void InputToAction(IMovable move, IAttackActionable[] attacks)
        {
            MoveAction(move);
            AttackAction(attacks);
        }

        /// <summary>
        /// 移動の決定と行動。
        /// </summary>
        /// <param name="move">移動指示先</param>
        void MoveAction(IMovable move)
        {
            // 移動の決定処理
            decideMoveAction.Clear();

            // 加点


            // 最高点の行動
            decideMoveAction.DecideAndAction(move);
        }

        /// <summary>
        /// 攻撃の決定と行動。
        /// </summary>
        /// <param name="attacks">攻撃指示先</param>
        void AttackAction(IAttackActionable[] attacks)
        {

        }
    }
}
