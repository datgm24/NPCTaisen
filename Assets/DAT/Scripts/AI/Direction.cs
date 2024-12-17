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
            return GetIndex(index, 2);
        }

        /// <summary>
        /// 逆方向を返す。
        /// </summary>
        /// <param name="index">反転したいインデックス</param>
        /// <returns>反転させたインデックス</returns>
        public static Index GetReverseIndex(Index index)
        {
            return GetIndex(index, 4);
        }

        /// <summary>
        /// 指定のインデックスに、指定の値を足したときのインデックス値を返す。
        /// </summary>
        /// <param name="source">元のインデックス</param>
        /// <param name="add">加算値</param>
        /// <returns>加算後のインデックス</returns>
        public static Index GetIndex(Index source, int add)
        {
            if (add >= 0)
            {
                int plus = ((int)source + add) % Count;
                return (Index)plus;
            }

            // マイナス
            int minus = (int)source + add;
            while (minus < 0)
            {
                minus += Count;
            }
            return (Index)minus;
        }
    }
}
