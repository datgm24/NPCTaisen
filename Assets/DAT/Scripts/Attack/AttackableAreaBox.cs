using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 攻撃範囲
    /// </summary>
    public class AttackableAreaBox : MonoBehaviour
    {
        BoxCollider boxCollider;
        int attackDetector;
        Collider[] colliders = new Collider[1];
        AttackBase attackBase;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider>();
            attackDetector = LayerMask.GetMask("AttackDetector");
            attackBase = GetComponentInParent<AttackBase>();
        }

        void FixedUpdate()
        {
            Debug.Log($"cast {boxCollider.bounds.center}, {boxCollider.bounds.extents} ");

            var count = Physics.OverlapBoxNonAlloc(
                boxCollider.bounds.center, boxCollider.bounds.extents, colliders,
                boxCollider.transform.rotation, attackDetector, QueryTriggerInteraction.Collide);
            if (count == 0) { return; }

            Debug.Log($"count on");

            var detector = colliders[0].GetComponent<AttackedDetector>();
            if (detector == null) { return; }

            Debug.Log($"call attack");
            detector.Attack(attackBase);
        }
    }
}
