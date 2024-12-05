namespace DAT.NPCTaisen
{
    /// <summary>
    /// 攻撃アクションから、攻撃したことを、コントローラーに知らせるためのインターフェース。
    /// </summary>
    public interface IAttackActionListener
    {
        /// <summary>
        /// 攻撃開始を報告するメソッド。
        /// </summary>
        /// <param name="attack">攻撃するアクションのインスタンス</param>
        void OnAttacking(IAttackActionable attack);
    }
}
