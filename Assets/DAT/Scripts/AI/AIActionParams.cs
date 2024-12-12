using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// AIActionに渡すデータ
    /// </summary>
    public class AIActionParams
    {
        public DecideActionParams decideActionParams;
        public Transform myTransform;
        public Transform enemyTransform;

        /// <summary>
        /// 攻撃の採点処理のインスタンス2つ分。
        /// </summary>
        public IScoreMoveWithTransform[] attackScoring = new IScoreMoveWithTransform[2];

        public AIActionParams(DecideActionParams decideActionParams, Transform myTransform, IScoreMoveWithTransform[] attackScoring)
        {
            this.decideActionParams = decideActionParams;
            this.myTransform = myTransform;
            this.attackScoring = attackScoring;
            FindTransforms(myTransform);
        }

        public void FindTransforms(Transform myTransform)
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].transform != myTransform)
                {
                    enemyTransform = players[i].transform;
                    return;
                }
            }
        }
    }
}
