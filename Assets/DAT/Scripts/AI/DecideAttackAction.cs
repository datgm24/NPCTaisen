using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public class DecideAttackAction : DecideActionBase, IDecideAction
    {
        enum ActionType
        {
            None,
            Melee,
            Ranged,
        }

        DecideAttackParams decideAttackParams;

        public DecideAttackAction(DecideAttackParams decideParams)
        {
            Init(System.Enum.GetValues(typeof(ActionType)).Length);
            decideAttackParams = decideParams;
        }

        IAttackActionable attackActionable;

        /// <summary>
        /// 攻撃開始するかを判断して、攻撃するならその方向を向いて、trueを返す。
        /// </summary>
        /// <param name="move">向きを変えるための移動インスタンス</param>
        /// <param name="attacks">攻撃操作のインスタンス</param>
        /// <returns>攻撃を開始するならtrue</returns>
        public bool TryAttackAndMove(IMovable move, AIActionParams aiActionParams, AttackActionBase[] attacks)
        {
            /*
            for (int i = 0; i < attacks.Length; i++)
            {
                var decision = attacks[i].TryAttack(aiActionParams);
                if (decision != DecideMoveAction.ActionType.Stop)
                {
                    attackActionable = attacks[i];
                    move.Move(DecideMoveAction.MoveVector[(int)decision]);
                    return true;
                }
            }
            */
            return false;
        }

        public void BeginAttack()
        {
            attackActionable?.Attack();
        }
    }
}
