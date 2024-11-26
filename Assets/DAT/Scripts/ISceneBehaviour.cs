namespace DAT.NPCTaisen
{
    public interface ISceneBehaviour
    {
        /// <summary>
        /// ゲームシステムのインスタンスを受け取って、シーンを開始する。
        /// </summary>
        /// <param name="instance">GameSystemのインスタンス</param>
        void StartScene(GameSystem instance);
    }
}
