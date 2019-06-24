﻿namespace Common
{
    /// <summary>シーン名を持つクラス</summary>
    public sealed class SceneName
    {
        /// <summary>タイトルシーン名</summary>
        public const string TITLE_SCENE = "TitleScene";
        /// <summary>ボスシーン名</summary>
        public const string BOSS_SCENE = "BossScene";
        /// <summary>エンディングシーン名</summary>
        public const string ENDING_SCENE = "EndingScene";
        /// <summary>ステージ名</summary>
        public readonly string[] STAGE_NAMES = {
            "FirstStageScene",
            "SecondStageScene",
            "ThirdStageScene"
        }; 
    }

    /// <summary>定数を持つクラス</summary>
    public sealed class Constance
    {
        /// <summary>全ての敵の数</summary>
        public const int ALL_ENEMY_COUNT = 147;
    }
}