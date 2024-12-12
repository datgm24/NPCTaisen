using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public static class ScoreFromEnemyDistance
    {
        /// <summary>
        /// 理想距離にいるとみなす距離
        /// </summary>
        static float IgnoreDistance => 0.1f;

        /// <summary>
        /// 敵からの理想的な距離へ移動するための
        /// 移動方向を採点する。
        /// 点数は、-1から1の範囲で、scoresに返す。
        /// </summary>
        /// <param name="scores">点数を返す先の配列の参照</param>
        /// <param name="myPosition">自分の座標</param>
        /// <param name="enemyPosition">敵の座標</param>
        /// <param name="targetDistance">理想距離</param>
        public static void Score(ref float[] scores, Vector3 myPosition, Vector3 enemyPosition, float targetDistance)
        {
            // 目的座標
            Vector3 toEnemy = enemyPosition - myPosition;
            Vector3 toTargetVector = -targetDistance * toEnemy.normalized;
            Vector3 targetPosition = enemyPosition + toTargetVector;

            // 到着判定
            if (Vector3.Distance(myPosition, targetPosition) <= IgnoreDistance)
            {
                scores[(int)DecideMoveAction.ActionType.Stop] = 1;
                return;
            }

            // 到着していないので、移動を選択
            scores[(int)DecideMoveAction.ActionType.Stop] = 0;
            Vector3 toTarget = targetPosition - myPosition;
            for (int i = 1; i < scores.Length; i++)
            {
                float angle = Mathf.Abs(Vector3.SignedAngle(toTarget, DecideMoveAction.ActionVector[i], Vector3.up));
                Debug.Log($"toTarget={toTarget} [{i}]={angle} actionVector={DecideMoveAction.ActionVector[i]}");
                // angle   score
                // 0       1
                // 90      0
                // 180     -1
                // # 90で引く
                //   0-90= -90      1
                //  90-90=   0      0
                // 180-90=  90      -1
                // # -90で割ってみる
                // -90/-90 = 1      1
                //   0/-90 = 0      0
                //  90/-90 = -1     -1
                // # 計算式
                // (angle-90)/-90
                // # 検算
                // angle = 45
                // (45-90)=-45/-90 = 0.5
                scores[i] = (angle - 90f) / -90f;
            }
        }
    }
}
