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

        public override void ScoreMove(ref float[] scores, AIActionParams aiActionParams)
        {
            // 最大の内積値を返す
            float maxDot = aiActionParams.toEnemyInfo.GetMaxDot();

            // すでに狙えていたら、停止
            if (aiActionParams.toEnemyInfo.IsTooNear || (maxDot >= matchedDot))
            {
                return;
            }

            // 敵がいる方向に一番近い方向をmaxIndexに求める
            Direction.Index maxIndex = aiActionParams.toEnemyInfo.GetMaxDotDirection();

            // 直交するインデックスを得る
            Direction.Index sideIndex = Direction.GetOrthogonalIndex(maxIndex);

            // 敵がいる側に設定
            float side2dot = aiActionParams.toEnemyInfo.GetDot(sideIndex);
            if (side2dot < 0)
            {
                sideIndex = Direction.GetReverseIndex(sideIndex);
            }
            Vector3 sideVector = Direction.Vector[(int)sideIndex];

            // 自分から敵へのベクトルに直交するベクトルを求める
            Vector3 toEnemy = aiActionParams.enemyTransform.position - aiActionParams.myTransform.position;
            Vector3 toEnemyOrthogonal = Vector3.Cross(toEnemy.normalized, Vector3.up);

            // toEnemyOrthogonalと、sideVectorの向きを揃える
            if (Vector3.Dot(toEnemyOrthogonal, sideVector) < 0)
            {
                toEnemyOrthogonal = -toEnemyOrthogonal;
            }

            // toEnemyOrthogonalと、各方向の内積を求めて、その値を得点とする
            // attackMoveRateを、答えに掛ける
            for (int i = (int)DecideMoveAction.ActionType.Up; i <= (int)DecideMoveAction.ActionType.UpLeft; i++)
            {
                scores[i] = attackMoveRate * Vector3.Dot(toEnemyOrthogonal, DecideMoveAction.ActionVector[i]);
            }
        }

        public override IAttackable SpawnAttack(string ownerName, Color attackColor)
        {
            var attackObject = base.SpawnAttack(ownerName, attackColor);
            return attackObject;
        }

        /// <summary>
        /// 攻撃する判定。攻撃するなら、向きを設定する。
        /// </summary>
        /// <returns></returns>
        public override DecideMoveAction.ActionType TryAttack(AIActionParams aiActionParams)
        {
            return DecideMoveAction.ActionType.Up;
        }
    }
}
