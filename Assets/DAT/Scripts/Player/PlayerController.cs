using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーを統括制御するクラス。
    /// </summary>
    public class PlayerController : MonoBehaviour, IAttackActionListener
    {
        public enum State
        {
            None = -1,
            Standby,
            Move,
            Attack,
            Win,
            Lose,
            Draw,
        }

        /// <summary>
        /// 操作の種類
        /// </summary>
        public enum ControlType
        {
            P1,
            P2,
            AI,
        }

        public enum AnimationState
        {
            Walk,
            MeleeAttack,
            RangedAttack,
        }

        [SerializeField]
        ControlType controlType =ControlType.P1;

        [SerializeField]
        string playerName = "";

        [SerializeField, Tooltip("攻撃アクションを2つ設定する。")]
        AttackActionBase [] attackActions = new AttackActionBase[2];

        /// <summary>
        /// プレイヤー名
        /// </summary>
        public string Name { get { return playerName; } }

        State currentState = State.None;
        State nextState = State.Standby;

        ITaisenInput[] inputs;

        IMovable moveable = null;

        GamePlay gamePlay = null;

        /// <summary>
        /// 攻撃中のアクションのインスタンス
        /// </summary>
        IAttackActionable attacking;

        private void Awake()
        {
            moveable = GetComponent<IMovable>();
            inputs = new ITaisenInput[]
            {
                new InputToAction1P(this),
                new InputToAction2P(this),
                null
            };
        }

        private void Update()
        {
            InitState();
            UpdateState();
        }

        /// <summary>
        /// ゲームがはじまったら、GamePlayから、このメソッドを呼び出す。
        /// </summary>
        public void StartPlay(GamePlay play)
        {
            nextState = State.Move;
            gamePlay = play;
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
            }
        }

        void UpdateState()
        {
            switch (currentState)
            {
                case State.Move:
                    UpdateMove();
                    break;
            }

            // 攻撃の更新
            for (int i = 0; i < attackActions.Length; i++)
            {
                attackActions[i].Update();
            }
        }

        /// <summary>
        /// 操作の更新処理
        /// </summary>
        void UpdateMove()
        {
            // 入力からアクションを実行させる
            inputs[(int)controlType].InputToAction(moveable, attackActions);
        }

        public void OnAttacking(IAttackActionable attack)
        {
            attacking = attack;
            nextState = State.Attack;
        }

        /// <summary>
        /// 攻撃フレームになったら、アニメから呼び出す。
        /// </summary>
        public void OnAttackFrame()
        {
            Debug.Log($"攻撃開始");
        }

        /// <summary>
        /// 攻撃アニメが終わったら、アニメから呼び出す。
        /// </summary>
        public void OnAttacked()
        {
            nextState = State.Move;
        }
    }
}
