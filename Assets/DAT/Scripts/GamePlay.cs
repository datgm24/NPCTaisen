#define DEBUG_KEY

using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// ゲームプレイを管理。
    /// </summary>
    public class GamePlay : SceneBehaviourBase, ILoseReportable
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

        /// <summary>
        /// プレイヤーのインスタンス
        /// </summary>
        PlayerController[] players;

        // 勝ち名乗りをしたプレイヤーのインスタンス
        List<PlayerController> loseReportPlayers = new List<PlayerController>(2);

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
        /// 負け報告を受け取る。
        /// </summary>
        /// <param name="player">報告元のインスタンス</param>
        public void ReportLose(PlayerController player)
        {
            // 2重報告は不要
            if (loseReportPlayers.Contains(player))
            {
                return;
            }

            loseReportPlayers.Add(player);
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
            players = GameObject.FindObjectsOfType<PlayerController>();
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
            if (loseReportPlayers.Count == 0)
            {
                return;
            }

            // 勝敗へ
            nextState = State.ToResult;

            // 引き分け
            if (loseReportPlayers.Count == 2)
            {
                gameSystem.SetResult(GameSystem.GameResultType.Draw);
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].SetDraw();
                }
                return;
            }

            // 勝者を報告
            for (int i = 0; i < players.Length; i++)
            {
                bool isLose = false;
                for (int j = 0; j < loseReportPlayers.Count; j++)
                {
                    if (players[i] == loseReportPlayers[j])
                    {
                        isLose = true;
                        players[i].SetLose();
                        break;
                    }
                }

                if (!isLose)
                {
                    // 勝者を設定
                    gameSystem.SetResult(GameSystem.GameResultType.WinLose, players[i].Name);
                    players[i].SetWin();
                }
            }
        }

        [System.Diagnostics.Conditional("DEBUG_KEY")]
        void UpdateDebugKey()
        {
            if (Input.GetButtonDown("Debug1PWin"))
            {
                ReportLose(players[1]);
            }
            if (Input.GetButtonDown("Debug2PWin"))
            {
                ReportLose(players[0]);
            }
            if (Input.GetButtonDown("DebugDraw"))
            {
                ReportLose(players[0]);
                ReportLose(players[1]);
            }
        }
    }
}
