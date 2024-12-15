using System.Runtime.ExceptionServices;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public class DecideMoveAction : DecideActionBase, IDecideAction
    {
        public enum ActionType
        {
            Stop,
            Up,
            UpRight,
            Right,
            DownRight,
            Down,
            DownLeft,
            Left,
            UpLeft,
        }

        public static readonly Vector2[] MoveVector = new Vector2[]
        {
            Vector2.zero,
            Vector2.up,
            (Vector2.up + Vector2.right).normalized,
            Vector2.right,
            (Vector2.right + Vector2.down).normalized,
            Vector2.down,
            (Vector2.down + Vector2.left).normalized,
            Vector2.left,
            (Vector2.up + Vector2.left).normalized,
        };

        public static readonly Vector3[] ActionVector = new Vector3[]
        {
            Vector3.zero,
            Vector3.forward,
            (Vector3.forward + Vector3.right).normalized,
            Vector3.right,
            (Vector3.right + Vector3.back).normalized,
            Vector3.back,
            (Vector3.back + Vector3.left).normalized,
            Vector3.left,
            (Vector3.forward + Vector3.left).normalized,
        };

        /// <summary>
        /// 移動に関するパラメーター
        /// </summary>
        DecideMoveParams decideMoveParams;

        /// <summary>
        /// 採点配列
        /// </summary>
        float[] scores = new float[System.Enum.GetValues(typeof(ActionType)).Length];

        public DecideMoveAction(DecideMoveParams moveParams)
        {
            this.decideMoveParams = moveParams;
            Init(System.Enum.GetValues(typeof(ActionType)).Length);
        }

        /// <summary>
        /// 判定と行動。
        /// </summary>
        /// <param name="move">移動のためのインターフェース</param>
        public void DecideAndAction(IMovable move, AIActionParams aiActionParams)
        {
            // 加点
            Clear();

            // 敵からの理想距離
            ClearScores();
            ScoreFromEnemyDistance.Score(ref scores, aiActionParams.myTransform.position, aiActionParams.enemyTransform.position, decideMoveParams.fromEnemyDistance);
            AddScores(decideMoveParams.fromEnemyWeight);

            // 攻撃の採点
            for (int i = 0; i < aiActionParams.attackScoring.Length; i++)
            {
                aiActionParams.attackScoring[i].ScoreMove(ref scores, aiActionParams);
                AddScores(decideMoveParams.attackWeight);
            }

            // 移動実行
            move.Move(MoveVector[Decision]);
        }

        /// <summary>
        /// 指定のウェイトに従って、scoresの値を、加点していく。
        /// </summary>
        /// <param name="weight">評価倍率</param>
        void AddScores(float weight)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                AddPoint(i, weight * scores[i]);
                scores[i] = 0;
            }
        }

        /// <summary>
        /// 戻り値のスコアを0にする。
        /// </summary>
        void ClearScores()
        {
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = 0;
            }
        }
    }
}