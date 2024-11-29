using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// ゲーム全体を統括するクラス。
    /// </summary>
    public class GameSystem : MonoBehaviour
    {
        public enum State
        {
            None = -1,
            Boot,
            HowTo,
            GamePlay,
            Result,
            Started,    // シーンを開始したら、この状態へ
            Reboot,
        }

        /// <summary>
        /// 勝負の有無
        /// </summary>
        public enum GameResultType
        {
            WinLose,
            Draw
        }

        static string HowToSceneName => "HowTo";
        static string GamePlaySceneName => "GamePlay";
        static string ResultSceneName => "Result";

        public State CurrentState { get; private set; } = State.None;
        State nextState = State.Boot;

        /// <summary>
        /// ゲームの勝敗
        /// </summary>
        public GameResultType GameResult { get; private set; }

        /// <summary>
        /// 勝者の名前。引き分けのときは空文字。
        /// </summary>
        public string Winner { get; private set; } = "";

        /// <summary>
        /// ゲームプレイを管理するシーンクラスのインスタンス。
        /// 起動時に取得する。
        /// </summary>
        GamePlay gamePlay;

        AsyncOperation asyncOperation;

        private void Update()
        {
            InitState();
            UpdateState();
        }

        /// <summary>
        /// 次のゲーム全体の状態を設定する。
        /// </summary>
        /// <param name="state">GameSystem.Stateで定義された状態</param>
        public void SetNextState(State state)
        {
            nextState = state;
        }

        /// <summary>
        /// 勝敗を受け取って、結果へ遷移する。
        /// </summary>
        /// <param name="result">IPlayResult.Stateの結果</param>
        public void SetResult(GameResultType result, string winner = "")
        {
            GameResult = result;
            Winner = winner;
            SetNextState(State.Result);
        }

        void InitState()
        {
            if (nextState == State.None)
            {
                return;
            }
            CurrentState = nextState;
            nextState = State.None;

            switch (CurrentState)
            {
                case State.Boot:
                    gamePlay = GameObject.FindObjectOfType<GamePlay>();
                    nextState = State.HowTo;
                    break;

                case State.HowTo:
                    asyncOperation = SceneManager.LoadSceneAsync(HowToSceneName, LoadSceneMode.Additive);
                    break;

                case State.Result:
                    asyncOperation = SceneManager.LoadSceneAsync(ResultSceneName, LoadSceneMode.Additive);
                    break;

                case State.GamePlay:
                    SceneManager.UnloadSceneAsync(HowToSceneName);
                    gamePlay.StartScene(this);
                    break;

                case State.Reboot:
                    SceneManager.LoadScene(GamePlaySceneName);
                    break;
            }
        }

        void UpdateState()
        {
            switch (CurrentState)
            {
                case State.HowTo:
                case State.Result:
                    WaitSceneLoaded();
                    break;
            }
        }

        /// <summary>
        /// シーンの非同期読み込みの完了を待つ。
        /// 完了していたら、シーンクラスのStartSceneを呼び出して、Startedへ遷移。
        /// </summary>
        void WaitSceneLoaded()
        {
            if (!asyncOperation.isDone)
            {
                return;
            }

            var sceneBehaviours = GameObject.FindObjectsOfType<SceneBehaviourBase>();
            for (int i = 0; i < sceneBehaviours.Length; i++)
            {
                if (sceneBehaviours[i] == gamePlay)
                {
                    continue;
                }

                // シーンを開始
                sceneBehaviours[i].StartScene(this);
                break;
            }

            nextState = State.Started;
        }
    }
}
