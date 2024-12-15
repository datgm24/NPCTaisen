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

        enum State
        {
            None = -1,
            Walk,
            Attack,
        }

        State currentState = State.None;
        State nextState = State.Walk;
        float waitTime;
        AttackActionBase[] attackActions;

        public AIAction(IAttackActionListener listener, AIActionParams aiParams, AttackActionBase[] attacks) : base(listener)
        {
            aiActionParams = aiParams;
            decideMoveAction = new(aiParams.decideActionParams.moveParams);
            decideAttackAction = new(aiParams.decideActionParams.attackParams);
            attackActions = attacks;
        }

        public override void InputToAction(IMovable move, IAttackActionable[] attacks)
        {
            InitState();
            UpdateState(move);
        }

        void InitState()
        {
            if (nextState == State.None)
            {
                return;
            }
            currentState = nextState;
            nextState = State.None;

            switch (currentState)
            {
                case State.Attack:
                    waitTime = 0;
                    break;
            }
        }

        void UpdateState(IMovable move)
        {
            switch (currentState)
            {
                case State.Walk:
                    aiActionParams.toEnemyInfo.Update(
                        aiActionParams.myTransform.position,
                        aiActionParams.enemyTransform.position);
                    UpdateWalk(move);
                    break;

                case State.Attack:
                    UpdateAttack(move);
                    break;
            }
        }

        /// <summary>
        /// 歩き状態の更新処理
        /// </summary>
        /// <param name="move"></param>
        void UpdateWalk(IMovable move)
        {
            if (decideAttackAction.TryAttackAndMove(move, aiActionParams, attackActions))
            {
                // 攻撃開始
                nextState = State.Attack;
            }
            else
            {
                // 歩きを実行
                decideMoveAction.DecideAndAction(move, aiActionParams);
            }
        }

        /// <summary>
        /// 攻撃更新
        /// </summary>
        void UpdateAttack(IMovable move)
        {
            move.Move(Vector2.zero);

            waitTime += Time.deltaTime;
            if (waitTime < aiActionParams.decideActionParams.attackParams.untilAttackSeconds)
            {
                return;
            }

            decideAttackAction.BeginAttack();
            nextState = State.Walk;
        }
    }
}
