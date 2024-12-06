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

        [SerializeField]
        ControlType controlType =ControlType.P1;

        [SerializeField]
        string playerName = "";

        [SerializeField, Tooltip("攻撃アクションを2つ設定する。")]
        AttackActionBase [] attackActions = new AttackActionBase[2];

        [SerializeField, Tooltip("攻撃色")]
        Color attackColor = Color.white;

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

        Animator animator;

        private void Awake()
        {
            moveable = GetComponent<IMovable>();
            animator = GetComponent<Animator>();
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
                case State.Move:
                    animator.SetInteger("State", (int)PlayerAnimationState.Walk);
                    break;

                case State.Attack:
                    InitAttack();
                    break;
            }
        }

        /// <summary>
        /// 攻撃の初期化
        /// </summary>
        void InitAttack()
        {
            if (attacking == null)
            {
                nextState = State.Move;
                return;
            }

            animator.SetInteger("State", (int)attacking.AnimationState);
            moveable.Move(Vector2.zero);
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
            if (currentState != State.Attack)
            {
                return;
            }

            attacking.SpawnAttack(transform, playerName, attackColor);
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
