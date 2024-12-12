using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public class DecideAttackAction : DecideActionBase, IDecideAction
    {
        enum ActionType
        {
            None,
            Melee,
            Ranged,
        }

        DecideAttackParams decideAttackParams;

        public DecideAttackAction(DecideAttackParams decideParams)
        {
            Init(System.Enum.GetValues(typeof(ActionType)).Length);
            decideAttackParams = decideParams;
        }

    }
}
