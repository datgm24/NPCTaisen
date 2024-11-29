using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAT.NPCTaisen
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPlayResult
    {
        public enum State
        {
            Win1P,
            Win2P,
            Draw,
        }

        /// <summary>
        /// 勝敗を知らせる。
        /// </summary>
        /// <param name="state">勝敗</param>
        void SetResult(State state);
    }
}
