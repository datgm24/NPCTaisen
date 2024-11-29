#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// ゲームプレイを管理。
    /// </summary>
    public class GamePlay : SceneBehaviourBase, IWinReportable
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

        // 勝ち名乗りをしたプレイヤーのインスタンス
        List<PlayerController> winReportPlayers = new List<PlayerController>(2);

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
        /// 勝利報告を受け取る。
        /// </summary>
        /// <param name="player">報告元のインスタンス</param>
        public void ReportWin(PlayerController player)
        {
            // 2重報告は不要
            if (winReportPlayers.Contains(player))
            {
                return;
            }

            winReportPlayers.Add(player);
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
                    UpdateGamePlay();
                    break;
            }
        }

        /// <summary>
        /// ゲーム中の処理。
        /// </summary>
        void UpdateGamePlay()
        {
            // 勝敗判定
            if (winReportPlayers.Count == 0)
            {
                return;
            }

            // 勝敗へ
            nextState = State.ToResult;

            // 引き分け
            if (winReportPlayers.Count == 2)
            {
                gameSystem.SetResult(GameSystem.GameResultType.Draw);
                return;
            }

            // 勝者を報告
            gameSystem.SetResult(GameSystem.GameResultType.WinLose, winReportPlayers[0].Name);
        }

        [System.Diagnostics.Conditional("DEBUG_KEY")]
        void UpdateDebugKey()
        {
            if (Input.GetButtonDown("Debug1PWin"))
            {
                var players = GameObject.FindObjectsOfType<PlayerController>();
                ReportWin(players[0]);
            }
            if (Input.GetButtonDown("Debug2PWin"))
            {
                var players = GameObject.FindObjectsOfType<PlayerController>();
                ReportWin(players[1]);
            }
            if (Input.GetButtonDown("DebugDraw"))
            {
                var players = GameObject.FindObjectsOfType<PlayerController>();
                ReportWin(players[0]);
                ReportWin(players[1]);
            }
        }
    }
}
