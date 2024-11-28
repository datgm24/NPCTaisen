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

        State currentState = State.None;
        State nextState = State.None;

        ITaisenInput[] inputs =
        {
            new InputToAction1P(),
            new InputToAction2P(),
            null
        };

        private void Update()
        {
            InitState();
            UpdateState();
        }

        /// <summary>
        /// ゲームがはじまったら、GamePlayから、このメソッドを呼び出す。
        /// </summary>
        public void StartPlay()
        {
            nextState = State.Play;
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
            }
        }

    }
}
