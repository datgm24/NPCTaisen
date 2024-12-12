using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// AIに操作をさせるクラス。
    /// </summary>
    public class AIAction : InputToActionBase, ITaisenInput
    {
        DecideMoveAction decideMoveAction;
        DecideAttackAction decideAttackAction;
        AIActionParams aiActionParams;

        public AIAction(IAttackActionListener listener, AIActionParams aiParams) : base(listener)
        {
            aiActionParams = aiParams;
            decideMoveAction = new(aiParams.decideActionParams.moveParams);
            decideAttackAction = new(aiParams.decideActionParams.attackParams);
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
            // 最高点の行動
            decideMoveAction.DecideAndAction(move, aiActionParams);
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
