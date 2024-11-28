#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// ゲームプレイを管理。
    /// </summary>
    public class GamePlay : SceneBehaviourBase
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
                case State.ToResult:
                    break;
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
                nextState = State.ToResult;
                gameSystem.SetNextState(GameSystem.State.Result1P);
            }
            if (Input.GetButtonDown("Debug2PWin"))
            {
                nextState = State.ToResult;
                gameSystem.SetNextState(GameSystem.State.Result2P);
            }
            if (Input.GetButtonDown("DebugDraw"))
            {
                nextState = State.ToResult;
                gameSystem.SetNextState(GameSystem.State.ResultDraw);
            }
        }
    }
}
