using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーを統括制御するクラス。
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public enum State
        {
            None = -1,
            Standby,
            Play,
            Win,
            Lose,
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

        [SerializeField, Tooltip("攻撃を2つ設定する。")]
        AttackableBase [] attackables = new AttackableBase[2];

        /// <summary>
        /// プレイヤー名
        /// </summary>
        public string Name { get { return playerName; } }

        State currentState = State.None;
        State nextState = State.Standby;

        ITaisenInput[] inputs =
        {
            new InputToAction1P(),
            new InputToAction2P(),
            null
        };

        IMoveable moveable = null;

        GamePlay gamePlay = null;

        private void Awake()
        {
            moveable = GetComponent<IMoveable>();
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
            nextState = State.Play;
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
                case State.Play:
                    UpdatePlay();
                    break;
            }
        }

        /// <summary>
        /// 操作の更新処理
        /// </summary>
        void UpdatePlay()
        {
            // 入力からアクションを実行させる
            inputs[(int)controlType].InputToAction(moveable, attackables);
        }
    }
}
