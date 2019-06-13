namespace Common
{
    /// <summary>シーン名を持つクラス</summary>
    public sealed class SceneName
    {
        /// <summary>タイトルシーン名</summary>
        public const string TITLE_SCENE = "TitleScene";
        /// <summary>ファーストステージ名</summary>
        public const string FIRST_STAGE_SCENE = "FirstStageScene";
    }

    /// <summary>定数を持つクラス</summary>
    public static class Constans
    {
        /// <summary>ファーストステージのステージ部品の横幅</summary>
        public const float FIRST_STAGE_PART_WIDTH = 5.0f;
    }

    /// <summary>進捗に関するクラス</summary>
    public static class Phase
    {
        /// <summary>中ボス到達フラグ</summary>
        public static bool IsMiddleBoss = false;
    }
}