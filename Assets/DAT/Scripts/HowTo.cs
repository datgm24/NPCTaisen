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
            Hided,
            HowTo,
            Credits
        }

        public override void StartScene(GameSystem instance)
        {
            base.StartScene(instance);

            animator.SetInteger("State", (int)State.HowTo);
        }
    }
}
