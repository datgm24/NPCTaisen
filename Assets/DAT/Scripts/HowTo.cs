using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 操作説明シーンの管理スクリプト
    /// </summary>
    public class HowTo : SceneBehaviourBase
    {
        [SerializeField]
        Animator animator = default;

        enum State
        {
            None = -1,
            Hided,
            HowTo,
            Credits,
            GameStart,
        }

        State currentState = State.None;
        State nextState = State.Hided;
        bool isAnimating;

        public override void StartScene(GameSystem instance)
        {
            base.StartScene(instance);

            nextState = State.HowTo;
        }

        private void Update()
        {
            InitState();
            UpdateState();
        }

        /// <summary>
        /// アニメーションが終わった時に呼び出す。
        /// </summary>
        public void AnimationDone()
        {
            isAnimating = false;
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
                case State.HowTo:
                    animator.SetInteger("State", (int)State.HowTo);
                    isAnimating = true;
                    break;

                case State.Credits:
                    animator.SetInteger("State", (int)State.Credits);
                    isAnimating = true;
                    break;

                case State.GameStart:
                    animator.SetInteger("State", (int)State.Hided);
                    isAnimating = true;
                    break;
            }
        }

        void UpdateState()
        {
            switch (currentState)
            {
                case State.HowTo:
                    UpdateHowTo();
                    break;

                case State.Credits:
                    UpdateCredits();
                    break;

                case State.GameStart:
                    UpdateGameStart();
                    break;
            }
        }

        void UpdateHowTo()
        {
            if (isAnimating)
            {
                return;
            }

            if (Input.GetButtonDown("Credits"))
            {
                nextState = State.Credits;
            }
            else if (Input.GetButtonDown("Start"))
            {
                nextState = State.GameStart;
            }
        }

        void UpdateCredits()
        {
            if (isAnimating)
            {
                return;
            }

            if (Input.GetButtonDown("Cancel"))
            {
                nextState = State.HowTo;
            }
        }

        void UpdateGameStart()
        {
            if (isAnimating)
            {
                return;
            }

            gameSystem.SetNextState(GameSystem.State.GamePlay);
        }
    }
}
