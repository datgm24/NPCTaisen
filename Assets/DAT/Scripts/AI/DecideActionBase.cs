using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 行動の得点を集計して、行動を決めるベースクラス
    /// </summary>
    public class DecideActionBase : IDecideAction
    {
        float[] points;

        public int Decision
        {
            get
            {
                int index = 0;
                float max = points[index];
                for (int i = 1; i < points.Length; i++)
                {
                    if (points[i] > max)
                    {
                        max = points[i];
                        index = i;
                    }
                }

                return index;
            }
        }

        public void AddPoint(int index, float point)
        {
            // 初期化前なら何もしない
            if (points == null)
            {
                return;
            }

            // インデックスが無効なら、何もしない
            if ((index < 0) || (index >= points.Length))
            {
                return;
            }

            points[index] += point;
        }

        public void Clear()
        {
            if (points == null)
            {
                return;
            }

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = 0;
            }
        }

        public void Init(int count)
        {
            points = new float[count];
            Clear();
        }
    }
}
