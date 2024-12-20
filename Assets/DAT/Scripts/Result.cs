using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DAT.NPCTaisen
{
    public class Result : SceneBehaviourBase
    {
        static readonly string[] ResultText =
        {
            " WIN!!",
            "DRAW"
        };

        enum State
        {
            None = -1,
            Show,
            Hiding,
            Hided,
        }

        State currentState = State.None;

        [SerializeField]
        TextMeshProUGUI resultText = default;
        [SerializeField]
        Animator animator = default;

        bool isAnimating = true;

        public override void StartScene(GameSystem instance)
        {
            base.StartScene(instance);

            resultText.text = $"{instance.Winner}{ResultText[(int)gameSystem.GameResult]}";

            currentState = State.Show;
            animator.SetBool("Show", true);
        }

        private void Update()
        {
            if (isAnimating)
            {
                return;
            }

            switch (currentState)
            {
                case State.Show:
                    UpdateWaitKey();
                    break;

                case State.Hiding:
                    UpdateNext();
                    break;
            }
        }

        public void OnAnimated()
        {
            isAnimating = false;
        }

        void UpdateWaitKey()
        {
            if (Input.GetButtonDown("Start"))
            {
                currentState = State.Hiding;
                isAnimating = true;
                animator.SetBool("Show", false);
            }
        }

        void UpdateNext()
        {
            if (isAnimating)
            {
                return;
            }

            currentState = State.Hided;
            gameSystem.SetNextState(GameSystem.State.Reboot);
        }
    }
}
