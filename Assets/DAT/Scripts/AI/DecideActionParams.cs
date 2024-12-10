using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    [CreateAssetMenu(fileName = "DecideActionParams", menuName ="DAT/Create Decide Action Params")]
    public class DecideActionParams : ScriptableObject
    {
        [Tooltip("移動用パラメーター")]
        public DecideMoveParams moveParams = new();

        [Tooltip("攻撃用パラメーター")]
        public DecideAttackParams attackParams = new();
    }
}
