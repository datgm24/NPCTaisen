using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public interface IDecideAction
    {
        /// <summary>
        /// 指定のインデックスの行動に、指定の値を加点する。
        /// </summary>
        /// <param name="index">行動のインデックス</param>
        /// <param name="point">加点値</param>
        void AddPoint(int index, float point);

        /// <summary>
        /// 得点をリセットする。
        /// </summary>
        void Clear();

        /// <summary>
        /// 行動の数を設定して、初期化する。
        /// </summary>
        /// <param name="count">行動の数</param>
        void Init(int count);

        /// <summary>
        /// 最高点の行動のインデックスを返す。
        /// </summary>
        int Decision { get; }
    }
}
