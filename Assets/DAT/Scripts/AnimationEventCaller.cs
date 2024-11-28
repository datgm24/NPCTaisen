using UnityEngine;
using UnityEngine.Events;

namespace DAT.NPCTaisen
{
    public class AnimationEventCaller : MonoBehaviour
    {
        [SerializeField]
        UnityEvent animated = default;

        /// <summary>
        /// アニメのイベントから呼び出して、登録しているイベントを呼び出す。
        /// </summary>
        public void OnAnimated()
        {
            animated.Invoke();
        }
    }
}
