#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// ゲームプレイを管理。
    /// </summary>
    public class GamePlay : SceneBehaviourBase, IPlayResult
    {
        enum State
        {
            None = -1,
            Standby,
            GamePlay,
            ToResult,
        }

        State currentState = State.None;
        State nextState = State.None;

        public override void StartScene(GameSystem instance)
        {
            base.StartScene(instance);

            nextState = State.GamePlay;
        }

        private void Update()
        {
            InitState();
            UpdateState();
        }

    /// <summary>
    /// ゲームの勝敗を受け取る。
    /// </summary>
    /// <param name="state">IPlayResult.Stateで受け取る</param>
        public void SetResult(IPlayResult.State state)
        {
            nextState = State.ToResult;
            gameSystem.SetResult(state);
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
                case State.GamePlay:
                    InitGamePlay();
                    break;

                case State.ToResult:
                    break;
            }

        }

        /// <summary>
        /// ゲーム開始時の処理。
        /// </summary>
        void InitGamePlay()
        {
            var players = GameObject.FindObjectsOfType<PlayerController>();
            foreach (var player in players)
            {
                player.StartPlay(this);
            }
        }

        void UpdateState()
        {
            switch (currentState)
            {
                case State.GamePlay:
                    UpdateDebugKey();
                    break;
            }
        }

        [System.Diagnostics.Conditional("DEBUG_KEY")]
        void UpdateDebugKey()
        {
            if (Input.GetButtonDown("Debug1PWin"))
            {
                SetResult(IPlayResult.State.Win1P);
            }
            if (Input.GetButtonDown("Debug2PWin"))
            {
                SetResult(IPlayResult.State.Win2P);
            }
            if (Input.GetButtonDown("DebugDraw"))
            {
                SetResult(IPlayResult.State.Draw);
            }
        }
    }
}
