using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// プレイヤーの遠距離攻撃アクションの実装。
    /// コンクリート（具象）クラスなので、べた書きでよい。
    /// </summary>
    public class RangedAction : AttackActionBase, IAttackActionable
    {
        [Tooltip("一致とみなす角度の誤差を度数で設定"), SerializeField]
        float matchedDegree = 2.5f;

        /// <summary>
        /// 内積を取った時に、この値以上なら一致とみなす値
        /// </summary>
        float matchedDot;

        void Awake()
        {
            matchedDot = Mathf.Cos(matchedDegree * Mathf.Deg2Rad);
        }

        public override void ScoreMove(ref float[] scores, Transform myTransform, Transform enemyTransform)
        {
            Vector3 toEnemy = (enemyTransform.position - myTransform.position);
            toEnemy.y = 0;
            Vector3 toEnemyNormalized = toEnemy.normalized;
            int index = (int)DecideMoveAction.ActionType.Up;
            float maxDot = Vector3.Dot(toEnemyNormalized, DecideMoveAction.ActionVector[index]);

            // 右上から左上まで
            for (int i = (int)DecideMoveAction.ActionType.UpRight ; i <= (int)DecideMoveAction.ActionType.UpLeft; i++)
            {
                float dot = Vector3.Dot(toEnemyNormalized, DecideMoveAction.ActionVector[i]);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    index = i;
                }
            }

            // すでに狙えていたら、停止
            if (maxDot >= matchedDot)
            {
                scores[(int)DecideMoveAction.ActionType.Stop] = 0;
                return;
            }

            // 直行していて、敵がいる側のベクトルを求める
            int plus2 = ((index + 2 - 1) % 8) + 1;
            int minus2 = (index - 2);
            if (minus2 < (int)DecideMoveAction.ActionType.Up)
            {
                minus2 += (int)DecideMoveAction.ActionType.UpLeft;
            }
            Vector3 targetVector = DecideMoveAction.ActionVector[plus2];
            float plus2dot = Vector3.Dot(toEnemyNormalized, targetVector);
            if (plus2dot < 0)
            {
                targetVector = DecideMoveAction.ActionVector[minus2];
            }

            // 自分から敵へのベクトルに直交するベクトルを求める
            Vector3 toEnemyTangent = Vector3.Cross(toEnemyNormalized, Vector3.up);

            // toEnemyTangentと、targetVectorの向きを揃える
            if (Vector3.Dot(toEnemyTangent, targetVector) < 0)
            {
                toEnemyTangent = -toEnemyTangent;
            }

            // toEnemyTangentと、各方向の内積を求めて、その値を得点とする
            // attackMoveRateを、答えに掛ける
            for (int i=(int)DecideMoveAction.ActionType.Up; i<=(int)DecideMoveAction.ActionType.UpLeft; i++)
            {
                scores[i] = attackMoveRate * Vector3.Dot(toEnemyTangent, DecideMoveAction.ActionVector[i]);
            }
        }

        public override IAttackable SpawnAttack(string ownerName, Color attackColor)
        {
            var attackObject = base.SpawnAttack(ownerName, attackColor);
            return attackObject;
        }

        public override DecideMoveAction.ActionType TryAttack(Transform myTransform, Transform enemyTransform)
        {
            return DecideMoveAction.ActionType.Up;
        }
    }
}
