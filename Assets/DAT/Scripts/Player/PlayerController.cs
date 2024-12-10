using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーを統括制御するクラス。
    /// </summary>
    public class PlayerController : MonoBehaviour, IAttackActionListener, IDamageable
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

        [SerializeField]
        DecideActionParams decideActionParams;

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
                new AIAction(this, decideActionParams),
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

        /// <summary>
        /// 勝ったら呼び出す
        /// </summary>
        public void SetWin()
        {
            nextState = State.Win;
        }

        /// <summary>
        /// 負けたら呼び出す
        /// </summary>
        public void SetLose()
        {
            nextState = State.Lose;
        }

        public void SetDraw()
        {
            nextState = State.Draw;
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

                case State.Win:
                case State.Lose:
                case State.Draw:
                    moveable.Move(Vector2.zero);
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
            if ((currentState == State.Move) && (nextState == State.None))
            {
                attacking = attack;
                nextState = State.Attack;
            }
        }

        /// <summary>
        /// 攻撃フレームになったら、アニメから呼び出す。
        /// </summary>
        public void OnAttackFrame()
        {
            if ((currentState != State.Attack) || (nextState != State.None))
            {
                return;
            }

            attacking.SpawnAttack(playerName, attackColor);
        }

        /// <summary>
        /// 攻撃アニメが終わったら、アニメから呼び出す。
        /// </summary>
        public void OnAttacked()
        {
            animator.SetInteger("State", (int)PlayerAnimationState.Walk);
            if ((currentState == State.Attack) && (nextState == State.None))
            {
                nextState = State.Move;
            }
        }

        public bool Damage(string ownerName)
        {
            // 自分の弾なら、ヒットしない
            if (playerName == ownerName)
            {
                return false;
            }

            // 敵の弾なので、死亡
            gamePlay.ReportLose(this);
            return true;
        }
    }
}
