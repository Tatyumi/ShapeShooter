using Common;
using UnityEngine;

public class StageDirector : MonoBehaviour
{
    /// <summary>ステージのBGM名</summary>
    public string StageBgmName;
    /// <summary>オーディオマネージャー</summary>
    protected AudioManager audioManager;

    private void Awake()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // BGMの再生
        audioManager.PlayBGM(StageBgmName);

        // フラグ初期化
        PauseManager.isPause = false;

        // シーン開始時に敵キャラ破壊数を初期化
        ResultPanelController.TempEnemyKillCount = 0;
    }
}