using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーの近接攻撃アクションの実装。
    /// コンクリート（具象）クラスなので、べた書きでよい。
    /// </summary>
    public class MeleeAction : AttackActionBase, IAttackActionable
    {
        public override bool Attack()
        {
            if (!base.Attack())
            {
                return false;
            }

            return true;
        }

        public override IAttackable SpawnAttack(string ownerName, Color attackColor)
        {
            var attackObject = base.SpawnAttack(ownerName, attackColor);
            return attackObject;
        }

        public override void ScoreMove(ref float[] scores, AIActionParams aiActionParams)
        {
            Debug.Log($"近距離攻撃をあてようとする移動採点");
        }

        public override DecideMoveAction.ActionType TryAttack(AIActionParams aiActionParams)
        {
            return DecideMoveAction.ActionType.Stop;
        }
    }
}
