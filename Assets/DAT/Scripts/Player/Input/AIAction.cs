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
        DecideActionParams decideActionParams;
        DecideMoveAction decideMoveAction;
        DecideAttackAction decideAttackAction;
        Transform myTransform;
        Transform enemyTransform;

        public AIAction(IAttackActionListener listener, DecideActionParams decideParams, Transform myTransformParam, Transform enemyTransformParam) : base(listener)
        {
            decideActionParams = decideParams;
            decideMoveAction = new(decideActionParams.moveParams);
            decideAttackAction = new(decideActionParams.attackParams);
            myTransform = myTransformParam;
            enemyTransform = enemyTransformParam;
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
            decideMoveAction.DecideAndAction(move, myTransform, enemyTransform);
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
