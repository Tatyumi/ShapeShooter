
public sealed class LastBossSceneDirector : StageDirector
{
    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // BGMの再生
        audioManager.PlayBGM(audioManager.LastBossSceneBGM.name);

        // フラグ初期化
        PauseManager.isPause = false;
    }
}