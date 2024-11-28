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
        public override void StartScene(GameSystem instance)
        {
            base.StartScene(instance);

            Debug.Log($"ゲーム開始");
        }
    }
}
