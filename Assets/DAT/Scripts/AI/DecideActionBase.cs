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
        public float[] Points { get; private set; }

        public int Decision
        {
            get
            {
                int index = 0;
                float max = Points[index];
                for (int i = 1; i < Points.Length; i++)
                {
                    if (Points[i] > max)
                    {
                        max = Points[i];
                        index = i;
                    }
                }

                return index;
            }
        }

        public void AddPoint(int index, float point)
        {
            // 初期化前なら何もしない
            if (Points == null)
            {
                return;
            }

            // インデックスが無効なら、何もしない
            if ((index < 0) || (index >= Points.Length))
            {
                return;
            }

            Points[index] += point;
        }

        public void Clear()
        {
            if (Points == null)
            {
                return;
            }

            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = 0;
            }
        }

        public void Init(int count)
        {
            Points = new float[count];
            Clear();
        }
    }
}
