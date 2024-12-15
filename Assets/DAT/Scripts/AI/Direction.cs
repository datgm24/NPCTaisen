using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public static class Direction
    {
        /// <summary>
        /// 方向インデックス
        /// </summary>
        public enum Index
        {
            None = -1,
            Far,
            FarRight,
            Right,
            NearRight,
            Near,
            NearLeft,
            Left,
            FarLeft,
        }

        /// <summary>
        /// 方向の数
        /// </summary>
        public static int Count => 8;

        /// <summary>
        /// インデックスに対応するベクトル
        /// </summary>
        public static Vector3[] Vector = new Vector3[]{
            Vector3.forward,
            (Vector3.forward+Vector3.right).normalized,
            Vector3.right,
            (Vector3.back+Vector3.right).normalized,
            Vector3.back,
            (Vector3.back+Vector3.left).normalized,
            Vector3.left,
            (Vector3.forward+Vector3.left).normalized,
        };

        /// <summary>
        /// 入力向けにベクトル
        /// </summary>
        public static Vector2[] InputVector = new Vector2[] {
            Vector2.up,
            (Vector2.up+Vector2.right).normalized,
            Vector2.right,
            (Vector2.down+Vector2.right).normalized,
            Vector2.down,
            (Vector2.down+Vector2.left).normalized,
            Vector2.left,
            (Vector2.up+Vector2.left).normalized,
        };

        /// <summary>
        /// 90度ずらしたインデックスを返す。
        /// </summary>
        /// <param name="index">基準のインデックス</param>
        /// <returns>90度進めたインデックス</returns>
        public static Index GetOrthogonalIndex(Index index)
        {
            int degree90 = ((int)index + 2) % Count;
            return (Index)degree90;
        }

        /// <summary>
        /// 逆方向を返す。
        /// </summary>
        /// <param name="index">反転したいインデックス</param>
        /// <returns>反転させたインデックス</returns>
        public static Index GetReverseIndex(Index index)
        {
            int reverse = ((int)index + 4) % Count;
            return (Index)reverse;
        }
    }
}
