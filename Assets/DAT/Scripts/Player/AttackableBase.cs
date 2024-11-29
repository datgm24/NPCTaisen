using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 攻撃オブジェクトを制御するベースクラス
    /// </summary>
    public abstract class AttackableBase : MonoBehaviour, IAttackable
    {
        public abstract void Attack();
    }
}
