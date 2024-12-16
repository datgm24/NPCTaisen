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

        [Tooltip("攻撃する誤差角度"), SerializeField]
        float attackDegree = 2.5f;

        /// <summary>
        /// 内積を取った時に、この値以上なら一致とみなす値
        /// </summary>
        float matchedDot;

        /// <summary>
        /// 攻撃を判断する内積の値
        /// </summary>
        float attackDot;

        void Awake()
        {
            matchedDot = Mathf.Cos(matchedDegree * Mathf.Deg2Rad);
            attackDot = Mathf.Cos(attackDegree * Mathf.Deg2Rad);
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

            // 直交するうち、近づく方向のインデックスを得る
            Direction.Index nearOrthogonalIndex = aiActionParams.toEnemyInfo.GetOrthogonalNearDirection();
            Vector3 sideVector = Direction.Vector[(int)nearOrthogonalIndex];

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
            // 近すぎたら何もしない
            if (aiActionParams.toEnemyInfo.IsTooNear)
            {
                return DecideMoveAction.ActionType.Stop;
            }

            float sideDistance = aiActionParams.toEnemyInfo.GetMaxDot();
            if (sideDistance < attackDot)
            {
                return DecideMoveAction.ActionType.Stop;
            }

            // 最大に一致する方向へショット
            int index = (int)aiActionParams.toEnemyInfo.GetMaxDotDirection();

            return (DecideMoveAction.ActionType)(index + 1);
        }
    }
}
