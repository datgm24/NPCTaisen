using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 敵に関する情報を収集して、取り出せる情報クラス
    /// </summary>
    public class ToEnemyInfo
    {
        /// <summary>
        /// 距離が近いと判断するデフォルト値
        /// </summary>
        const float NearDistance = 0.1f;

        /// <summary>
        /// 8方向ごとの敵へのベクトルとの内積
        /// </summary>
        float[] dots = new float[Direction.Count];

        /// <summary>
        /// 敵へのベクトルに対する、8方向の射影距離。完全一致なら、敵ベクトルまでの距離。要素がなければ0
        /// </summary>
        float[] distances = new float[Direction.Count];

        /// <summary>
        /// 距離が近すぎたら、true
        /// </summary>
        public bool IsTooNear { get; private set; }

        Vector3 toEnemy;
        int maxIndex;

        /// <summary>
        /// 自分と敵の座標を受け取って、8方向に対して内積と距離を求める。
        /// </summary>
        /// <param name="me">自分の座標</param>
        /// <param name="enemy">敵の座標</param>
        /// <param name="minDistance">最小距離。これ以上、距離が近いときは、</param>
        /// <returns>距離を求めたらtrue。近すぎたらfalse</returns>
        public bool Update(Vector3 me, Vector3 enemy, float minDistance = NearDistance)
        {
            toEnemy = enemy - me;
            if (toEnemy.magnitude <= minDistance)
            {
                IsTooNear = true;
                return false;
            }

            IsTooNear = false;
            Vector3 toEnemyNormal = toEnemy.normalized;
            float maxDot = 0;
            for (int i = 0; i < Direction.Count; i++)
            {
                dots[i] = Vector3.Dot(toEnemyNormal, Direction.Vector[i]);
                distances[i] = toEnemy.magnitude * dots[i];
                if (dots[i] > maxDot)
                {
                    maxDot = dots[i];
                    maxIndex = i;
                }
            }

            return true;
        }

        /// <summary>
        /// 最大の内積値を返す。近過ぎだったら、0を返す。
        /// </summary>
        /// <returns>最大の内積値。近すぎていたら0</returns>
        public float GetMaxDot()
        {
            if (IsTooNear)
            {
                return 0;
            }

            return dots[maxIndex];
        }

        /// <summary>
        /// 最大の内積を返す。距離が近すぎた場合はNoneを返す。
        /// </summary>
        /// <returns>最大の方向をDirection.Indexで返す。近すぎたらNone</returns>
        public Direction.Index GetMaxDotDirection()
        {
            if (IsTooNear)
            {
                return Direction.Index.None;
            }

            return (Direction.Index)maxIndex;
        }

        /// <summary>
        /// 指定の方向の内積値を返す。
        /// </summary>
        /// <param name="index">方向</param>
        /// <returns>内積値</returns>
        public float GetDot(Direction.Index index) => dots[(int)index];
    }
}
