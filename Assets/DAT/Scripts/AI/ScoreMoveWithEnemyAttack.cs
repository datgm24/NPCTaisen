using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 敵の攻撃から、移動用の得点を算出。
    /// </summary>
    public class ScoreMoveWithEnemyAttack : IScoreMove
    {
        ToTargetInfo toTargetInfo = new();

        /// <summary>
        /// 遠ざかる方向の配点
        /// </summary>
        static float FarPoint => 0.25f;

        /// <summary>
        /// 垂直に遠ざかる方向の配点
        /// </summary>
        static float FarOrthogonalPoint => 0.5f;

        /// <summary>
        /// 最高点
        /// </summary>
        static float MaxPoint => 1;

        public void ScoreMove(ref float[] scores, AIActionParams aiActionParams)
        {
            // スコアを0にしておく
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = 0;
            }

            int count = aiActionParams.attackedDetector.AttackedTransforms.Count;
            for (int i = 0; i < count; i++)
            {
                // 各方向の情報を計算
                var detector = aiActionParams.attackedDetector.AttackedTransforms[i];
                if (detector == null)
                {
                    continue;
                }

                Vector3 toTarget = detector.transform.position - aiActionParams.myTransform.position;

                // 攻撃の前方に対する垂直方向を求める
                toTargetInfo.Update(Vector3.zero, detector.transform.forward);
                var maxDir = toTargetInfo.GetMaxDotDirection();
                var farOrthogonalDirection = Direction.GetIndex(maxDir, -2);
                if (Vector3.Dot(Direction.Vector[(int)farOrthogonalDirection], toTarget) > 0)
                {
                    // 正方向の時は、近づくので反転させる
                    farOrthogonalDirection = Direction.GetReverseIndex(farOrthogonalDirection);
                }

                // 対象に近づく方向
                if (!toTargetInfo.Update(aiActionParams.myTransform.position, detector.position))
                {
                    continue;
                }
                var nearDirection = toTargetInfo.GetMaxDotDirection();
                // 遠ざかるベクトル
                var farVector = -Direction.Vector[(int)nearDirection];

                // 各方向の点数を判定
                int decrement = (int)Direction.GetIndex(farOrthogonalDirection, -1);
                int increment = (int)Direction.GetIndex(farOrthogonalDirection, 1);

                for (int j = 0; j < Direction.Count; j++)
                {
                    // 垂直に遠ざかる方向なら、満点
                    if (j == (int)farOrthogonalDirection)
                    {
                        scores[j + 1] += MaxPoint / (float)count;
                        continue;
                    }

                    // 垂直方向の加点
                    if ((decrement == j) || (increment == j))
                    {
                        scores[j + 1] += FarOrthogonalPoint / (float)count;
                    }

                    // 遠ざかる方向の加点
                    if (Vector3.Dot(farVector, Direction.Vector[j]) > 0)
                    {
                        scores[j + 1] += FarPoint / (float)count;
                    }
                }
            }

            aiActionParams.attackedDetector.Clear();
        }
    }
}
