namespace DAT.NPCTaisen
{
    /// <summary>
    /// 負けたことを知らせるためのインターフェース
    /// </summary>
    public interface ILoseReportable
    {
        /// <summary>
        /// 負けたことを知らせる。
        /// </summary>
        /// <param name="player">自分のインスタンスを渡す</param>
        void ReportLose(PlayerController player);
    }
}
