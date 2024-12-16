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
        public ToTargetInfo toEnemyInfo = new();
        public AttackedDetector attackedDetector;

        /// <summary>
        /// 攻撃の採点処理のインスタンス2つ分。
        /// </summary>
        public IScoreMove[] attackScoring = new IScoreMove[2];

        public AIActionParams(DecideActionParams decideActionParams, Transform myTransform, IScoreMove[] attackScoring, AttackedDetector attackedDetector)
        {
            this.decideActionParams = decideActionParams;
            this.myTransform = myTransform;
            this.attackScoring = attackScoring;
            FindTransforms(myTransform);
            this.attackedDetector = attackedDetector;
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
