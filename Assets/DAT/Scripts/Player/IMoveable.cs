using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    public interface IMoveable
    {
        /// <summary>
        /// 移動方向を受け取るので、自分の速度で移動する。
        /// </summary>
        /// <param name="move">移動したい向きベクトル。単位化して利用する。</param>
        void Move(Vector2 move);
    }
}
