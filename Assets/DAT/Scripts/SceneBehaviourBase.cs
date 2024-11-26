using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// ゲームシーンを管理するクラスの基底クラス。
    /// </summary>
    public class SceneBehaviourBase : MonoBehaviour, ISceneBehaviour
    {
        protected GameSystem gameSystem;

        public virtual void StartScene(GameSystem instance)
        {
            gameSystem = instance;
        }
    }
}
