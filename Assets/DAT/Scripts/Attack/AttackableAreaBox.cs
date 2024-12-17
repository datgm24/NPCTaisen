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
            var count = Physics.OverlapBoxNonAlloc(
                boxCollider.bounds.center, boxCollider.size * 0.5f, colliders,
                boxCollider.transform.rotation, attackDetector, QueryTriggerInteraction.Collide);
            if (count == 0) { return; }

            var detector = colliders[0].GetComponent<AttackedDetector>();
            if (detector == null) { return; }

            detector.Attack(attackBase);
        }
    }
}
