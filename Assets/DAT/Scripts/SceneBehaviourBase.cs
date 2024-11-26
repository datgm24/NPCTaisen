using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// ゲームシーンを管理するクラスの基底クラス。
    /// </summary>
    public class SceneBehaviourBase : MonoBehaviour, ISceneBehaviour
    {
        GameSystem gameSystem;

        public void StartScene(GameSystem instance)
        {
            gameSystem = instance;
        }
    }
}
