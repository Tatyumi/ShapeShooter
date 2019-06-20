namespace Common
{
    /// <summary>シーン名を持つクラス</summary>
    public sealed class SceneName
    {
        /// <summary>タイトルシーン名</summary>
        public const string TITLE_SCENE = "TitleScene";
        /// <summary>ボスシーン名</summary>
        public const string BOSS_SCENE = "BossScene";
        /// <summary>ステージ名</summary>
        public readonly string[] STAGE_NAMES = {
            "FirstStageScene",
            "SecondStageScene"
        }; 
    }
}