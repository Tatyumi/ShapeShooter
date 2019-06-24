using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneDirector : StageDirector
{
    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // BGMの再生
        audioManager.PlayBGM(StageBgmName);

        // フラグ初期化
        PauseManager.isPause = false;
    }
}
