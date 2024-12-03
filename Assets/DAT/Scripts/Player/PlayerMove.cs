using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーを移動させるクラス。
    /// </summary>
    public class PlayerMove : MonoBehaviour, IMovable
    {
        [SerializeField]
        float speed = 4f;

        [SerializeField, Tooltip("停止させる入力値")]
        float ignoreInput = 0.1f;

        Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Move(Vector2 move)
        {
            if (move.magnitude < ignoreInput)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = Vector2.zero;
                return;
            }

            Vector3 v = rb.velocity;
            v.x = move.x;
            v.z = move.y;
            v.y = 0;
            rb.velocity = speed * v.normalized;

            transform.forward = v.normalized;
        }
    }
}
